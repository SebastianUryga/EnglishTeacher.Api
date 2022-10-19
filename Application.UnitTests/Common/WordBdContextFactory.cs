using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Entities;
using EnglishTeacher.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace Application.UnitTests.Common
{
    public class WordDbContextFactory
    {
        public static Mock<WordDbContext> Create()
        {
            var dateTime = new DateTime(2022, 2, 2);
            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now).Returns(dateTime);

            var currenUserMock = new Mock<ICurrentUserService>();
            currenUserMock.Setup(m => m.Email).Returns("user@user.com");
            currenUserMock.Setup(m => m.IsAuthenticated).Returns(true);

            var options = new DbContextOptionsBuilder<WordDbContext>()
                .UseInMemoryDatabase(new Guid().ToString()).Options;
          
            var mock = new Mock<WordDbContext>(options, dateTimeMock.Object, currenUserMock.Object) { CallBase = true };
            
            var context = mock.Object;
            
            context.Database.EnsureCreated();

            var word1 = new EnglishTeacher.Domain.Entities.Word()
            {
                StatusId = 1,
                CreatedBy = "Admin",
                EnglishText = "Mouse",
                PolishText = "Mysz",
                AnsweringStatistics = new EnglishTeacher.Domain.ValueObjects.AnsweringStatistics
                {
                    CorrectAnswers = 0,
                    WrongAnswers = 0,
                    LastAnswer = dateTime
                }, 
            };

            var word2 = new EnglishTeacher.Domain.Entities.Word()
            {
                StatusId = 1,
                CreatedBy = "Admin",
                EnglishText = "Delete",
                PolishText = "Usuń",
                AnsweringStatistics = new EnglishTeacher.Domain.ValueObjects.AnsweringStatistics
                {
                    CorrectAnswers = 0,
                    WrongAnswers = 0,
                    LastAnswer = dateTime
                },
            };

            context.Words.Add(word2);
            context.Words.Add(word1);

            var sentence = new Sentence
            {
                StatusId = 1,
                CreatedBy = "Admin",
                Text = "Mosue is very small animal",
                Word = word1,
                WordId = word1.Id
            };

            context.Sentenses.Add(sentence);
            context.SaveChanges();

            return mock;
        }

        public static void Distroy(WordDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
