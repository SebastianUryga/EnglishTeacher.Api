
using EnglishTeacher.Domain.Entities;

namespace EnglishTeacher.Domain.Policies
{
    public class ProportionOfCorrectAnswersPolicy : IWordProbabilityValuePolicy
    {
        private const double _factory = 0.1;
        public bool IsApplicable(PolicyData data)
        {
            var stat = data.Word.AnsweringStatistics;

            return stat.CorrectAnswers + stat.WrongAnswers > 4;
        }

        public double CalculateProbabilityValue(PolicyData data)
        {
            var stat = data.Word.AnsweringStatistics;
           
            var percentageOfWrongAnswers = 100 * stat.WrongAnswers / (stat.WrongAnswers + stat.CorrectAnswers);

            return percentageOfWrongAnswers * _factory;
        }

    }
}
