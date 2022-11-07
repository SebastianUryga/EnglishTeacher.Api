using EnglishTeacher.Application.Common.Interfaces;
using MediatR;

namespace EnglishTeacher.Application.Sentences.Command.DeleteSentences;

public class DeleteSentencesCommandHandler : IRequestHandler<DeleteSentencesCommand>
{
    private readonly IWordDbContext _context;

    public DeleteSentencesCommandHandler(IWordDbContext context)
    {
        _context = context;
    }
    public Task<Unit> Handle(DeleteSentencesCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}