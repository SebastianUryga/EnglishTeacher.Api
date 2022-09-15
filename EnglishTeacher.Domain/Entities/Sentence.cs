using EnglishTeacher.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTeacher.Domain.Entities
{
    public class Sentence : AuditableEntity
    {
        public string Text { get; set; }

        public int WordId { get; set; }
        public Word Word { get; set; }
    }
}
