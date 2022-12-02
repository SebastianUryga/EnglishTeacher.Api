using System.Threading;
using System.Threading.Tasks;
using Application.UnitTests.Common;
using AutoMapper;
using EnglishTeacher.Application.Words.Query.GetWords;
using EnglishTeacher.Persistance;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Word.Queries;

[Collection("QueryCollection")]
public class GetWordsQueryHandlerTests
{
    private readonly WordDbContext _context;
    private readonly IMapper _mapper;

    public GetWordsQueryHandlerTests(QueryTestFixtures fixtures)
    {
        _context = fixtures.Context;
        _mapper = fixtures.Mapper;
    }

    [Fact]
    public async Task CanGetWords()
    {
        var handler = new GetWordsQueryHandler(_context, _mapper);
        var result = await handler.Handle(new GetWordsQuery(), CancellationToken.None);

        result.ShouldBeOfType<WordsVm>();
        result.Words.Count.ShouldBe(6);
    }
}