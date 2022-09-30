﻿using FluentValidation;
using MediatR;

namespace EnglishTeacher.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var failurers = _validators.Select(v => v.Validate(context)).SelectMany(result => result.Errors).Where(x => x != null).ToList();
                
                if(failurers.Any())
                {
                    throw new ValidationException(failurers);
                }
            }
            return await next();
        }
    }
}
