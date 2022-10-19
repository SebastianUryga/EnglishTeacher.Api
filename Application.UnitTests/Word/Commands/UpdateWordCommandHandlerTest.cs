using Application.UnitTests.Common;
using AutoMapper;
using EnglishTeacher.Application.Words.Command.UpdateWord;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Word
{
    public class UpdateWordCommandHandlerTest : CommandTestBase
    {
        private UpdateWordCommandHandler _handler;

        public UpdateWordCommandHandlerTest()
            :base()
        {
            _handler = new UpdateWordCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldNotCrash()
        {
            var wordId = 1;
            var word = await _context.Words.FirstOrDefaultAsync(t => t.Id == wordId, CancellationToken.None);

            var command = new UpdateWordCommand()
            {
                WordId = wordId,
                EnglishText = word.EnglishText,
                PolishText = word.PolishText
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            word.ShouldNotBeNull();
        }
    }
}
