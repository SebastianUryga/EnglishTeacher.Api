using EnglishTeacher.Application.Common.Exceptions;
using EnglishTeacher.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EnglishTeacher.Application.Sentences.Command.DeleteSentences;

public class DeleteSentencesCommandHandler : IRequestHandler<DeleteSentencesCommand>
{
    private readonly IWordDbContext _context;

    public DeleteSentencesCommandHandler(IWordDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteSentencesCommand request, CancellationToken cancellationToken)
    {
        var sentence = await _context.Sentences.Where(p => p.Id == request.SentenceId && p.StatusId == 1).FirstOrDefaultAsync(cancellationToken);

        try
        {
            _context.Sentences.Remove(sentence);
        }
        catch (Exception ex)
        {
            throw new SentenceNotFoundException(request.SentenceId, ex);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}