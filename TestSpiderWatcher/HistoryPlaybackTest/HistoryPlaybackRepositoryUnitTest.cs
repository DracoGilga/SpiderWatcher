using Entities.Poco;
using Microsoft.EntityFrameworkCore;
using RepositoryEFCore.DataContext;
using RepositoryEFCore.Repositories;

namespace TestSpiderWatcher.HistoryPlaybackTest
{
    public class HistoryPlaybackRepositoryUnitTest
    {
        private DbContextOptions<SpiderWatcherContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<SpiderWatcherContext>()
                .UseInMemoryDatabase(databaseName: "TestSWDB")
                .Options;
        }

        [Fact]
        public void CreateHistoryPlaybackSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.HistoryPlaybacks.RemoveRange(context.HistoryPlaybacks); 
                context.SaveChanges();

                HistoryPlaybackRepository repository = new(context);
                HistoryPlayback historyPlayback = new()
                {
                    UserId = 1,
                    ContentId = 1,
                    PlaybackTime = new TimeOnly(10, 30),
                    PlaybackDate = new DateOnly(2024, 6, 10)
                };

                // Act
                repository.CreateHistoryPlayback(historyPlayback);
                context.SaveChanges();

                // Assert
                Assert.Equal(historyPlayback.HistoryPlaybackId, context.HistoryPlaybacks.Single().HistoryPlaybackId);
                Assert.Equal(historyPlayback.UserId, context.HistoryPlaybacks.Single().UserId);
            }
        }

        [Fact]
        public void ReadHistoryPlaybackSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.HistoryPlaybacks.RemoveRange(context.HistoryPlaybacks); 
                context.SaveChanges();

                HistoryPlaybackRepository repository = new(context);
                HistoryPlayback historyPlayback = new()
                {
                    HistoryPlaybackId = 1,
                    UserId = 1,
                    ContentId = 1,
                    PlaybackTime = new TimeOnly(10, 30),
                    PlaybackDate = new DateOnly(2024, 6, 10)
                };
                repository.CreateHistoryPlayback(historyPlayback);
                context.SaveChanges();

                // Act
                var retrievedHistoryPlayback = repository.ReadHistoryPlayback(1);

                // Assert
                Assert.NotNull(retrievedHistoryPlayback);
            }
        }

        [Fact]
        public void ReadHistoryPlaybackNotFound()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.HistoryPlaybacks.RemoveRange(context.HistoryPlaybacks); 
                context.SaveChanges();

                HistoryPlaybackRepository repository = new(context);

                // Act
                var retrievedHistoryPlayback = repository.ReadHistoryPlayback(999); 

                // Assert
                Assert.Null(retrievedHistoryPlayback);
            }
        }

        [Fact]
        public void ReadAllHistoryPlaybacksSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.HistoryPlaybacks.RemoveRange(context.HistoryPlaybacks); 
                context.SaveChanges();

                HistoryPlaybackRepository repository = new(context);

                HistoryPlayback historyPlayback1 = new()
                {
                    UserId = 1,
                    ContentId = 1,
                    PlaybackTime = new TimeOnly(10, 30),
                    PlaybackDate = new DateOnly(2024, 6, 10)
                };
                HistoryPlayback historyPlayback2 = new()
                {
                    UserId = 2,
                    ContentId = 2,
                    PlaybackTime = new TimeOnly(10, 30),
                    PlaybackDate = new DateOnly(2024, 6, 10)
                };
                repository.CreateHistoryPlayback(historyPlayback1);
                repository.CreateHistoryPlayback(historyPlayback2);
                context.SaveChanges();

                // Act
                var allHistoryPlaybacks = repository.ReadAllHistoryPlaybacks();

                // Assert
                Assert.NotNull(allHistoryPlaybacks);
                Assert.Equal(2, allHistoryPlaybacks.Count());
            }
        }

        [Fact]
        public void UpdateHistoryPlaybackSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.HistoryPlaybacks.RemoveRange(context.HistoryPlaybacks); 
                context.SaveChanges();

                HistoryPlaybackRepository repository = new(context);
                HistoryPlayback historyPlayback = new()
                {
                    HistoryPlaybackId = 1,
                    UserId = 1,
                    ContentId = 1,
                    PlaybackTime = new TimeOnly(10, 30),
                    PlaybackDate = new DateOnly(2024, 6, 10)
                };
                repository.CreateHistoryPlayback(historyPlayback);
                context.SaveChanges();

                // Act
                historyPlayback.UserId = 2;
                var result = repository.UpdateHistoryPlayback(historyPlayback);
                context.SaveChanges();

                // Assert
                Assert.True(result);
                Assert.Equal(2, context.HistoryPlaybacks.Single().UserId);
            }
        }

        [Fact]
        public void DeleteHistoryPlaybackSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.HistoryPlaybacks.RemoveRange(context.HistoryPlaybacks); 
                context.SaveChanges();

                HistoryPlaybackRepository repository = new(context);
                HistoryPlayback historyPlayback = new()
                {
                    HistoryPlaybackId = 1,
                    UserId = 1,
                    ContentId = 1,
                    PlaybackTime = new TimeOnly(10, 30),
                    PlaybackDate = new DateOnly(2024, 6, 10)
                };
                repository.CreateHistoryPlayback(historyPlayback);
                context.SaveChanges();

                // Act
                var deletedHistoryPlayback = repository.DeleteHistoryPlayback(1);

                // Assert
                Assert.NotNull(deletedHistoryPlayback);
                Assert.Equal(1, deletedHistoryPlayback.HistoryPlaybackId);
            }
        }

        [Fact]
        public void DeleteHistoryPlaybackNotFound()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.HistoryPlaybacks.RemoveRange(context.HistoryPlaybacks); 
                context.SaveChanges();

                HistoryPlaybackRepository repository = new(context);

                // Act
                var deletedHistoryPlayback = repository.DeleteHistoryPlayback(999); 

                // Assert
                Assert.Null(deletedHistoryPlayback);
            }
        }
    }
}
