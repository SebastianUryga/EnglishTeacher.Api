using FluentValidation;

namespace EnglishTeacher.Application.Words.Command.CreateWord
{
    public class CreateWordCommandValidator : AbstractValidator<CreateWordCommand>
    {
        public CreateWordCommandValidator()
        {
            RuleFor(x => x.EnglishText).NotEmpty();
            RuleFor(x => x.PolishText).NotEmpty();
        }
    }
}
