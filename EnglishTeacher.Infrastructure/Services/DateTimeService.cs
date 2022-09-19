using EnglishTeacher.Common.Interfaces;

namespace EnglishTeacher.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
