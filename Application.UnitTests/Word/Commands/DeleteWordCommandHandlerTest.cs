using Application.UnitTests.Common;
using EnglishTeacher.Application.Common.Exceptions;
using EnglishTeacher.Application.Words.Command.CreateWord;
using EnglishTeacher.Application.Words.Command.DeleteWord;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Word.Commands
{
    public class DeleteWordCommandHandlerTest : CommandTestBase
    {
        private DeleteWordCommandHandler _handler;

        public DeleteWordCommandHandlerTest()
            : base()
        {
            _handler = new DeleteWordCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenNotExistingWordId_ShouldThrowNotFoundExcetpion()
        {
            var command = new DeleteWordCommand()
            {
                WordId = 0
            };
            var word = await _context.Words.Where(x => x.Id == 0).FirstOrDefaultAsync(CancellationToken.None);
            word.ShouldBeNull();

            var exception = await Record.ExceptionAsync(() => _handler.Handle(command, CancellationToken.None));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<WordNotFoundException>();
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldRemoveWord()
        {
            var command = new DeleteWordCommand()
            {
                WordId = 2
            };
            var word = await _context.Words.Where(x => x.Id == 2).FirstOrDefaultAsync(CancellationToken.None);
            word.ShouldNotBeNull();
            word.StatusId.ShouldBe(1);

            var result = _handler.Handle(command, CancellationToken.None);

            await result.ShouldNotThrowAsync();
            word.ShouldNotBeNull();
            word.StatusId.ShouldBe(0);
        }
    }
}
