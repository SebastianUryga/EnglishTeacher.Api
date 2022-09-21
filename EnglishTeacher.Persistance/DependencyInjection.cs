using EnglishTeacher.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishTeacher.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WordDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("WordDatabase")));
            services.AddScoped<IWordDbContext, WordDbContext>();
            return services;

        }
    }
}