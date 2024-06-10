using Entities.Poco;

namespace TestSpiderWatcher.ContentTest
{
    public class ContentUnitTest
    {
        [Fact]
        public void ContentDefaultValuesSuccess()
        {
            // Arrange & Act
            Content content = new();

            // Assert
            Assert.Equal(0, content.ContentId);
            Assert.Null(content.Title);
            Assert.Null(content.Director);
            Assert.Null(content.Description);
            Assert.Equal(default(DateOnly), content.ReleaseDate);
            Assert.Equal(default(DateOnly), content.PublicationDate);
            Assert.Equal(default(TimeOnly), content.Duration);
            Assert.Equal(0, content.Rating);
            Assert.Null(content.ImageReference);
            Assert.Null(content.VideoReference);
        }

        [Fact]
        public void ContentValidDataSuccess()
        {
            // Arrange
            Content content = new();
            var releaseDate = new DateOnly(2021, 6, 1);
            var publicationDate = new DateOnly(2021, 6, 15);
            var duration = new TimeOnly(2, 30);

            // Act
            content.ContentId = 1;
            content.Title = "Inception";
            content.Director = "Christopher Nolan";
            content.Description = "A thief who enters the dreams of others to steal secrets from their subconscious.";
            content.ReleaseDate = releaseDate;
            content.PublicationDate = publicationDate;
            content.Duration = duration;
            content.Rating = 8;
            content.ImageReference = "inception.jpg";
            content.VideoReference = "inception.mp4";

            // Assert
            Assert.Equal(1, content.ContentId);
            Assert.Equal("Inception", content.Title);
            Assert.Equal("Christopher Nolan", content.Director);
            Assert.Equal("A thief who enters the dreams of others to steal secrets from their subconscious.", content.Description);
            Assert.Equal(releaseDate, content.ReleaseDate);
            Assert.Equal(publicationDate, content.PublicationDate);
            Assert.Equal(duration, content.Duration);
            Assert.Equal(8, content.Rating);
            Assert.Equal("inception.jpg", content.ImageReference);
            Assert.Equal("inception.mp4", content.VideoReference);
        }
    }
}
