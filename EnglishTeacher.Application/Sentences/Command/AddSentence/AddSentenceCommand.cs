using MediatR;

namespace EnglishTeacher.Application.Sentences.Command.AddSentence
{
    public class AddSentenceCommand : IRequest<int>
    {
        public string EnglishText { get; set; }
        public string PolishText { get; set; }
        public int WordId { get; set; }
    }
}
