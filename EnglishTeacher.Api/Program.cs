using EnglishTeacher.Persistance;
using EnglishTeacher.Infrastructure;
using EnglishTeacher.Application;
using IdentityModel;
using Serilog;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Api.Service;
using EnglishTeacher.Api;
using EnglishTeacher.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddDefaultPolicy(
policy =>
{
    policy.WithOrigins("https://localhost:5000").AllowAnyMethod().AllowAnyHeader();
}));

if (builder.Environment.IsEnvironment("Test"))
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("WordDatabase")));

    builder.Services.AddDefaultIdentity<ApplicationUser>()
        .AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddIdentityServer()
        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
         {
             options.ApiResources.Add(new ApiResource("api1"));
             options.ApiScopes.Add(new ApiScope("api1"));
             options.Clients.Add(new Client
             {
                 ClientId = "client",
                 AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                 ClientSecrets = { new Secret("secret".Sha256()) },
                 AllowedScopes = { "openid", "profile", "EnglishTeacher.ApiAPI", "api1" }
             });
         }).AddTestUsers(new List<TestUser>
         {
             new TestUser
             {
                SubjectId = "4B434A88-212D-4A4D-A17C-F35102D73CBB",
                Username = "alice",
                Password = "Pass123$",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Email, "alice@user.com"),
                    new Claim(ClaimTypes.Name, "alice")
                }
             }
         });
    builder.Services.AddAuthentication("Bearer")
        .AddIdentityServerJwt();
}
else
{
    builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5001";
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = false
        };
    });
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("ApiScope", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("scope", "api1");
        });
    });
}
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.TryAddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
                TokenUrl = new Uri("https://localhost:5001/connect/token"),
                Scopes = new Dictionary<string, string>
                {
                    {"api1", "Full access" },
                }
            }
        }
    });
    x.OperationFilter<AuthorizeCheckOperationFilter>();
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Description = "Description",
        Title = "EnglishTeacher",
        Version = "v1",
    });

    var filePath = Path.Combine(AppContext.BaseDirectory, "EnglishTeacher.Api.xml");
    x.IncludeXmlComments(filePath);
});

builder.Services.AddHealthChecks();

var app = builder.Build();

try
{
    Log.Information("Application is starting up");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "EnglishTeacher v1");
            c.OAuthClientId("swagger");
            c.OAuth2RedirectUrl("https://localhost:7168/swagger/oauth2-redirect.html");
            //c.OAuthUsePkce();
        });
    }
    app.UseHealthChecks("/hc");
    app.UseHttpsRedirection();

    app.UseSerilogRequestLogging();

    app.UseCors();
    app.UseRouting();

    app.UseAuthentication();
    if (app.Environment.IsEnvironment("Test"))
    {
        app.UseIdentityServer();
    }
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    //.RequireAuthorization("ApiScope");

        app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Application couldn't start up");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program { }