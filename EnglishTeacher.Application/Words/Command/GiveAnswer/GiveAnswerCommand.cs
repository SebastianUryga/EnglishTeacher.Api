using MediatR;

namespace EnglishTeacher.Application.Words.Command.GiveAnswer
{
    public class GiveAnswerCommand : IRequest<bool>
    {
        public int WordId { get; set; }
        public string Answer { get; set; }
    }
}
