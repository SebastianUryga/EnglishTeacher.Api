using EnglishTeacher.Application.Common.Interfaces;
using EnglishTeacher.Domain.Common;
using EnglishTeacher.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EnglishTeacher.Persistance
{
    public class WordDbContext : DbContext, IWordDbContext
    {
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _userService;
        public WordDbContext(DbContextOptions<WordDbContext> options) : base(options)
        {
        }

        public WordDbContext(DbContextOptions<WordDbContext> options, IDateTime dateTime, ICurrentUserService userService) : base(options)
        {
            _dateTime = dateTime;
            _userService = userService;
        }

        public DbSet<Word> Words { get; set; }
        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<Answer> Answers { get; set; }

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
                    case EntityState.Deleted:
                        entry.Entity.Status = Status.Deleted;
                        entry.Entity.Modified = _dateTime.Now;
                        entry.Entity.ModifiedBy = _userService.Email;
                        entry.Entity.Inactivated = _dateTime.Now;
                        entry.Entity.InactivatedBy = _userService.Email;
                        entry.State = EntityState.Modified;
                        break;
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.Now;
                        entry.Entity.CreatedBy = _userService.Email;
                        entry.Entity.Status = Status.Active;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = _dateTime.Now;
                        entry.Entity.ModifiedBy = _userService.Email;
                        break;
                    
                }
            }

            foreach (var entry in ChangeTracker.Entries<ValueObject>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }

 
}