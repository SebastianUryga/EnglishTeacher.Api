using EnglishTeacher.Application.Common.Interfaces;
using System.Net.Http;
using System.Text;

namespace EnglishTeacher.Infrastructure.ExternalAPI.Dictionary
{
    public partial class DictionaryClient : IDictionaryClient
    {
        private string _baseUrl = "https://api.dictionaryapi.dev/api/v2/entries/en/";
        private readonly HttpClient _httpClient;
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

        public DictionaryClient(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("Dictionary");
            _baseUrl = _httpClient.BaseAddress.ToString();
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(() =>
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }

        protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);

        public async Task<string> GetExample(string word)
        {

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl);
            urlBuilder.Append($"&t={word}");
            var client = _httpClient;
            try
            {
                using(var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                    var response = await client.SendAsync(request,HttpCompletionOption.ResponseHeadersRead);
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var responceData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        return responceData;
                    }
                    else if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return $"Word {word} doesn't exist in Dictionary.";
                    }
                    else
                    {
                        return "Something goes wrong.";
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string BaseUrl { 
            get { return _baseUrl; }
            set { _baseUrl = value; } 
        }
    }
}
