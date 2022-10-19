using EnglishTeacher.Domain.Entities;

namespace EnglishTeacher.Domain.Policies
{
    public record PolicyData (KeyValuePair<Word, double> WordValuePair, DateTime Now);
}