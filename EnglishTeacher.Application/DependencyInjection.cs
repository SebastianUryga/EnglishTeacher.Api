using EnglishTeacher.Application.Behaviours;
using EnglishTeacher.Domain.Policies;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EnglishTeacher.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddSingleton<IRandomProbabilityValuePolicy, RatioOfCorrectAnswersPolicy>();
            services.AddSingleton<IRandomProbabilityValuePolicy, TimePassedSinceLastAnswerPolicy>();
            services.AddSingleton<IRandomProbabilityValuePolicy, UnpracticedWordsPolicy>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IRequestPreProcessor<>), typeof(LoggingBehaviour<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            return services;
        }
    }
}
