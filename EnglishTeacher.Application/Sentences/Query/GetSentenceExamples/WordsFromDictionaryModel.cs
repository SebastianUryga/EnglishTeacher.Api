namespace EnglishTeacher.Application.Sentences.Query.GetSentenceExamples
{
    public class WordsFromDictionaryModel
    {
        public ICollection<WordFromDictionaryModel> Words { get; set; }
    }

    public class WordFromDictionaryModel
    {
        public string Word { get; set; }
        public string Phonetic { get; set; }
        public ICollection<Phonetic> Phonetics { get; set; }
        public string Origin { get; set; }
        public ICollection<Meaning> Meanings { get; set; }

    }

    public class Phonetic
    {
        public string Text { get; set; }
        public string Audio { get; set; }
    }

    public class Meaning
    {
        public string PartOfSpeech { get; set; }
        public ICollection<Def> Definitions { get; set; }
    }

    public class Def
    {
        public string Definition { get; set; }
        public string Example { get; set; }
        public ICollection<string> Synonyms { get; set; }
    }
}
