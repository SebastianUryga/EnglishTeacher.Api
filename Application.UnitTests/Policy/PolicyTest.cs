using AutoMapper.Internal;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Policies;
using EnglishTeacher.Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;

namespace Application.UnitTests.Policy
{
    public class PolicyTest : IClassFixture<PolicyTestFixture>
    {
        private IEnumerable<IWordProbabilityValuePolicy> _policies;
        private IDateTime _dateTime;

        private readonly ICollection<EnglishTeacher.Domain.Entities.Word> _testWords;

        public PolicyTest(PolicyTestFixture policyTestFixture)
        {
            _policies = policyTestFixture.Policies;
            _dateTime = policyTestFixture.DateTime;
            _testWords = TestWordsFactory.Create(_dateTime);
        }

        [Fact]
        public void PoliciesMethods_ValidData_DoesNotThrowErrors()
        {
            var data = new PolicyData(_testWords.First(), _dateTime.Now);

            var actions = _policies.SelectMany(x => new[]
            {
                new Action(() => x.IsApplicable(data)),
                new Action(() => x.CalculateProbabilityValue(data))
            });

            actions.ForAll(x => x.ShouldNotThrow());
        }

        private double GetSumOfProbalityValueForWord(EnglishTeacher.Domain.Entities.Word word)
        {
            var policyData = new PolicyData(word, _dateTime.Now);
            var applicablePolicies = _policies.Where(p => p.IsApplicable(policyData));
            var valueSum = applicablePolicies.Sum(p => p.CalculateProbabilityValue(policyData));
            return valueSum;
        }
    }
}
