namespace EnglishTeacher.Application.Common.Exceptions;

public class SentenceNotFoundException : Exception
{
    public SentenceNotFoundException(int id, Exception ex) : base($"Sentence with id: '{id} is not exist.",ex)
    {

    }
}