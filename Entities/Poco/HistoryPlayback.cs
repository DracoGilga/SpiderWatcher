namespace Entities.Poco
{
    public class HistoryPlayback
    {
        public int HistoryPlaybackId { get; set; }
        public int UserId { get; set; }
        public int ContentId { get; set; }
        public TimeOnly PlaybackTime { get; set; }
        public DateOnly PlaybackDate { get; set; }
        public Content Content { get; set; }
        public User User { get; set; }
    }
}
