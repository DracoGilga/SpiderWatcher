namespace Entities.Poco
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Genre { get; set; } = null!;
        public int MiniumAge { get; set; }
    }
}
