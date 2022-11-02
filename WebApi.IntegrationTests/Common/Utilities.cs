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
                StatusId = 1,
                CreatedBy = "Admin",
                EnglishText = "Mouse",
                PolishText = "Mysz",
                AnsweringStatistics = new EnglishTeacher.Domain.ValueObjects.AnsweringStatistics
                {
                    CorrectAnswers = 0,
                    WrongAnswers = 0,
                    LastAnswer = DateTime.Now
                },
            };
            var sentence = new Sentence
            {
                StatusId = 1,
                CreatedBy = "Admin",
                Text = "Mosue is very small animal",
                Word = word,
                WordId = 2
            };

            context.Words.Add(word);
            context.Sentences.Add(sentence);
            context.SaveChanges();
        }
    }
}
