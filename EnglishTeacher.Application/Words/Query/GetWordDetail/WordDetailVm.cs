using AutoMapper;
using EnglishTeacher.Application.Common.Mappings;
using EnglishTeacher.Domain.Entities;
using System;

namespace EnglishTeacher.Application.Words.Query.GetWordDetail
{
    public class WordDetailVm : IMapForm<Word>
    {
        public int Id { get; set; }
        public string PolishText { get; set; }
        public string EnglishText { get; set; }
        public int WrongAnswers { get; set; }
        public int CorrectAnswers { get; set; }
        public DateTime? LastAnswers { get; set; }

        public ICollection<AnswerDto> AnswersHistory {get; set;}
    
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Word, WordDetailVm>()
                .ForMember(d => d.WrongAnswers, map => map.MapFrom(src => src.AnsweringStatistics.WrongAnswers))
                .ForMember(d => d.CorrectAnswers, map => map.MapFrom(src => src.AnsweringStatistics.CorrectAnswers))
                .ForMember(d => d.LastAnswers, map => map.MapFrom(src => src.AnsweringStatistics.LastAnswer))
                .ForMember(d => d.AnswersHistory, map => map.MapFrom(src => src.AnswersHistory.OrderByDescending(x => x.AnswerDate)));
        }

    }

    public class AnswersVm
    {
        public List<AnswerDto> Answers { get; set; }
    }

    public class AnswerDto : IMapForm<Answer>
    {
        public string AnswerText { get; set; }

        public DateTime AnswerDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Answer, AnswerDto>()
                .ForMember(d => d.AnswerText, map => map.MapFrom(src => src.AnswerText))
                .ForMember(d => d.AnswerDate, map => map.MapFrom(src => src.AnswerDate));
        }
    }
}
