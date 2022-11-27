using AutoMapper;
using EnglishTeacher.Application.Common.Exceptions;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Application.Words.Query.GetWordDetail;
using EnglishTeacher.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EnglishTeacher.Application.Words.Command.UpdateWord
{
    public class UpdateWordCommandHandler : IRequestHandler<UpdateWordCommand,WordDetailVm>
    {
        private readonly IWordDbContext _context;
        private readonly IMapper _mapper;

        public UpdateWordCommandHandler(IWordDbContext wordDbContext)
        {
            _context = wordDbContext;
            //_mapper = mapper;
        }

        public async Task<WordDetailVm> Handle(UpdateWordCommand request, CancellationToken cancellationToken)
        {
            var word = await _context.Words.Where(p => p.Id == request.WordId).FirstOrDefaultAsync(cancellationToken);
            if (word == null)
            {
                throw new WordNotFoundException(request.WordId);
            }
            word.EnglishText = request.EnglishText;
            word.PolishText = request.PolishText;

            _context.Words.Update(word);

            await _context.SaveChangesAsync(cancellationToken);

            return new WordDetailVm() 
            {
                EnglishText = word.EnglishText,
                PolishText = word.PolishText,
                Id = word.Id,
                CorrectAnswers = word.AnsweringStatistics.CorrectAnswers,
                WrongAnswers = word.AnsweringStatistics.WrongAnswers,
                LastAnswers = word.AnsweringStatistics.LastAnswer,
            };
        }
    }
}
