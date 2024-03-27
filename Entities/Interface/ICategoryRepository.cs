using Entities.Poco;

namespace Entities.Interface
{
    public interface ICategoryRepository
    {
        void CreateCategory(Category category);
        Category ReadCategory(int id);
        bool UpdateCategory(Category category);
        void DeleteCategory(int id);

        IEnumerable<Category> ReadAllCategories();
    }
}
