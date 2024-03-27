namespace Entities.Poco
{
    public class CategoryContent
    {
        public int CategoryContentId { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ContentId { get; set; }
        public Content Content { get; set; }
    }
}
