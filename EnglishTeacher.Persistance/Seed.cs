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
            });

            builder.Entity<Sentence>(data =>
            {
                data.HasData(
                    new Sentence() { Id = 1, StatusId = 1, Created = DateTime.Now, CreatedBy = "Admin", WordId = 1, Text = "text" },
                    new Sentence() { Id = 2, StatusId = 1, Created = DateTime.Now, CreatedBy = "Adnim", WordId = 1, Text = "text 2" }
                );
            });
        }
    }
}
