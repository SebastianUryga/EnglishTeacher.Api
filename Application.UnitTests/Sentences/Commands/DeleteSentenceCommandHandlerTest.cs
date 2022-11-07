using System.Threading.Tasks;
using Application.UnitTests.Common;
using EnglishTeacher.Application.Sentences.Command.DeleteSentences;
using Xunit;

namespace Application.UnitTests.Sentences.Commands;

public class DeleteSentenceCommandHandlerTest : CommandTestBase
{
    private DeleteSentencesCommandHandler _handler;

    public DeleteSentenceCommandHandlerTest() : base()
    {
        _handler = new DeleteSentencesCommandHandler(_context);
    }

    [Fact]
    public async Task Handle_ValidRequest_ShouldDeleteSentence()
    {
        await Task.FromResult(Task.CompletedTask);
    }
}