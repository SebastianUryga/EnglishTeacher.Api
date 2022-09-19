using EnglishTeacher.Common.Interfaces;
using EnglishTeacher.Domain.Common;
using EnglishTeacher.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EnglishTeacher.Persistance
{
    public class WordDbContext : DbContext
    {
        private readonly IDateTime _dateTime;

        public WordDbContext(DbContextOptions<WordDbContext> options, IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }
        public DbSet<Word> Words { get; set; }
        public DbSet<Sentence> Sentenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = _dateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.StatusId = 0;
                        entry.Entity.Modified = _dateTime.Now;
                        entry.Entity.Inactivated = _dateTime.Now;
                        entry.State = EntityState.Modified;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }

 
}