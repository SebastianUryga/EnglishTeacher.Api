using EnglishTeacher.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishTeacher.Persistance.Configurations
{
    public class SentenceConfiguration : IEntityTypeConfiguration<Sentence>
    {
        public void Configure(EntityTypeBuilder<Sentence> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Text).IsRequired();
        }
    }
}
