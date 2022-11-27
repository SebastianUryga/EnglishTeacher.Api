using Microsoft.AspNetCore.Http;

namespace EnglishTeacher.Application.Common.Exceptions
{
    public class WordNotFoundException : ServiceException
    {
        private readonly int _id;
        public WordNotFoundException(int id)
        {
            _id = id;
        }

        public override int HttpStatusCode => StatusCodes.Status404NotFound;
        public override string ErrorMessage => $"Word with '{_id}' does not exist.";
    }
}
