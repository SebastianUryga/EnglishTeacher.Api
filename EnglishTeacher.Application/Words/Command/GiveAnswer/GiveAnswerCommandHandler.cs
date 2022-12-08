using EnglishTeacher.Application.Common.Exceptions;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Common;
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
            var word = await _context.Words
                .FirstOrDefaultAsync(x => x.Status == Status.Active && x.Id == request.WordId, cancellationToken);

            if (word == null)
                throw new WordNotFoundException(request.WordId);

            var answer = new Answer()
            {
                WordId = word.Id,
                AnswerText = request.Answer,
                AnswerDate = _dateTime.Now
            };
            
            _context.Answers.Add(answer);
            
            //word.AnswersHistory.Add(answer);

            var correct = word.EnglishText.Equals(request.Answer, StringComparison.OrdinalIgnoreCase);

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
