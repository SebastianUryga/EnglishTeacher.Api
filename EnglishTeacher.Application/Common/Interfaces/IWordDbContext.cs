using EnglishTeacher.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EnglishTeacher.Application.Common.Interfaces
{
    public interface IWordDbContext
    {
        DbSet<Word> Words { get; set; }
        DbSet<Sentence> Sentences { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
