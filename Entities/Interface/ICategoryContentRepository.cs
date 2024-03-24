using Entities.Poco;

namespace Entities.Interface
{
    public interface ICategoryContentRepository
    {
        Task CreateCategoryContent(CategoryContent categoryContent);
        Task<CategoryContent> ReadCategoryContent(int id);
        Task UpdateCategoryContent(CategoryContent categoryContent);
        Task DeleteCategoryContent(int id);

        Task<IEnumerable<CategoryContent>> ReadAllCategoryContents();
    }
}
