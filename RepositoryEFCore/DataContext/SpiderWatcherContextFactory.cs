using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RepositoryEFCore.DataContext
{
    public class SpiderWatcherContextFactory :
        IDesignTimeDbContextFactory<SpiderWatcherContext>
    {
        public SpiderWatcherContext CreateDbContext(string[] args)
        {
            var optionsBuilder = 
                new DbContextOptionsBuilder<SpiderWatcherContext>();
            optionsBuilder.UseSqlServer(
                "Server=localhost;Initial Catalog=SpiderWatcher;User ID=SpiderUser;Password=12345678;TrustServerCertificate=true");
            return new SpiderWatcherContext(optionsBuilder.Options);
        }
    }
}
