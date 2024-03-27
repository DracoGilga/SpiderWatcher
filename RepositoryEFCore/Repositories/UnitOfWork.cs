using Entities.Interface;
using RepositoryEFCore.DataContext;

namespace RepositoryEFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly SpiderWatcherContext Context;
        public UnitOfWork(SpiderWatcherContext context) 
            => Context = context;

        public Task<int> SaveChanges()
        {
            try
            {
                return Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
