namespace DTOs.HistoryPlaybackDTO
{
    public class ReadHistoryPlaybackDTO
    {
        public int IdHistory { get; init; }
        public int IdUser { get; init; }
        public int IdContent { get; init; }
        public TimeOnly PlaybackTime { get; init; }
        public DateOnly PlaybackDate { get; init; }
        public string ContentTitle { get; init; }
        public string UserName { get; init; }
    }
}
