using AutoMapper;
using EnglishTeacher.Application.Common.Mappings;
using EnglishTeacher.Domain.Entities;
using System;

namespace EnglishTeacher.Application.Words.Query.GetWordDetail
{
    public class WordDetialVm : IMapForm<Word>
    {
        public int Id { get; set; }
        public string PolishText { get; set; }
        public string EnglishText { get; set; }
        public int WrongAnswers { get; set; }
        public int CorrectAnswers { get; set; }
        public DateTime? LastAnswers { get; set; }

    
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Word, WordDetialVm>()
                .ForMember(d => d.WrongAnswers, map => map.MapFrom(src => src.AnsweringStatistics.WrongAnswers))
                .ForMember(d => d.CorrectAnswers, map => map.MapFrom(src => src.AnsweringStatistics.CorrectAnswers))
                .ForMember(d => d.LastAnswers, map => map.MapFrom(src => src.AnsweringStatistics.LastAnswer));
        }

    }
}
