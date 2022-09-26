using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace EnglishTeacher.Application.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var reqestName = typeof(TRequest).Name;

            _logger.LogInformation("EnglishTeacher Reqest: {Name} {@Request}",
                reqestName, request);
        }
    }
}
