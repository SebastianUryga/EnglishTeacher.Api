using AutoMapper;
using AutoMapper.QueryableExtensions;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Application.Words.Query.GetWords;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EnglishTeacher.Application.Sentences.Query.GetSentences;

public class GetSentencesQueryHandler : IRequestHandler<GetSentencesQuery,SentencesVm>
{
    private readonly IWordDbContext _context;
    private IMapper _mapper;
    public async Task<SentencesVm> Handle(GetSentencesQuery request, CancellationToken cancellationToken)
    {
        var sentences = (await _context.Sentences.Where(x => x.StatusId == 1).AsNoTracking().ProjectTo<SentenceDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken));
        var sentencesVm = _mapper.Map<SentencesVm>(sentences);
        return sentencesVm;
    }
}