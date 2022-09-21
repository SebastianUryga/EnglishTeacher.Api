using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTeacher.Application.Words.Query.GetWords
{
    public class WordsVm
    {
        ICollection<WordDto> Words { get; set; }
    }
}
