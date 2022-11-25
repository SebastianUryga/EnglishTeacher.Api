using Application.UnitTests.Common;
using AutoMapper;
using EnglishTeacher.Application.Words.Query.GetWords;
using EnglishTeacher.Domain.Common;
using EnglishTeacher.Persistance;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Word.Queries
{
    [Collection("QueryCollection")]
    public class GetRandomWordsQueryHandlerTests
    {
        private readonly WordDbContext _context;
        private readonly IMapper _mapper;
        public GetRandomWordsQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }
        [Fact]
        public async Task CanGetRandomWords()
        {
            var handler = new GetRandomWordsQueryHandler(_context, _mapper);

            var quantity = 2;

            var result = await handler.Handle(new GetRandomWordsQuery { MaxQuantity = quantity }, CancellationToken.None);

            result.ShouldBeOfType<WordsVm>();
            result.Words.Count().ShouldBe(quantity);
        }

        [Fact]
        public async Task Handle_GivenMaxQuantityPropOverDbSize_shouldReturnAllFromDb()
        {
            var handler = new GetRandomWordsQueryHandler(_context, _mapper);

            var quantity = await _context.Words.CountAsync(x => x.Status == Status.Active, CancellationToken.None);

            var result = await handler.Handle(new GetRandomWordsQuery { MaxQuantity = quantity + 1 }, CancellationToken.None);

            result.Words.Count().ShouldBe(quantity);
        }
    }
}
