using AutoMapper;
using EnglishTeacher.Application.Common.Mappings;
using EnglishTeacher.Domain.Entities;

namespace EnglishTeacher.Application.Sentences.Query.GetSentences;

public class SentenceDto :IMapForm<Sentence>
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Word { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Sentence, SentenceDto>()
            .ForMember(dst => dst.Word, map => map.MapFrom(src => src.Word.EnglishText));
    }
}