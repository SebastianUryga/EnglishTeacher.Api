using AutoMapper;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Application.Words.Query.GetWords;
using EnglishTeacher.Domain.Common;
using EnglishTeacher.Domain.Entities;
using EnglishTeacher.Domain.Policies;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EnglishTeacher.Application.Words.Query.GetPackOfRandomWords
{
    public class GetPackOfWordsToAnswerQueryHandler : IRequestHandler<GetPackOfWordsToAnswerQuery, WordsVm>
    {
        private readonly IWordDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IWordProbabilityValuePolicy> _policies;
        private readonly IDateTime _dateTime;

        public GetPackOfWordsToAnswerQueryHandler(IWordDbContext context, IMapper mapper, IEnumerable<IWordProbabilityValuePolicy> policies, IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _policies = policies;
            _dateTime = dateTime;
        }

        public async Task<WordsVm> Handle(GetPackOfWordsToAnswerQuery request, CancellationToken cancellationToken)
        {
            var allWords = await _context.Words
                .Where(p => p.Status == Status.Active)
                .ToListAsync(cancellationToken);

            var wordValueDictionary = allWords.ToDictionary(word => word, GetSumOfProbabilityValueForWord);

            var hightestValueWords = wordValueDictionary
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .Take(request.MaxQuantity)
                .ToList();

            return _mapper.Map<WordsVm>(hightestValueWords);
        }

        private double GetSumOfProbabilityValueForWord(Word word)
        {
            var policyData = new PolicyData(word, _dateTime.Now);
            var applicablePolicies = _policies.Where(p => p.IsApplicable(policyData));
            var valueSum = applicablePolicies.Sum(p => p.CalculateProbabilityValue(policyData));
            return valueSum;
        }
    }
}

