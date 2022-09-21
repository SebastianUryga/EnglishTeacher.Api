using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Entities;
using MediatR;

namespace EnglishTeacher.Application.Words.Command.CreateWord
{
    public class CreateWordComandHandler : IRequestHandler<CreateWordCommand, int>
    {
        private readonly IWordDbContext _context;

        public CreateWordComandHandler(IWordDbContext wordDbContext)
        {
            _context = wordDbContext;
        }

        public async Task<int> Handle(CreateWordCommand request, CancellationToken cancellationToken)
        {
            var word = new Word
            {
                EnglishText = request.EnglishText,
                PolishText = request.PolishText,
                WrongAnswers = 0,
                CorrectAnswers = 0,
                LastAnswer = null,
            };
            _context.Words.Add(word);

            await _context.SaveChangesAsync(cancellationToken);
            
            return word.Id;
        }
    }
}
