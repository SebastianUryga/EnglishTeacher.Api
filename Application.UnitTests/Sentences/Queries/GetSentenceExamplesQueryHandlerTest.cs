using System.Threading;
using System.Threading.Tasks;
using Application.UnitTests.Common;
using AutoMapper;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Application.Sentences.Query.GetSentenceExamples;
using EnglishTeacher.Persistance;
using Microsoft.Extensions.FileProviders;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Sentences.Queries
{
    public class GetSentenceExamplesQueryHandlerTest
    {
        private readonly IDictionaryClient _dictionary;
        public GetSentenceExamplesQueryHandlerTest(IDictionaryClient dictionary)
        {
            _dictionary = dictionary;
        }

        [Fact]
        public async Task GetSentenceExamplesHandle_GivenValidWord_ReturnsCoupleOfExamples()
        {
            var word = "blanket";
            var handler = new GetSentenceExamplesQueryHandler(_dictionary);

            var query = new GetSentenceExamplesQuery { Word = word };
            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldNotBeEmpty();
        }
    }
}
