using EnglishTeacher.Application.Sentences.Query.GetSentences;
using MediatR;

namespace EnglishTeacher.Application.Sentences.Query.GetSentenceExamples
{
    public class GetSentenceExamplesQuery : IRequest<string[]>
    {
        public string Word { get; set; }
    }
}
