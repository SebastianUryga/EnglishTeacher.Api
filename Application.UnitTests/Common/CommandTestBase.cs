using EnglishTeacher.Persistance;
using Moq;
using System;
using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Infrastructure.Services;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly IDateTime _dateTime;
        protected readonly WordDbContext _context;
        protected readonly Mock<WordDbContext> _contextMock;

        public CommandTestBase()
        {
            _contextMock = WordDbContextFactory.Create();
            _context = _contextMock.Object;
            _dateTime = new DateTimeService();
        }

        public void Dispose()
        {
            WordDbContextFactory.Destroy(_context);
        }
    }
}
