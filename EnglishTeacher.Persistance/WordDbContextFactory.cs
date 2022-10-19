using Microsoft.EntityFrameworkCore;

namespace EnglishTeacher.Persistance
{
    public class WordDbContextFactory : DesignTimeDbContextFactoryBase<WordDbContext>
    {
        protected override WordDbContext CreateNewInstance(DbContextOptions<WordDbContext> optionBuilder)
        {
            return new WordDbContext(optionBuilder);
        }
    }
}
