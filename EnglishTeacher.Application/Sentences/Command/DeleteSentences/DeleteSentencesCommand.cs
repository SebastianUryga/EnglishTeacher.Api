using MediatR;

namespace EnglishTeacher.Application.Sentences.Command.DeleteSentences
{
    public class DeleteSentencesCommand : IRequest
    {
        public int Id { get; set; }
    }
}
