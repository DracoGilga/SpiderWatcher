using Entities.Interface;
using Entities.Poco;
using RepositoryEFCore.DataContext;

namespace RepositoryEFCore.Repositories
{
    public class ContentRepository : IContentRepository
    {
        readonly SpiderWatcherContext Context;
        public ContentRepository(SpiderWatcherContext context) 
            => Context = context;

        public void CreateContent(Content content) => 
            Context.Add(content);
        public Content DeleteContent(int id)
        {
            var contentToDelete = ReadContent(id);
            if (contentToDelete != null)
            {
                var deletedContent = Context.Remove(contentToDelete).Entity;
                Context.SaveChanges(); 
                return deletedContent;
            }
            
            return null;
        }

        public IEnumerable<Content> ReadAllContents(int idUser)
        {
            var DateBirth = Context.Users
                .Where(u => u.UserId == idUser)
                .Select(u => u.DateBirth)
                .FirstOrDefault();

            var userAge = DateTime.Today.Year - DateBirth.Year;

            var contents = Context.Contents
                .Join(Context.CategoryContents,
                      content => content.ContentId,
                      categoryContent => categoryContent.ContentId,
                      (content, categoryContent) => new { Content = content, CategoryContent = categoryContent })
                .Join(Context.Categories,
                      combined => combined.CategoryContent.CategoryId,
                      category => category.CategoryId,
                      (combined, category) => new { Content = combined.Content, Category = category })
                .Where(x => userAge >= x.Category.MiniumAge)
                .Select(x => x.Content)
                .Distinct()
                .OrderBy(content => content.Title) 
                .ToList();

            return contents;
        }
        public Content ReadContent(int id) => 
            Context.Contents.FirstOrDefault(c => c.ContentId == id) ?? null;
        public bool UpdateContent(Content content) => 
            Context.Contents.Update(content) != null;
        public Content ViewContent(Content content) => 
            Context.Contents.FirstOrDefault(c => c.ContentId == content.ContentId) ?? null;
    }
}
