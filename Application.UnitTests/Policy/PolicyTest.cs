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
using EnglishTeacher.Domain.ValueObjects;

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

        [Theory]
        [MemberData(nameof(WordsAnswerStatistics))]
        public void ComperingProbalityValues_ForTwoValidWords_FirstOneShuldBeGrather(int corrAns1, int wrongAns1, int time1, int corrAns2, int wrongAns2, int time2)
        {
            var word1 = _testWords.ElementAt(0);
            var word2 = _testWords.ElementAt(1);
            word1.AnsweringStatistics.CorrectAnswers = corrAns1;
            word1.AnsweringStatistics.WrongAnswers = wrongAns1;
            word1.AnsweringStatistics.LastAnswer = _dateTime.Now.AddDays(-time1);

            word2.AnsweringStatistics.CorrectAnswers = corrAns2;
            word2.AnsweringStatistics.WrongAnswers = wrongAns2;
            word2.AnsweringStatistics.LastAnswer = _dateTime.Now.AddDays(-time2);

            var sum1 = GetSumOfProbalityValueForWord(word1);
            var sum2 = GetSumOfProbalityValueForWord(word2);
            sum1.ShouldBeGreaterThan(sum2);

        }

        public static IEnumerable<object[]> WordsAnswerStatistics =>
        new List<object[]>
        {
            new object[]{20,4,2, 20,3,2},
            new object[]{20,4,2, 25,4,2},
            new object[]{20,4,2, 20,5,1},
            new object[]{2,0,1, 2,5,7},
        };

        private double GetSumOfProbalityValueForWord(EnglishTeacher.Domain.Entities.Word word)
        {
            var policyData = new PolicyData(word, _dateTime.Now);
            var applicablePolicies = _policies.Where(p => p.IsApplicable(policyData));
            var valueSum = applicablePolicies.Sum(p => p.CalculateProbabilityValue(policyData));
            return valueSum;
        }
    }
}
