using EnglishTeacher.Application.Common.Exceptions;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Common;
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
            var word = await _context.Words
                .Where(p => p.Id == request.WordId && p.Status == Status.Active)
                .FirstOrDefaultAsync(cancellationToken);
            
            try
            {
                _context.Words.Remove(word);
            }
            catch (Exception ex)
            {
                throw new WordNotFoundException(request.WordId, ex);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
