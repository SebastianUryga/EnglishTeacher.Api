using EnglishTeacher.Application.Words.Query.GetWords;
using MediatR;

namespace EnglishTeacher.Application.Words.Query.GetPackOfRandomWords
{
    public class GetPackOfWordsToAnswerQuery : IRequest<WordsVm>
    {
        public int MaxQuantity { get; set; }
    }
}
