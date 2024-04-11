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

        public IEnumerable<Content> ReadAllContents() => 
            Context.Contents ?? null;
        public Content ReadContent(int id) => 
            Context.Contents.FirstOrDefault(c => c.ContentId == id) ?? null;
        public bool UpdateContent(Content content) => 
            Context.Contents.Update(content) != null;
        public Content ViewContent(Content content) => 
            Context.Contents.FirstOrDefault(c => c.ContentId == content.ContentId) ?? null;
    }
}
