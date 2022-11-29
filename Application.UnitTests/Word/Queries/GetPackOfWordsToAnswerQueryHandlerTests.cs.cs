using System.Collections.Generic;
using Application.UnitTests.Common;
using AutoMapper;
using EnglishTeacher.Application.Words.Query.GetWords;
using EnglishTeacher.Domain.Common;
using EnglishTeacher.Persistance;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Application.Words.Query.GetPackOfRandomWords;
using EnglishTeacher.Domain.Policies;
using Moq;
using Xunit;
using System;

namespace Application.UnitTests.Word.Queries
{
    [Collection("QueryCollection")]
    public class GetPackOfWordsToAnswerQueryHandlerTests
    {
        private readonly WordDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IWordProbabilityValuePolicy> _policies;
        private readonly Mock<IDateTime> _dateTimeMock;

        public GetPackOfWordsToAnswerQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
            _policies = fixtures.Policies;
            var dateTime = new DateTime(2022, 2, 2);
            _dateTimeMock = new Mock<IDateTime>();
            _dateTimeMock.Setup(m => m.Now).Returns(dateTime);
        }
        [Fact]
        public async Task Handle_ValidCommand_ReturnsExpectedValue()
        {
            var handler = new GetPackOfWordsToAnswerQueryHandler(_context, _mapper, _policies, _dateTimeMock.Object);

            var quantity = 2;

            var result = await handler.Handle(new GetPackOfWordsToAnswerQuery() { MaxQuantity = quantity }, CancellationToken.None);

            result.ShouldBeOfType<WordsVm>();
            result.Words.Count().ShouldBe(quantity);
        }

        [Fact]
        public async Task Handle_GivenMaxQuantityPropOverDbSize_shouldReturnAllFromDb()
        {
            var handler = new GetPackOfWordsToAnswerQueryHandler(_context, _mapper, _policies, _dateTimeMock.Object);

            var quantity = await _context.Words.CountAsync(x => x.Status == Status.Active, CancellationToken.None);

            var result = await handler.Handle(new GetPackOfWordsToAnswerQuery { MaxQuantity = quantity + 1 }, CancellationToken.None);

            result.Words.Count().ShouldBe(quantity);
        }

        [Fact]
        public async Task Handle_ValidCommand_ReturnsCoupleOfWordsInRightOrder()
        {
            var handler = new GetPackOfWordsToAnswerQueryHandler(_context, _mapper, _policies, _dateTimeMock.Object);
            var result = await handler.Handle(new GetPackOfWordsToAnswerQuery { MaxQuantity = 2 }, CancellationToken.None);
            result.Words.ElementAt(0).EnglishText.ShouldBe("First");
            result.Words.ElementAt(1).EnglishText.ShouldBe("Second");
        }
    }
}
