namespace Entities.Poco
{
    public class HistoryPlayback
    {
        public int IdHistory { get; set; }
        public int IdUser { get; set; }
        public int IdContent { get; set; }
        public TimeOnly PlaybackTime { get; set; }
        public DateOnly PlaybackDate { get; set; }
        public Content Content { get; set; }
        public User User { get; set; }
    }
}
