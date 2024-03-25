namespace DTOs.ContentDTO
{
    public class CreateContentDTO
    {
        public string Title { get; set; } 
        public string Director { get; set; } 
        public string Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public DateOnly PublicationDate { get; set; }
        public TimeOnly Duration { get; set; }
        public int Rating { get; set; }
        public string ImageReference { get; set; }
        public string VideoReference { get; set; }
    }
}
