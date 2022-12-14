using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Entities;
using EnglishTeacher.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using EnglishTeacher.Domain.Common;
using System.Collections.Generic;

namespace Application.UnitTests.Common
{
    public class WordDbContextFactory
    {
        public static Mock<WordDbContext> Create()
        {
            var dateTime = new DateTime(2022, 2, 2);
            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now).Returns(dateTime);

            var currentUserMock = new Mock<ICurrentUserService>();
            currentUserMock.Setup(m => m.Email).Returns("user@user.com");
            currentUserMock.Setup(m => m.IsAuthenticated).Returns(true);

            var options = new DbContextOptionsBuilder<WordDbContext>()
                .UseInMemoryDatabase(new Guid().ToString()).Options;
          
            var mock = new Mock<WordDbContext>(options, dateTimeMock.Object, currentUserMock.Object) { CallBase = true };
            
            var context = mock.Object;
            
            context.Database.EnsureCreated();

            var word1 = new EnglishTeacher.Domain.Entities.Word()
            {
                Status = Status.Active,
                CreatedBy = "Admin",
                EnglishText = "Mouse",
                PolishText = "Mysz",
                AnsweringStatistics = new EnglishTeacher.Domain.ValueObjects.AnsweringStatistics
                {
                    CorrectAnswers = 5,
                    WrongAnswers = 1,
                    LastAnswer = dateTime.AddDays(-1)
                }, 
            };

            var word2 = new EnglishTeacher.Domain.Entities.Word()
            {
                Status = Status.Active,
                CreatedBy = "Admin",
                EnglishText = "Delete",
                PolishText = "Usuń",
                AnsweringStatistics = new EnglishTeacher.Domain.ValueObjects.AnsweringStatistics
                {
                    CorrectAnswers = 6,
                    WrongAnswers = 3,
                    LastAnswer = dateTime.AddDays(-2)
                },
            };

            var words = new List<EnglishTeacher.Domain.Entities.Word>()
            {
                new EnglishTeacher.Domain.Entities.Word
                {
                    Status = Status.Active,
                    CreatedBy = "Admin",
                    EnglishText = "First",
                    PolishText = "Pierwszy",
                    AnsweringStatistics = new()
                    {
                        CorrectAnswers = 4,
                        WrongAnswers = 0,
                        LastAnswer = dateTime.AddDays(-4)
                    }
                },
                new EnglishTeacher.Domain.Entities.Word
                {
                    Status = Status.Active,
                    CreatedBy = "Admin",
                    EnglishText = "Second",
                    PolishText = "Drugi",
                    AnsweringStatistics = new()
                    {
                        CorrectAnswers = 20,
                        WrongAnswers = 3,
                        LastAnswer = dateTime.AddDays(-5)
                    }
                },
                new EnglishTeacher.Domain.Entities.Word
                {
                    Status = Status.Active,
                    CreatedBy = "Admin",
                    EnglishText = "Third",
                    PolishText = "Trzeci",
                    AnsweringStatistics = new()
                    {
                        CorrectAnswers = 7,
                        WrongAnswers = 3,
                        LastAnswer = dateTime.AddDays(-3)
                    }
                }
            };
            context.Words.AddRange(words);
            context.Words.Add(word2);
            context.Words.Add(word1);

            var sentence = new Sentence
            {
                Id = 4,
                Status = Status.Active,
                CreatedBy = "Admin",
                Text = "Mouse is very small animal",
                Word = word1,
                WordId = word1.Id
            };

            context.Sentences.Add(sentence);
            context.SaveChanges();

            return mock;
        }

        public static void Destroy(WordDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
