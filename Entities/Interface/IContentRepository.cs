using Entities.Poco;

namespace Entities.Interface
{
    public interface IContentRepository
    {
        Task CreateContent(Content content);
        Task<Content> ReadContent(int id);
        Task UpdateContent(Content content);
        Task DeleteContent(Content content);

        Task<IEnumerable<Content>> ReadAllContents();
        Task ViewContent(Content content);
    }
}