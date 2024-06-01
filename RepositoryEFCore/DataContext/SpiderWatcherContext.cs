using Entities.Poco;
using Microsoft.EntityFrameworkCore;

namespace RepositoryEFCore.DataContext
{
    public class SpiderWatcherContext : DbContext
    {
        public SpiderWatcherContext(DbContextOptions
            <SpiderWatcherContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryContent> CategoryContents { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<HistoryPlayback> HistoryPlaybacks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Validation> Validations { get; set; }
    }
}
