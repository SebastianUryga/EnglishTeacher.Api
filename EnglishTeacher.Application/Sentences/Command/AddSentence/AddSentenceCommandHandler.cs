using EnglishTeacher.Application.Common.Exceptions;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Entities;
using MediatR;

namespace EnglishTeacher.Application.Sentences.Command.AddSentence;

public class AddSentenceCommandHandler : IRequestHandler<AddSentenceCommand, int>
{
    private readonly IWordDbContext _context;

    public AddSentenceCommandHandler(IWordDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(AddSentenceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var word = await _context.Words.FindAsync(request.WordId);
            if (word == null)
                throw new WordNotFoundException(request.WordId, new Exception());

            if (!request.EnglishText.Contains(word.EnglishText, StringComparison.OrdinalIgnoreCase))
                throw new SentenceDoesNotContainRelatedWord(word.EnglishText);

            var sentence = new Sentence()
            {
                Text = request.EnglishText,
                Word = word,
            };

            _context.Sentences.Add(sentence);

            await _context.SaveChangesAsync(cancellationToken);

            return sentence.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}