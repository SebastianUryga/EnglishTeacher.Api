using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Policies;
using Moq;
using System;
using System.Collections.Generic;

namespace Application.UnitTests.Policy
{
    public class PolicyTestFixture
    {
        public PolicyTestFixture()
        {
            Policies = new List<IWordProbabilityValuePolicy>()
            {
                new ProportionOfCorrectAnswersPolicy(),
                new TimePassedSinceLastAnswerPolicy(),
                new UnpracticedWordsPolicy()
            };
            var dateTime = new DateTime(2022, 2, 2);
            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now).Returns(dateTime);
            DateTime = dateTimeMock.Object;
        }
        public IEnumerable<IWordProbabilityValuePolicy> Policies { get; private set; }
        public IDateTime DateTime;
    }
}
