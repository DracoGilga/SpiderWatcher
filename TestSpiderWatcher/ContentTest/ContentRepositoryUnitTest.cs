using Entities.Poco;
using Microsoft.EntityFrameworkCore;
using RepositoryEFCore.DataContext;
using RepositoryEFCore.Repositories;

namespace TestSpiderWatcher.ContentTest
{
    public class ContentRepositoryUnitTest
    {
        private DbContextOptions<SpiderWatcherContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<SpiderWatcherContext>()
                .UseInMemoryDatabase(databaseName: "TestSWDB")
                .Options;
        }

        [Fact]
        public void CreateContentSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Contents.RemoveRange(context.Contents);
                context.SaveChanges();

                ContentRepository repository = new(context);
                Content content = new()
                {
                    Title = "Avengers: Endgame",
                    Director = "Anthony Russo, Joe Russo",
                    Description = "The Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
                    ReleaseDate = new DateOnly(2019, 4, 26),
                    PublicationDate = new DateOnly(2019, 5, 7),
                    Duration = new TimeOnly(3, 2),
                    Rating = 8,
                    ImageReference = "avengers_endgame.jpg",
                    VideoReference = "avengers_endgame.mp4"
                };

                // Act
                repository.CreateContent(content);
                context.SaveChanges();

                // Assert
                Assert.Equal(content.Title, context.Contents.Single().Title);
            }
        }

        [Fact]
        public void ReadContentSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Contents.RemoveRange(context.Contents);
                context.SaveChanges();

                ContentRepository repository = new(context);
                Content content = new()
                {
                    ContentId = 1,
                    Title = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    ReleaseDate = new DateOnly(1994, 10, 14),
                    PublicationDate = new DateOnly(1995, 2, 17),
                    Duration = new TimeOnly(2, 22),
                    Rating = 9,
                    ImageReference = "shawshank_redemption.jpg",
                    VideoReference = "shawshank_redemption.mp4"
                };
                repository.CreateContent(content);
                context.SaveChanges();

                // Act
                var retrievedContent = repository.ReadContent(1);

                // Assert
                Assert.NotNull(retrievedContent);
            }
        }

        [Fact]
        public void ReadAllContentsSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Contents.RemoveRange(context.Contents);
                context.SaveChanges();

                ContentRepository repository = new(context);

                Content content1 = new()
                {
                    Title = "Inception",
                    Director = "Christopher Nolan",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    ReleaseDate = new DateOnly(2010, 7, 16),
                    PublicationDate = new DateOnly(2010, 8, 9),
                    Duration = new TimeOnly(2, 28),
                    Rating = 8,
                    ImageReference = "inception.jpg",
                    VideoReference = "inception.mp4"
                };
                Content content2 = new()
                {
                    Title = "The Dark Knight",
                    Director = "Christopher Nolan",
                    Description = "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
                    ReleaseDate = new DateOnly(2008, 7, 18),
                    PublicationDate = new DateOnly(2008, 8, 11),
                    Duration = new TimeOnly(2, 32),
                    Rating = 9,
                    ImageReference = "dark_knight.jpg",
                    VideoReference = "dark_knight.mp4"
                };
                repository.CreateContent(content1);
                repository.CreateContent(content2);
                context.SaveChanges();

                // Act
                var allContents = repository.ReadAllContents();

                // Assert
                Assert.NotNull(allContents);
                Assert.Equal(2, allContents.Count());
            }
        }

        [Fact]
        public void UpdateContentSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Contents.RemoveRange(context.Contents);
                context.SaveChanges();

                ContentRepository repository = new(context);
                Content content = new()
                {
                    ContentId = 1,
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                    ReleaseDate = new DateOnly(1972, 3, 24),
                    PublicationDate = new DateOnly(1972, 5, 19),
                    Duration = new TimeOnly(2, 55),
                    Rating = 9,
                    ImageReference = "godfather.jpg",
                    VideoReference = "godfather.mp4"
                };
                repository.CreateContent(content);
                context.SaveChanges();

                // Act
                content.Title = "The Godfather: Part II";
                var result = repository.UpdateContent(content);
                context.SaveChanges();

                // Assert
                Assert.True(result);
                Assert.Equal("The Godfather: Part II", context.Contents.Single().Title);
            }
        }

        [Fact]
        public void DeleteContentSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Contents.RemoveRange(context.Contents);
                context.SaveChanges();

                ContentRepository repository = new(context);
                Content content = new()
                {
                    ContentId = 1,
                    Title = "The Matrix",
                    Director = "Lana Wachowski, Lilly Wachowski",
                    Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                    ReleaseDate = new DateOnly(1999, 3, 31),
                    PublicationDate = new DateOnly(1999, 6, 1),
                    Duration = new TimeOnly(2, 16),
                    Rating = 8,
                    ImageReference = "matrix.jpg",
                    VideoReference = "matrix.mp4"
                };
                repository.CreateContent(content);
                context.SaveChanges();

                // Act
                var deletedContent = repository.DeleteContent(1);

                // Assert
                Assert.NotNull(deletedContent);
                Assert.Equal(1, deletedContent.ContentId);
            }
        }

        [Fact]
        public void ViewContentSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Contents.RemoveRange(context.Contents);
                context.SaveChanges();

                ContentRepository repository = new(context);
                Content content = new()
                {
                    ContentId = 1,
                    Title = "Interstellar",
                    Director = "Christopher Nolan",
                    Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                    ReleaseDate = new DateOnly(2014, 11, 7),
                    PublicationDate = new DateOnly(2015, 2, 10),
                    Duration = new TimeOnly(2, 49),
                    Rating = 8,
                    ImageReference = "interstellar.jpg",
                    VideoReference = "interstellar.mp4"
                };
                repository.CreateContent(content);
                context.SaveChanges();

                // Act
                var viewedContent = repository.ViewContent(content);

                // Assert
                Assert.NotNull(viewedContent);
                Assert.Equal(1, viewedContent.ContentId);
                Assert.Equal("Interstellar", viewedContent.Title);
            }
        }

    }
}
