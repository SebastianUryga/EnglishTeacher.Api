using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Persistance;
using IdentityModel.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.IntegrationTests.Common
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            try
            {
                builder.ConfigureServices(services =>
                {
                    var serviceProvider = new ServiceCollection()
                        .AddEntityFrameworkInMemoryDatabase()
                        .BuildServiceProvider();

                    services.AddDbContext<WordDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                        options.UseInternalServiceProvider(serviceProvider);
                    });

                    services.AddScoped<IWordDbContext>(provider => provider.GetService<WordDbContext>());

                    var sp = services.BuildServiceProvider();

                    using var scope = sp.CreateScope();
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<WordDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    db.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                            "database with test messages. Error: {Message}", ex.Message);
                    }
                })
                .UseEnvironment("Test");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<HttpClient> GetAuthenticatedClientAsync()
        {
            var client = CreateClient();

            var token = await GetAccessToken(client, "alice", "Pass123$");
            client.SetBearerToken(token);
            return client;
        }

        private async Task<string> GetAccessToken(HttpClient client, string userName, string password)
        {
            var disco = await client.GetDiscoveryDocumentAsync();

            if (disco.IsError)
                throw new Exception(disco.Error);

            var responce = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "openid profile EnglishTeacher.ApiAPI api1",
                UserName = userName,
                Password = password
            });

            if (responce.IsError)
            {
                throw new Exception(responce.Error);
            }

            return responce.AccessToken;
        }
    }
}