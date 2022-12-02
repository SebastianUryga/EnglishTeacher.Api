using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Common;
using System;
using System.Collections.Generic;

namespace Application.UnitTests.Policy
{
    public class TestWordsFactory
    {
        public static List<EnglishTeacher.Domain.Entities.Word> Create(IDateTime dateTime)
        {
            var words = new List<EnglishTeacher.Domain.Entities.Word>()
            {
                new EnglishTeacher.Domain.Entities.Word
                {
                    EnglishText = "First",
                    PolishText = "Pierwszy",
                    AnsweringStatistics = new()
                    {
                        CorrectAnswers = 4,
                        WrongAnswers = 0,
                        LastAnswer = dateTime.Now.AddDays(-4)
                    }
                },
                new EnglishTeacher.Domain.Entities.Word
                {
                    EnglishText = "Second",
                    PolishText = "Drugi",
                    AnsweringStatistics = new()
                    {
                        CorrectAnswers = 20,
                        WrongAnswers = 3,
                        LastAnswer = dateTime.Now.AddDays(-5)
                    }
                },
                new EnglishTeacher.Domain.Entities.Word
                {
                    EnglishText = "Third",
                    PolishText = "Trzeci",
                    AnsweringStatistics = new()
                    {
                        CorrectAnswers = 7,
                        WrongAnswers = 3,
                        LastAnswer = dateTime.Now.AddDays(-3)
                    }
                }
            };
            return words;
        }
    }
}
