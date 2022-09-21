using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTeacher.Application.Common.Interfaces
{
    public interface IDictionaryClient
    {
        Task<string> GetExample(string word);
        
    }
}
