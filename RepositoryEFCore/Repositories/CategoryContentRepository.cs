using Entities.Interface;
using Entities.Poco;
using RepositoryEFCore.DataContext;

namespace RepositoryEFCore.Repositories
{
    public class CategoryContentRepository : ICategoryContentRepository
    {
        readonly SpiderWatcherContext Context;
        public CategoryContentRepository(SpiderWatcherContext context) 
            => Context = context;

        public void CreateCategoryContent(CategoryContent categoryContent) => 
            Context.CategoryContents.Add(categoryContent);
        public void DeleteCategoryContent(int id) => 
            Context.CategoryContents.Remove(ReadCategoryContent(id));
        public IEnumerable<CategoryContent> ReadAllCategoryContents() =>
            Context.CategoryContents;
        public CategoryContent ReadCategoryContent(int id) => 
            Context.CategoryContents.Find(id);
        public bool UpdateCategoryContent(CategoryContent categoryContent) => 
            Context.CategoryContents.Update(categoryContent) != null;
    }
}
