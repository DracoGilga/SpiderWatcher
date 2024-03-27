namespace Entities.Interface
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
    }
}
