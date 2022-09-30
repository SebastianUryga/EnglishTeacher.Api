﻿using AutoMapper;
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
        private readonly ICurrentUserService _userService;

        public GetWordDetailQueryHandler(IWordDbContext wordDbContext, IMapper mapper, ICurrentUserService userService)
        {
            _context = wordDbContext;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<WordDetialVm> Handle(GetWordDetailQuery request, CancellationToken cancellationToken)
        {
            var word = await _context.Words.Where(p => p.Id == request.WordId).FirstOrDefaultAsync(cancellationToken);

            var wordVm = _mapper.Map<WordDetialVm>(word);

            return wordVm;
        }
    }
}
