using AutoMapper;
using EnglishTeacher.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EnglishTeacher.Application.Sentences.Query.GetSentenceDetail
{
    public class GetSentenceDetailQueryHandler : IRequestHandler<GetSentenceDetailQuery,SentenceDetailVm>
    {
        private readonly IWordDbContext _context;
        private IMapper _mapper;

        public GetSentenceDetailQueryHandler(IMapper mapper,IWordDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<SentenceDetailVm> Handle(GetSentenceDetailQuery request, CancellationToken cancellationToken)
        {
            var sentence = await _context.Sentences.Where(x => x.StatusId == 1 && x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<SentenceDetailVm>(sentence);
        }
    }
}
