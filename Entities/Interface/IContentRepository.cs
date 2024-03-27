using Entities.Poco;

namespace Entities.Interface
{
    public interface IContentRepository
    {
        void CreateContent(Content content);
        Content ReadContent(int id);
        bool UpdateContent(Content content);
        void DeleteContent(Content content);

        IEnumerable<Content> ReadAllContents();
        Content ViewContent(Content content);
    }
}