using FluentValidation;

namespace EnglishTeacher.Application.Words.Command.CreateWord
{
    public class CreateWordCommandValidator : AbstractValidator<CreateWordCommand>
    {
        public CreateWordCommandValidator()
        {
            RuleFor(x => x.EnglishText).NotEmpty().Must(x => x.Length == x.Trim().Length);
            RuleFor(x => x.PolishText).NotEmpty().Must(x => x.Length == x.Trim().Length);
        }
    }
}
