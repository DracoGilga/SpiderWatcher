using Entities.Poco;

namespace Entities.Interface
{
    public interface ICategoryRepository
    {
        void CreateCategory(Category category);
        Category ReadCategory(int id);
        bool UpdateCategory(Category category);
        Category DeleteCategory(int id);

        IEnumerable<Category> ReadAllCategories();
    }
}
