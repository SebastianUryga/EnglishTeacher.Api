using EnglishTeacher.Application.Common.Mappings;

namespace EnglishTeacher.Application.Sentences.Query.GetSentences
{
    public class SentencesVm : IMapForm<ICollection<SentenceDto>>
    {
        public ICollection<SentenceDto> Sentences { get; set; }
    }
}
