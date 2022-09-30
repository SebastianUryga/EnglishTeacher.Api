using EnglishTeacher.Persistance;
using EnglishTeacher.Infrastructure;
using Microsoft.Extensions.Configuration;
using EnglishTeacher.Application;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddCors(options =>
options.AddPolicy(name: "myPolicy",
builder =>
{
    builder.AllowAnyOrigin();
}));
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
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
        app.UseSwaggerUI();
    }
    app.UseHealthChecks("/hc");
    app.UseHttpsRedirection();

    app.UseSerilogRequestLogging();

    app.UseCors();
    app.UseRouting();
    app.UseAuthorization();

    app.MapControllers();

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

