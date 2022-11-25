using AutoMapper;
using AutoMapper.QueryableExtensions;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Application.Words.Query.GetWords;
using EnglishTeacher.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EnglishTeacher.Application.Sentences.Query.GetSentences;

public class GetSentencesQueryHandler : IRequestHandler<GetSentencesQuery,SentencesVm>
{
    private readonly IWordDbContext _context;
    private IMapper _mapper;

    public GetSentencesQueryHandler(IWordDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<SentencesVm> Handle(GetSentencesQuery request, CancellationToken cancellationToken)
    {
        var sentences = _context.Sentences
            .Where(x => x.Status == Status.Active);
        var sentenceDtos = await sentences
            .ProjectTo<SentenceDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var sentencesVm = _mapper.Map<SentencesVm>(sentenceDtos);
        return sentencesVm;
    }
}