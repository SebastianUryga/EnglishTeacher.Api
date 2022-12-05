using EnglishTeacher.Domain.Entities;

namespace EnglishTeacher.Domain.Policies
{
    public class TimePassedSinceLastAnswerPolicy : IWordProbabilityValuePolicy
    {
        private const double _factor = 0.02;
        public bool IsApplicable(PolicyData data)
        {
            var lastAnswerDate = data.Word.AnsweringStatistics.LastAnswer;

            return data.Now > lastAnswerDate ;
        }

        public double CalculateProbabilityValue(PolicyData data)
        {
            var lastAnswerDate = data.Word.AnsweringStatistics.LastAnswer;

            var passedTime = data.Now - lastAnswerDate;
            
            return Math.Sqrt(passedTime.TotalSeconds) * _factor;
        }

    }
}
