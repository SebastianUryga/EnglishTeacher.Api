using EnglishTeacher.Domain.Entities;
using EnglishTeacher.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EnglishTeacher.Persistance.Configurations
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(p => p.AnsweringStatistics).Property(p => p.CorrectAnswers)
                .HasColumnName("CorrectAnswers")
                .HasDefaultValue(0)
                .IsRequired();
            builder.OwnsOne(p => p.AnsweringStatistics).Property(p => p.WrongAnswers)
                .HasColumnName("WrongAnswers")
                .HasDefaultValue(0)
                .IsRequired();
            builder.OwnsOne(p => p.AnsweringStatistics).Property(p => p.LastAnswer)
                .HasColumnName("LastAnswer")
                .HasDefaultValue(null);            
        }
    }
}
