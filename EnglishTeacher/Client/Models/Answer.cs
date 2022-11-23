using System.ComponentModel.DataAnnotations;

namespace EnglishTeacher.Client.Models
{
    public class AnswerForm
    {
        [Required]
        public int WordId { get; set; }
        public string Answer { get; set; }
    }
}
