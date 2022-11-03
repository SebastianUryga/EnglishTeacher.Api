using MediatR;

namespace EnglishTeacher.Application.Words.Query.GetWordDetail
{
    public class GetWordDetailQuery : IRequest<WordDetailVm>
    {
        public int WordId { get; set; }
    }
}
