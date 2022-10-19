using AutoMapper;
using EnglishTeacher.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnglishTeacher.Application.Words.Query.GetWordDetail
{
    public class GetWordDetailQueryHandler : IRequestHandler<GetWordDetailQuery, WordDetialVm>
    {
        private readonly IWordDbContext _context;
        private IMapper _mapper;

        public GetWordDetailQueryHandler(IWordDbContext wordDbContext, IMapper mapper)
        {
            _context = wordDbContext;
            _mapper = mapper;
        }
        public async Task<WordDetialVm> Handle(GetWordDetailQuery request, CancellationToken cancellationToken)
        {
            var word = await _context.Words.Where(p => p.Id == request.WordId && p.StatusId == 1).FirstOrDefaultAsync(cancellationToken);

            var wordVm = _mapper.Map<WordDetialVm>(word);

            return wordVm;
        }
    }
}
