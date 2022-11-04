using System.Drawing;
using System.Net.Http.Headers;
using AutoMapper;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Application.Sentences.Query.GetSentences;
using MediatR;
using Newtonsoft.Json;

namespace EnglishTeacher.Application.Sentences.Query.GetSentenceExamples
{
    public class GetSentenceExamplesQueryHandler : IRequestHandler<GetSentenceExamplesQuery, string[]>
    {
        private readonly IMapper _mapper;
        private readonly IDictionaryClient _dictionary;
        public GetSentenceExamplesQueryHandler(IMapper mapper, IDictionaryClient dictionary)
        {
            _mapper = mapper;
            _dictionary = dictionary;
        }
        public async Task<string[]> Handle(GetSentenceExamplesQuery request, CancellationToken cancellationToken)
        {
            var stringRepose = await _dictionary.GetExample(request.Word);
            //currently not working
            var result = JsonConvert.DeserializeObject<ICollection<WordFromDictionaryModel>>(stringRepose);

            return result?.FirstOrDefault()?.Meanings.SelectMany(x => x.Definitions).Select(x => x.Example).Where(x => x != null).ToArray();
        }
    }
}
