using AutoMapper;
using EnglishTeacher.Application.Common.Mappings;
using EnglishTeacher.Application.Words.Query.GetWordDetail;
using EnglishTeacher.Domain.Entities;

namespace EnglishTeacher.Application.Sentences.Query.GetSentenceDetail
{
    public class SentenceDetailVm : IMapForm<Sentence>
    {
        public int Id { get; set; }
        public string EnglishText { get; set; }
        public string PolishText { get; set; }
        public string Word { get; set; }
        public string AddedBy { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Sentence, SentenceDetailVm>()
                .ForMember(dest => dest.EnglishText, map => map.MapFrom(src => src.Text));
        }
    }
}
