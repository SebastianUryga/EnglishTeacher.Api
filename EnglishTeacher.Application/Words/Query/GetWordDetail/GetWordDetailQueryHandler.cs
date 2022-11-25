using AutoMapper;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnglishTeacher.Application.Words.Query.GetWordDetail
{
    public class GetWordDetailQueryHandler : IRequestHandler<GetWordDetailQuery, WordDetailVm>
    {
        private readonly IWordDbContext _context;
        private IMapper _mapper;

        public GetWordDetailQueryHandler(IWordDbContext wordDbContext, IMapper mapper)
        {
            _context = wordDbContext;
            _mapper = mapper;
        }
        public async Task<WordDetailVm> Handle(GetWordDetailQuery request, CancellationToken cancellationToken)
        {
            var word = await _context.Words
                .Where(p => p.Id == request.WordId && p.Status == Status.Active)
                .FirstOrDefaultAsync(cancellationToken);

            var wordVm = _mapper.Map<WordDetailVm>(word);

            return wordVm;
        }
    }
}
