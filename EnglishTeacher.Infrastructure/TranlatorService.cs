/*using DeepL;
using DeepL.Model;

namespace EnglishTeacher.Infrastructure
{
    public class TranlatorService : ITranslatorService
    {
        public async Task<List<string>> Translate(string text)
        {
           
            var translator = new Translator("key");
            var cc = new TextResult("key",LanguageCode.English);
            // Translate text into a target language, in this case, French:
            var translatedText = await translator.TranslateTextAsync(
                  text,
                  LanguageCode.Polish,
                  LanguageCode.English);
            Console.WriteLine(translatedText);
            Console.WriteLine(translatedText.DetectedSourceLanguageCode);
            Console.WriteLine(translatedText.Text);
            Console.WriteLine(translatedText.ToString());

            return new List<string>() { translatedText.Text,translatedText.DetectedSourceLanguageCode,translatedText.ToString()};
        }
    }

}*/