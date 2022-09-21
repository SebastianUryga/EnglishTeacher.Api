using MediatR;

namespace EnglishTeacher.Application.Words.Command.DeleteWord
{
    public class DeleteWordCommand : IRequest
    {
        public int WordId { get; set; }
    }
}
