using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Entities;
using EnglishTeacher.Domain.ValueObjects;
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
                //TODO: check if these values will be added by default
                AnsweringStatistics = new AnsweringStatistics()
                {
                    WrongAnswers = 0,
                    CorrectAnswers = 0,
                    LastAnswer = DateTime.Now,
                }
            };
            _context.Words.Add(word);

            await _context.SaveChangesAsync(cancellationToken);
            
            return word.Id;
        }
    }
}
