using EnglishTeacher.Domain.Common;
using EnglishTeacher.Domain.ValueObjects;

namespace EnglishTeacher.Domain.Entities
{
    public class Word : AuditableEntity
    {
        public string PolishText { get; set; }
        public string EnglishText { get; set; }
        public AnsweringStatistics AnsweringStatistics { get; set; }
    }
}