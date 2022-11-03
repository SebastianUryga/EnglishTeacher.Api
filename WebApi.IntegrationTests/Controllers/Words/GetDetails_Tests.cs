using System.Net.Http;
using EnglishTeacher.Application.Words.Query.GetWordDetail;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Shouldly;
using System.Threading.Tasks;
using WebApi.IntegrationTests.Common;
using Xunit;

namespace WebApi.IntegrationTests.Controllers.Words
{
    public class GetDetails_Tests : IClassFixture<CustomWebApplicationFactory<Program>> 
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public GetDetails_Tests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenWordIdByAthenticatedClient_ReturnWordsDetail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string id = "2";
            var response = await client.GetAsync($"/api/words/{id}");
            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<WordDetailVm>(response);

            result.EnglishText.ShouldBe("Mouse");
        }

        [Fact]
        public async Task GivenWordId_ReturnWordsDetail()
        {
            var client = _factory.CreateClient();

            string id = "2";
            var response = await client.GetAsync($"/api/words/{id}");
            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<WordDetailVm>(response);

            result.EnglishText.ShouldBe("Mouse");
        }
    }
}
