using EnglishTeacher.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnglishTeacher.Application.Words.Query.GetWordDetail
{
    public class GetWordDetailQueryHandler : IRequestHandler<GetWordDetailQuery, WordDetialVm>
    {
        private readonly IWordDbContext _context;

        public GetWordDetailQueryHandler(IWordDbContext wordDbContext)
        {
            _context = wordDbContext;
        }
        public async Task<WordDetialVm> Handle(GetWordDetailQuery request, CancellationToken cancellationToken)
        {
            var word = await _context.Words.Where(p => p.Id == request.WordId).FirstOrDefaultAsync(cancellationToken);

            var wordVm = new WordDetialVm
            {
                EnglishText = word.EnglishText,
                PolishText = word.PolishText,
            };

            return wordVm;
        }
    }
}
