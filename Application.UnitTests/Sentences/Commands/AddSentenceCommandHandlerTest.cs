using System.Threading;
using System.Threading.Tasks;
using Application.UnitTests.Common;
using EnglishTeacher.Application.Common.Exceptions;
using EnglishTeacher.Application.Sentences.Command.AddSentence;
using EnglishTeacher.Application.Words.Command.CreateWord;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Sentences.Commands
{
    public class AddSentenceCommandHandlerTest : CommandTestBase
    {
        private AddSentenceCommandHandler _handler;

        public AddSentenceCommandHandlerTest() :base()
        {
            _handler = new AddSentenceCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldInsertSentence()
        {
            string englishText = "I immediately deleted the program and have not used it since.";
            string polishText = "Natychmiast usunąłem program i od tego czasu nie używałem go.";
            var command = new AddSentenceCommand()
            {
                EnglishText = englishText,
                PolishText = polishText,
                WordId = 2,
            };
            var result = await _handler.Handle(command, CancellationToken.None);
            var sentence = await _context.Sentences.FirstOrDefaultAsync(t => t.Id == result, CancellationToken.None);

            sentence.ShouldNotBeNull();
            sentence.Text.ShouldBe(englishText);
        }

        [Fact]
        public async Task Handle_MissingWordInSentenceRequest_ShouldThrowException()
        {
            var command = new AddSentenceCommand()
            {
                EnglishText = "I immediately installed the program and have not used it since.",
                PolishText = "Natychmiast zainstalowałem program i od tego czasu nie używałem go.",
                WordId = 2,
            };

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<SentenceDoesNotContainRelatedWord>();
        }
    }
}
