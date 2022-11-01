using EnglishTeacher.Application.Common.Exceptions;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Entities;
using EnglishTeacher.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EnglishTeacher.Application.Words.Command.GiveAnswer
{
    public class GiveAnswerCommandHandler : IRequestHandler<GiveAnswerCommand, bool>
    {
        private readonly IWordDbContext _context;
        private readonly IDateTime _dateTime;

        public GiveAnswerCommandHandler(IWordDbContext wordDbContext, IDateTime dateTime)
        {
            _context = wordDbContext;
            _dateTime = dateTime;
        }

        public async Task<bool> Handle(GiveAnswerCommand request, CancellationToken cancellationToken)
        {
            var word = await _context.Words.FirstOrDefaultAsync(x => x.StatusId == 1 && x.Id == request.WordId, cancellationToken);

            if (word == null)
                throw new WordNotFoundException(request.WordId, new Exception());

            var correct = word.EnglishText.Equals(request.Answer);

            if (correct)
            {
                word.AnsweringStatistics.CorrectAnswers++;
            }
            else
            {
                word.AnsweringStatistics.WrongAnswers++;
            }

            word.AnsweringStatistics.LastAnswer = _dateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);
            
            return correct;
        }
    }
}
