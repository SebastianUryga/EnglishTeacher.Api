namespace EnglishTeacher.Domain.Policies
{
    public class UnpracticedWordsPolicy : IWordProbabilityValuePolicy
    {
        private const double _factor = 100.0;

        public bool IsApplicable(PolicyData data)
        {
            var stat = data.Word.AnsweringStatistics;
            return stat.CorrectAnswers + stat.WrongAnswers < 5;
        }

        public double CalculateProbabilityValue(PolicyData data)
        {
            var stat = data.Word.AnsweringStatistics;
            var sumOfAnswers = stat.CorrectAnswers + stat.WrongAnswers;
            return _factor / (sumOfAnswers + 1);
        }
    }
}
