using MediatR;

namespace EnglishTeacher.Application.Words.Command.CreateWord
{
    public class CreateWordCommand : IRequest<int>
    {
        public string PolishText { get; set; }
        public string EnglishText { get; set; }
    }
}
