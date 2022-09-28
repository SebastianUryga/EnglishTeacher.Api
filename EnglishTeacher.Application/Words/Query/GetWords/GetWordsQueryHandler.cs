using AutoMapper;
using AutoMapper.QueryableExtensions;
using EnglishTeacher.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EnglishTeacher.Application.Words.Query.GetWords
{
    public class GetWordsQueryHandler : IRequestHandler<GetWordsQuery, WordsVm>
    {
        private readonly IWordDbContext _context;
        private readonly IMapper _mapper;

        public GetWordsQueryHandler(IWordDbContext wordDbContext, IMapper mapper)
        {
            _context = wordDbContext;
            _mapper = mapper;
        }

        public async Task<WordsVm> Handle(GetWordsQuery request, CancellationToken cancellationToken)
        {
            var words = (await _context.Words.Where(x => x.StatusId == 1).AsNoTracking().ProjectTo<WordDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken));
            var wordsVm = _mapper.Map<WordsVm>(words);
            return wordsVm;
        }
    }
}
