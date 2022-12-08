using EnglishTeacher.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishTeacher.Persistance.Configurations
{
    public class AnswerConfiguration
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
