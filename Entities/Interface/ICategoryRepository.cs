using Entities.Poco;

namespace Entities.Interface
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        Task<Category> ReadCategory(int id);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);

        Task<IEnumerable<Category>> ReadAllCategories();
    }
}
