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
        public void DeleteCategory(int id) => 
            Context.Categories.Remove(ReadCategory(id));
        public IEnumerable<Category> ReadAllCategories() => 
            Context.Categories;
        public Category ReadCategory(int id) => 
            Context.Categories.Find(id);
        public bool UpdateCategory(Category category) => 
            Context.Categories.Update(category) != null;
    }
}
