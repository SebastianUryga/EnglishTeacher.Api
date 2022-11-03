using EnglishTeacher.Application.Words.Query.GetWordDetail;
using MediatR;

namespace EnglishTeacher.Application.Words.Command.UpdateWord
{
    public class UpdateWordCommand : IRequest<WordDetailVm>
    {
        public int WordId { get; set; }
        public string PolishText { get; set; }
        public string EnglishText { get; set; }
    }
}
