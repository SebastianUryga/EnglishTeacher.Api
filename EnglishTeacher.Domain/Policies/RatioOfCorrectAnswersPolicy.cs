
using EnglishTeacher.Domain.Entities;

namespace EnglishTeacher.Domain.Policies
{
    public class RatioOfCorrectAnswersPolicy : IRandomProbabilityValuePolicy
    {
        private const double _factory = 4.5;
        public bool IsApplicable(PolicyData data)
        {
            var stat = data.WordValuePair.Key.AnsweringStatistics;

            return stat.CorrectAnswers + stat.WrongAnswers > 4;
        }

        public KeyValuePair<Word, double> SetProbabilityValue(PolicyData data)
        {
            var stat = data.WordValuePair.Key.AnsweringStatistics;
           
            var ratio = stat.WrongAnswers / stat.CorrectAnswers;

            return new KeyValuePair<Word, double>(data.WordValuePair.Key, data.WordValuePair.Value + ratio * _factory);
        }

    }
}
