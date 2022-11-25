using System.Data.Common;
using EnglishTeacher.Domain.Entities;

namespace EnglishTeacher.Domain.Policies
{
    public class UnpracticedWordsPolicy : IRandomProbabilityValuePolicy
    {
        private const double _factor = 100.0;

        public bool IsApplicable(PolicyData data)
        {
            var stat = data.WordValuePair.Key.AnsweringStatistics;
            return stat.CorrectAnswers + stat.WrongAnswers < 5;
        }

        public KeyValuePair<Word, double> SetProbabilityValue(PolicyData data)
        {
            var pair = data.WordValuePair;
            return new KeyValuePair<Word, double>(pair.Key,pair.Value + _factor);
        }
    }
}
