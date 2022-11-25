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
        private IWordDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IRandomProbabilityValuePolicy> _policies;
        private readonly IDateTime _dateTime;

        public GetPackOfWordsToAnswerQueryHandler(IWordDbContext context, IMapper mapper, IEnumerable<IRandomProbabilityValuePolicy> policies, IDateTime dateTime)
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

            var wordValueDictionary = new Dictionary<Word, double>();

            foreach (var word in allWords)
            {
                var sumValuePair = new KeyValuePair<Word, double>(word, 0.0);
                foreach (var policy in _policies)
                {
                    var policyData = new PolicyData(sumValuePair, _dateTime.Now);
                    if (policy.IsApplicable(policyData))
                        sumValuePair = policy.SetProbabilityValue(policyData);
                }
                wordValueDictionary.Add(sumValuePair.Key, sumValuePair.Value);
            }

            var chosenWords = wordValueDictionary
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .Take(request.MaxQuantity)
                .ToList();

            return _mapper.Map<WordsVm>(chosenWords);
        }
    }
}

