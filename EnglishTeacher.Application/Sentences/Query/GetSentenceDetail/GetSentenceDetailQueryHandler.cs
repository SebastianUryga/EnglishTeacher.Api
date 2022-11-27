using AutoMapper;
using EnglishTeacher.Application.Common.Exceptions;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Common;
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
            var sentence = await _context.Sentences
                .Where(x => x.Status == Status.Active && x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if(sentence == null)
            {
                throw new SentenceNotFoundException(request.Id, new Exception());
            } 
            
            return _mapper.Map<SentenceDetailVm>(sentence);
        }
    }
}
