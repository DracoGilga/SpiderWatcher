namespace Entities.Poco
{
    public class CategoryContent
    {
        public int IdCategoryContent { get; set; }

        public int IdCategory { get; set; }
        public Category Category { get; set; }
        public int IdContent { get; set; }
        public Content Content { get; set; }
    }
}
