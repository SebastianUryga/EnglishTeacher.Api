using EnglishTeacher.Domain.Common;

namespace EnglishTeacher.Domain.Entities
{
    public class Answer 
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public string AnswerText { get; set; }
        public DateTime AnswerDate { get; set; }
    }
}
