
using EnglishTeacher.Domain.Entities;

namespace EnglishTeacher.Domain.Policies
{
    public class RatioOfCorrectAnswersPolicy : IRandomProbabilityValuePolicy
    {
        private const double _factory = 0.1;
        public bool IsApplicable(PolicyData data)
        {
            var stat = data.WordValuePair.Key.AnsweringStatistics;

            return stat.CorrectAnswers + stat.WrongAnswers > 4;
        }

        public KeyValuePair<Word, double> SetProbabilityValue(PolicyData data)
        {
            var stat = data.WordValuePair.Key.AnsweringStatistics;
           
            var percentageOfWrongAnswers = 100 * stat.WrongAnswers / (stat.WrongAnswers + stat.CorrectAnswers);

            return new KeyValuePair<Word, double>(data.WordValuePair.Key, data.WordValuePair.Value + percentageOfWrongAnswers * _factory);
        }

    }
}
