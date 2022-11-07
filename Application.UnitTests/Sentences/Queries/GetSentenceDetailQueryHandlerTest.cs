using System.Threading;
using System.Threading.Tasks;
using Application.UnitTests.Common;
using AutoMapper;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Application.Common.Mappings;
using EnglishTeacher.Application.Sentences.Query.GetSentenceDetail;
using Microsoft.AspNetCore.Http;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Sentences.Queries
{
    [Collection("QueryCollection")]
    public class GetSentenceDetailQueryHandlerTest
    {
        private readonly IWordDbContext _context;
        private readonly IMapper _mapper;
        public GetSentenceDetailQueryHandlerTest(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task QueryHandler_ExistingSentenceId_ShouldReturnValidSentence()
        {
            var query = new GetSentenceDetailQuery { Id = 4 };
            var handler = new GetSentenceDetailQueryHandler(_mapper, _context);

            var result = await handler.Handle(query, CancellationToken.None);
            result.ShouldBeOfType(typeof(SentenceDetailVm));
            result.EnglishText.ShouldBe("Mouse is very small animal");
            result.AddedBy.ShouldBe("Admin");
        }
    }
}
