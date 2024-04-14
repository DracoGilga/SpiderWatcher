using Entities.Interface;
using Entities.Poco;
using RepositoryEFCore.DataContext;

namespace RepositoryEFCore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly SpiderWatcherContext Context;
        public CategoryRepository(SpiderWatcherContext context) 
            => Context = context;

        public void CreateCategory(Category category) => 
            Context.Categories.Add(category);
        public Category DeleteCategory(int id)
        {
            var categoryToDelete = ReadCategory(id);
            if (categoryToDelete != null)
            {
                Context.Categories.Remove(categoryToDelete);
                Context.SaveChanges();
                return categoryToDelete;
            }
            return null;
        }

        public IEnumerable<Category> ReadAllCategories() => 
            Context.Categories;
        public Category ReadCategory(int id) => 
            Context.Categories.Find(id);
        public bool UpdateCategory(Category category) => 
            Context.Categories.Update(category) != null;
    }
}
