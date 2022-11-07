using FluentValidation;

namespace EnglishTeacher.Application.Sentences.Command.AddSentence;

public class AddSentenceCommandValidator : AbstractValidator<AddSentenceCommand>
{
    public AddSentenceCommandValidator()
    {
        RuleFor(x => x.EnglishText).NotEmpty();
    }
}