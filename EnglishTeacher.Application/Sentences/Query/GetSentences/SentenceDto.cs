using EnglishTeacher.Application.Common.Mappings;
using EnglishTeacher.Domain.Entities;

namespace EnglishTeacher.Application.Sentences.Query.GetSentences;

public class SentenceDto :IMapForm<Sentence>
{
    public string Text { get; set; }
    public string Word { get; set; }
}