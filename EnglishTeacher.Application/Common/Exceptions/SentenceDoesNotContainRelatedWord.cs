namespace EnglishTeacher.Application.Common.Exceptions
{
    public class SentenceDoesNotContainRelatedWord : Exception
    {
        public SentenceDoesNotContainRelatedWord(string word) : base($"Sentence should contain word '{word}'.")
        {
            
        }
    }
}
