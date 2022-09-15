using EnglishTeacher.Domain.Common;

namespace EnglishTeacher.Domain.Entities
{
    public class Word : AuditableEntity
    {
        public string PolishText { get; set; }
        public string EnglishText { get; set; }

        public int WrongAnswers { get; set; }
        public int CorrectAnswers { get; set; }
        public DateTime LastAnswer { get; set; }
    }

    

}