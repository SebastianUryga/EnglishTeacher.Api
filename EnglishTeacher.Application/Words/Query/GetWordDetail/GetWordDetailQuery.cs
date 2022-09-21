using MediatR;

namespace EnglishTeacher.Application.Words.Query.GetWordDetail
{
    public class GetWordDetailQuery : IRequest<WordDetialVm>
    {
        public int WordId { get; set; }
    }
}
