using EnglishTeacher.Domain.Entities;

namespace EnglishTeacher.Domain.Policies
{
    public class TimePassedSinceLastAnswerPolicy : IRandomProbabilityValuePolicy
    {
        private const double _factor = 0.01;
        public bool IsApplicable(PolicyData data)
            => true;

        public KeyValuePair<Word, double> SetProbabilityValue(PolicyData data)
        {
            var pair = data.WordValuePair;
            var lastAnswerDate = pair.Key.AnsweringStatistics.LastAnswer;

            var passedTime = data.Now - lastAnswerDate;
            var result = new KeyValuePair<Word,double>(pair.Key, pair.Value + Math.Sqrt(passedTime.TotalSeconds) * _factor);
            
            return result;
        }

    }
}
