using EnglishTeacher.Persistance;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
options.AddPolicy(name: "myPolicy",
builder =>
{
    builder.AllowAnyOrigin();
}));

builder.Services.AddPersistance(builder.Configuration);
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHealthChecks("/hc");
app.UseHttpsRedirection();

app.UseCors();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
