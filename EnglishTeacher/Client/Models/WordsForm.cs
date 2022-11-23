using System.ComponentModel.DataAnnotations;

namespace EnglishTeacher.Client.Models
{
    public class WordsForm
    {
        [Required]
        public string PolishText { get; set; }
        [Required]
        public string EnglishText { get; set; }
    }
}
