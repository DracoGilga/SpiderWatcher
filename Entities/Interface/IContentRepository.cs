using Entities.Poco;

namespace Entities.Interface
{
    public interface IContentRepository
    {
        void CreateContent(Content content);
        Content ReadContent(int id);
        bool UpdateContent(Content content);
        Content DeleteContent(int id);

        IEnumerable<Content> ReadAllContents(int idUser);
        Content ViewContent(Content content);
    }
}