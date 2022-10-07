using AutoMapper;
using EnglishTeacher.Application.Common.Mappings;
using EnglishTeacher.Persistance;
using System;
using Xunit;

namespace Application.UnitTests.Common
{
    public class QueryTestFixtures : IDisposable
    {
        public WordDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixtures()
        {
            Context = WordDbContextFactory.Create().Object;

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            WordDbContextFactory.Distroy(Context);
        }

        [CollectionDefinition("QueryCollection")]
        public class QueryCollection : ICollectionFixture<QueryTestFixtures> { }
    }
}
