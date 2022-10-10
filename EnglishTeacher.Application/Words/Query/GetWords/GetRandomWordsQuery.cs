using MediatR;

namespace EnglishTeacher.Application.Words.Query.GetWords
{
    public class GetRandomWordsQuery : IRequest<WordsVm>
    {
        public int MaxQuantity { get; set; }
    }
}
