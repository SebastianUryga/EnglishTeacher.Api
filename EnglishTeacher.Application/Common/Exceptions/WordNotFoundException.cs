namespace EnglishTeacher.Application.Common.Exceptions
{
    public class WordNotFoundException : Exception
    {
        public WordNotFoundException(int id, Exception ex) : base($"Word with '{id}' does not exist.", ex)
        {

        }
    }
}
