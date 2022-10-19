using Application.UnitTests.Common;
using AutoMapper;
using EnglishTeacher.Application.Words.Query.GetWordDetail;
using EnglishTeacher.Persistance;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Word.Queries
{
    [Collection("QueryCollection")]
    public class GetWordDetailQueryHandlerTests
    {
        private readonly WordDbContext _context;
        private readonly IMapper _mapper;
        public GetWordDetailQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }
        [Fact]
        public async Task CanGetWordDetailById()
        {
            var handler = new GetWordDetailQueryHandler(_context, _mapper);

            var wordId = 3;

            var restult = await handler.Handle(new GetWordDetailQuery { WordId = wordId }, CancellationToken.None);

            restult.ShouldBeOfType<WordDetialVm>();
            restult.EnglishText.ShouldBe("Mouse");
        }
    }
}
