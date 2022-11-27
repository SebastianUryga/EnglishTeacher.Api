using FluentValidation;

namespace EnglishTeacher.Application.Words.Command.UpdateWord
{
    public class UpdateWordCommandValidator : AbstractValidator<UpdateWordCommand>
    {
        public UpdateWordCommandValidator()
        {
            RuleFor(x => x.WordId).GreaterThan(0);
            RuleFor(x => x.EnglishText).NotEmpty().Must(x => x.Length == x.Trim().Length);
            RuleFor(x => x.PolishText).NotEmpty().Must(x => x.Length == x.Trim().Length);
        }
    }
}
