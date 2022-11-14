using EnglishTeacher.Domain.Common;

namespace EnglishTeacher.Domain.Entities
{
    public class Sentence : AuditableEntity
    {
        public string Text { get; set; }

        public int WordId { get; set; }
        public Word Word { get; set; }
    }
}
