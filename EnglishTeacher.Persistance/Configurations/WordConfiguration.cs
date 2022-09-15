using EnglishTeacher.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EnglishTeacher.Persistance.Configurations
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.Property(p => p.CorrectAnswers).HasDefaultValue(0);
            builder.Property(p => p.LastAnswer).HasDefaultValue(null);
        }
    }
}
