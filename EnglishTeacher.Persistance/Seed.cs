using EnglishTeacher.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EnglishTeacher.Persistance
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder builder)
        {
            builder.Entity<Word>(data =>
            {
                data.HasData(new Word()
                {
                    Id = 1,
                    StatusId = 1,
                    Created = DateTime.Now,
                    CreatedBy = "Admin",
                    EnglishText = "Do",
                    PolishText = "robić",
                    
                });
                data.OwnsOne(t => t.AnsweringStatistics).HasData(new
                {
                    WordId = 1,
                    CorrectAnswers = 0,
                    WrongAnswers = 0,
                    LastAnswer = DateTime.Now
                }) ;
            });

            builder.Entity<Sentence>(data =>
            {
                data.HasData(
                    new Sentence() { Id = 1, StatusId = 1, Created = DateTime.Now, CreatedBy = "Admin", WordId = 1, Text = "What do you do?" },
                    new Sentence() { Id = 2, StatusId = 1, Created = DateTime.Now, CreatedBy = "Adnim", WordId = 1, Text = "Just do it" }
                );
            });
        }
    }
}
