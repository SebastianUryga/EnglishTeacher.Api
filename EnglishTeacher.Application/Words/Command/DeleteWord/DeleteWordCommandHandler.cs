using EnglishTeacher.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EnglishTeacher.Application.Words.Command.DeleteWord
{
    public class DeleteWordCommandHandler : IRequestHandler<DeleteWordCommand>
    {
        private readonly IWordDbContext _context;

        public DeleteWordCommandHandler(IWordDbContext wordDbContext)
        {
            _context = wordDbContext;
        }

        public async Task<Unit> Handle(DeleteWordCommand request, CancellationToken cancellationToken)
        {
            var word = await _context.Words.Where(p => p.Id == request.WordId).FirstOrDefaultAsync(cancellationToken);

            _context.Words.Remove(word);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
