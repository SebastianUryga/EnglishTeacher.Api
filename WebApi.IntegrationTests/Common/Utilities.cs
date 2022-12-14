using EnglishTeacher.Domain.Common;
using EnglishTeacher.Domain.Entities;
using EnglishTeacher.Persistance;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.IntegrationTests.Common
{
    public class Utilities
    {
        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringRespose = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringRespose);

            return result;
        }

        public static void InitializeDbForTests(WordDbContext context)
        {
            var word = new Word()
            {
                Id = 93,
                Status = Status.Active,
                CreatedBy = "Admin",
                EnglishText = "Mouse",
                PolishText = "Mysz",
                AnsweringStatistics = new EnglishTeacher.Domain.ValueObjects.AnsweringStatistics
                {
                    CorrectAnswers = 15,
                    WrongAnswers = 1,
                    LastAnswer = DateTime.Now
                },
            };
            context.Words.Add(word);

            var sentence = new Sentence
            {
                Status = Status.Active,
                CreatedBy = "Admin",
                Text = "Mouse is very small animal",
                //Word = word,
                WordId = 93
            };

            context.Sentences.Add(sentence);
            context.SaveChanges();
        }
    }
}
