using Entities.Poco;

namespace TestSpiderWatcher.HistoryPlaybackTest
{
    public class HistoryPlaybackUnitTest
    {
        [Fact]
        public void HistoryPlaybackDefaultValuesSuccess()
        {
            // Arrange & Act
            HistoryPlayback historyPlayback = new();

            // Assert
            Assert.Equal(0, historyPlayback.HistoryPlaybackId);
            Assert.Equal(0, historyPlayback.UserId);
            Assert.Equal(0, historyPlayback.ContentId);
            Assert.Equal(default(TimeOnly), historyPlayback.PlaybackTime);
            Assert.Equal(default(DateOnly), historyPlayback.PlaybackDate);
            Assert.Null(historyPlayback.Content);
            Assert.Null(historyPlayback.User);
        }

        [Fact]
        public void HistoryPlaybackValidDataSuccess()
        {
            // Arrange
            HistoryPlayback historyPlayback = new();
            var playbackTime = new TimeOnly(2, 30);
            var playbackDate = new DateOnly(2024, 6, 9);

            // Act
            historyPlayback.HistoryPlaybackId = 1;
            historyPlayback.UserId = 1;
            historyPlayback.ContentId = 1;
            historyPlayback.PlaybackTime = playbackTime;
            historyPlayback.PlaybackDate = playbackDate;

            // Assert
            Assert.Equal(1, historyPlayback.HistoryPlaybackId);
            Assert.Equal(1, historyPlayback.UserId);
            Assert.Equal(1, historyPlayback.ContentId);
            Assert.Equal(playbackTime, historyPlayback.PlaybackTime);
            Assert.Equal(playbackDate, historyPlayback.PlaybackDate);
        }
    }
}
