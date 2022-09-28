using EnglishTeacher.Application.Common.Mappings;

namespace EnglishTeacher.Application.Words.Query.GetWords
{
    public class WordsVm : IMapForm<ICollection<WordDto>>
    {
        public ICollection<WordDto> Words { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<ICollection<WordDto>, WordsVm>()
                .ForMember(dst => dst.Words, map => map.MapFrom(src => src));
        }
    }
}
