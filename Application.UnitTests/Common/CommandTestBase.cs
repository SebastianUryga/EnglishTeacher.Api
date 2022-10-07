using EnglishTeacher.Persistance;
using Moq;
using System;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly WordDbContext _context;
        protected readonly Mock<WordDbContext> _contextMock;

        public CommandTestBase()
        {
            _contextMock = WordDbContextFactory.Create();
            _context = _contextMock.Object;
        }

        public void Dispose()
        {
            WordDbContextFactory.Distroy(_context);
        }
    }
}
