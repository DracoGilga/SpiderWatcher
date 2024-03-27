namespace Entities.Poco
{
    public class Content
    {
        public int ContentId { get; set; }
        public string Title { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateOnly ReleaseDate { get; set; }
        public DateOnly PublicationDate { get; set; }
        public TimeOnly Duration { get; set; }
        public int Rating { get; set; }
        public string ImageReference { get; set; } = null!;
        public string VideoReference { get; set; } = null!;
    }
}
