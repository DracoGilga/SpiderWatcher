namespace DTOs.ContentDTO
{
    public class UpdateContentDTO
    {
        public int IdContent { get; init; }
        public string Title { get; init; } 
        public string Director { get; init; } 
        public string Description { get; init; }
        public DateOnly ReleaseDate { get; init; }
        public TimeOnly Duration { get; init; }
        public int Rating { get; init; }
        public string ImageReference { get; init; }
        public string VideoReference { get; init; }
    }
}
