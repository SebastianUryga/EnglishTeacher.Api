using Application.UnitTests.Common;
using AutoMapper;
using EnglishTeacher.Application.Words.Command.UpdateWord;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EnglishTeacher.Application.Words.Command.GiveAnswer;
using Xunit;
using EnglishTeacher.Infrastructure.Services;
using EnglishTeacher.Domain.Entities;

namespace Application.UnitTests.Word
{
    public class GiveAnswerCommandHandlerTest : CommandTestBase
    {
        private GiveAnswerCommandHandler _handler;

        public GiveAnswerCommandHandlerTest()
            : base()
        {
            _handler = new GiveAnswerCommandHandler(_context, _dateTime);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldNotCrash()
        {
            var wordId = 1;

            var command = new GiveAnswerCommand()
            {
                WordId = wordId,
                Answer = "Answer",
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            result.ShouldBeFalse();

        }

        [Fact]

        public async Task CommandHandler_GiveAnswers_ShouldChangeAnswerStatistics()
        {
            var wordId = 1;

            var word = await _context.Words.FirstOrDefaultAsync(t => t.Id == wordId, CancellationToken.None);
            var commands = new[]
            {
                new GiveAnswerCommand { WordId = wordId, Answer = "WrongAnswer" },
                new GiveAnswerCommand { WordId = wordId, Answer = word.EnglishText },
            };
            foreach (var command in commands)
            {
                await _handler.Handle(command, CancellationToken.None);
                Thread.Sleep(1);
                word.AnsweringStatistics.LastAnswer.ShouldBeLessThan(_dateTime.Now);
            }

            word.AnsweringStatistics.WrongAnswers.ShouldBe(1);
            word.AnsweringStatistics.CorrectAnswers.ShouldBe(1);
        }
    }
}
