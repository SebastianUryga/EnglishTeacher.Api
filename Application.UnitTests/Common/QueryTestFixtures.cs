using AutoMapper;
using EnglishTeacher.Application.Common.Mappings;
using EnglishTeacher.Persistance;
using System;
using System.Collections;
using System.Collections.Generic;
using EnglishTeacher.Domain.Policies;
using Xunit;

namespace Application.UnitTests.Common
{
    public class QueryTestFixtures : IDisposable
    {
        public WordDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }
        public IEnumerable<IWordProbabilityValuePolicy> Policies { get; private set; }

        public QueryTestFixtures()
        {
            Context = WordDbContextFactory.Create().Object;

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();

            Policies = new List<IWordProbabilityValuePolicy>()
            {
                new ProportionOfCorrectAnswersPolicy(),
                new TimePassedSinceLastAnswerPolicy(),
                new UnpracticedWordsPolicy()
            };
        }

        public void Dispose()
        {
            WordDbContextFactory.Destroy(Context);
        }

        [CollectionDefinition("QueryCollection")]
        public class QueryCollection : ICollectionFixture<QueryTestFixtures> { }
    }
}
