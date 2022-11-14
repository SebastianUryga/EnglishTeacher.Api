using AutoMapper;
using EnglishTeacher.Application.Common.Mappings;
using EnglishTeacher.Domain.Entities;

namespace EnglishTeacher.Application.Words.Query.GetWords
{
    public class WordDto : IMapForm<Word>
    {
        public int Id { get; set; }
        public string EnglishText { get; set; }
        public string PolishText { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Word, WordDto>();
        }
    }
}