using Application.UnitTests.Common;
using EnglishTeacher.Application.Words.Command.CreateWord;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Word
{
    public class CreateWordCommandHandlerTest : CommandTestBase
    {
        private CreateWordCommandHandler _handler;

        public CreateWordCommandHandlerTest()
            :base()
        {
            _handler = new CreateWordCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertWord()
        {
            var command = new CreateWordCommand()
            {
                EnglishText = "Scissors",
                PolishText = "Nożyce"
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var word = await _context.Words.FirstOrDefaultAsync(t => t.Id == result, CancellationToken.None);

            word.ShouldNotBeNull();
        }
    }
}
