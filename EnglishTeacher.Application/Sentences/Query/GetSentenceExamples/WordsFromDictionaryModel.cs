using Newtonsoft.Json;

namespace EnglishTeacher.Application.Sentences.Query.GetSentenceExamples
{
    public class WordsFromDictionaryModel
    {
        public ICollection<WordFromDictionaryModel> Words { get; set; }
    }

    public class WordFromDictionaryModel
    {
        [JsonProperty("word")]
        public string Word { get; set; }

        [JsonProperty("phonetic")]
        public string Phonetic { get; set; }

        [JsonProperty("phonetics")]
        public ICollection<Phonetic> Phonetics { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("meanings")]
        public ICollection<Meaning> Meanings { get; set; }

    }

    public class Phonetic
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("audio")]
        public string Audio { get; set; }
    }

    public class Meaning
    {
        [JsonProperty("partOfSpeech")]
        public string PartOfSpeech { get; set; }

        [JsonProperty("definitions")]
        public ICollection<Def> Definitions { get; set; }
    }

    public class Def
    {
        [JsonProperty("definition")]
        public string Definition { get; set; }

        [JsonProperty("example")]
        public string Example { get; set; }
        [JsonProperty("synonyms")]
        public ICollection<string> Synonyms { get; set; }
        [JsonProperty("antonyms")]
        public ICollection<string> Antonyms { get; set; }
    }
}
