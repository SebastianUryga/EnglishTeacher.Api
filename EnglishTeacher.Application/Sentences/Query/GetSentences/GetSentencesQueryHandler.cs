using AutoMapper;
using EnglishTeacher.Application.Common.Interfaces;
using MediatR;

namespace EnglishTeacher.Application.Sentences.Query.GetSentences;

public class GetSentencesQueryHandler : IRequestHandler<GetSentencesQuery,SentencesVm>
{
    private readonly IWordDbContext _context;
    private IMapper _mapper;
    public async Task<SentencesVm> Handle(GetSentencesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}