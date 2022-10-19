using EnglishTeacher.Domain.Common;

namespace EnglishTeacher.Domain.ValueObjects
{
    public class AnsweringStatistics : ValueObject
    {
        public int WrongAnswers { get; set; }
        public int CorrectAnswers { get; set; }
        public DateTime LastAnswer { get; set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return WrongAnswers;
            yield return CorrectAnswers;
            yield return LastAnswer;
        }
    }
}
