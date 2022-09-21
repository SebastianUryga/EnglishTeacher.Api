using EnglishTeacher.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EnglishTeacher.Infrastructure.ExternalAPI.Dictionary;
using EnglishTeacher.Infrastructure.FileStore;
using EnglishTeacher.Infrastructure.Services;
using System.Net.Http;

namespace EnglishTeacher.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("DictionaryClient", option =>
            {
                 option.BaseAddress = new Uri("ttps://api.dictionaryapi.dev/api/v2/entries/en/");
                 option.Timeout = new TimeSpan(0, 0, 10);
                 option.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            }).ConfigurePrimaryHttpMessageHandler(sp => new HttpClientHandler());

            services.AddScoped<IDictionaryClient, DictionaryClient>();

            services.AddTransient<IDirectoryWrapper, DirectoryWrapper>();
            services.AddTransient<IFileWrapper, FileWrapper>();
            services.AddTransient<IFileStore, FileStore.FileStore>();
            services.AddTransient<IDateTime, DateTimeService>();
            return services;
        }
    }
}