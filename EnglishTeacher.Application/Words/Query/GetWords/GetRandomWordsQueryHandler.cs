using AutoMapper;
using AutoMapper.QueryableExtensions;
using EnglishTeacher.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EnglishTeacher.Application.Words.Query.GetWords
{
    public class GetRandomWordsQueryHandler : IRequestHandler<GetRandomWordsQuery, WordsVm>
    {
        private readonly IWordDbContext _context;
        private readonly IMapper _mapper;
        public GetRandomWordsQueryHandler(IWordDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<WordsVm> Handle(GetRandomWordsQuery request, CancellationToken cancellationToken)
        {
            var words = (await _context.Words.Where(x => x.StatusId == 1).AsNoTracking().ProjectTo<WordDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken));
            var rnd = new Random();
            var randomWords = words.OrderBy(x => rnd.Next()).Take(request.MaxQuantity).ToList();
            return _mapper.Map<WordsVm>(randomWords);
        }
    }
}
