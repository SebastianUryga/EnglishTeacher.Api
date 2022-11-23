namespace EnglishTeacher.Client.Models
{
    public class WordsDetailVm
    {
        public int Id { get; set; }
        public string PolishText { get; set; }
        public string EnglishText { get; set; }
        public int WrongAnswers { get; set; }
        public int CorrectAnswers { get; set; }
        public DateTime? LastAnswers { get; set; }
    }
}
