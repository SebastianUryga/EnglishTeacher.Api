
namespace EnglishTeacher.Infrastructure
{
    public interface ITranslatorService
    {
        Task<List<string>> Translate(string text);
    }
}