using EnglishTeacher.Application.Common.Mappings;
using EnglishTeacher.Application.Words.Query.GetWords;

namespace EnglishTeacher.Application.Sentences.Query.GetSentences
{
    public class SentencesVm : IMapForm<ICollection<SentenceDto>>
    {
        public ICollection<SentenceDto> Sentences { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<ICollection<SentenceDto>, SentencesVm>()
                .ForMember(dst => dst.Sentences, map => map.MapFrom(src => src));
        }
    }
}
