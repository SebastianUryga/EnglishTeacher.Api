using MediatR;

namespace EnglishTeacher.Application.Sentences.Query.GetSentenceDetail
{
    public  class GetSentenceDetailQuery : IRequest<SentenceDetailVm>
    {
        public int Id { get; set; }
    }
}
