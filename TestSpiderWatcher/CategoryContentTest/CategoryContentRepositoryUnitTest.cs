using Entities.Interface;
using Entities.Poco;
using Microsoft.EntityFrameworkCore;
using RepositoryEFCore.DataContext;
using RepositoryEFCore.Repositories;
using Xunit;

namespace TestSpiderWatcher.CategoryContentRepositoryTest
{
    public class CategoryContentRepositoryUnitTest
    {
        private DbContextOptions<SpiderWatcherContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<SpiderWatcherContext>()
                .UseInMemoryDatabase(databaseName: "TestSWDB")
                .Options;
        }

        [Fact]
        public void CreateCategoryContentSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.CategoryContents.RemoveRange(context.CategoryContents);
                context.SaveChanges();

                CategoryContentRepository repository = new(context);
                CategoryContent categoryContent = new()
                {
                    CategoryId = 1,
                    ContentId = 1
                };

                // Act
                repository.CreateCategoryContent(categoryContent);
                context.SaveChanges();

                // Assert
                Assert.Equal(categoryContent.CategoryId, context.CategoryContents.Single().CategoryId);
            }
        }

        [Fact]
        public void ReadCategoryContentSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.CategoryContents.RemoveRange(context.CategoryContents);
                context.SaveChanges();

                CategoryContentRepository repository = new(context);
                CategoryContent categoryContent = new()
                {
                    CategoryContentId = 1,
                    CategoryId = 1,
                    ContentId = 1
                };
                repository.CreateCategoryContent(categoryContent);
                context.SaveChanges();

                // Act
                var retrievedCategoryContent = repository.ReadCategoryContent(1);

                // Assert
                Assert.NotNull(retrievedCategoryContent);
            }
        }

        [Fact]
        public void ReadAllCategoryContentsSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.CategoryContents.RemoveRange(context.CategoryContents);
                context.SaveChanges();

                CategoryContentRepository repository = new(context);

                CategoryContent categoryContent1 = new()
                {
                    CategoryId = 1,
                    ContentId = 1
                };
                CategoryContent categoryContent2 = new()
                {
                    CategoryId = 2,
                    ContentId = 2
                };
                repository.CreateCategoryContent(categoryContent1);
                repository.CreateCategoryContent(categoryContent2);
                context.SaveChanges();

                // Act
                var allCategoryContents = repository.ReadAllCategoryContents();

                // Assert
                Assert.NotNull(allCategoryContents);
                Assert.Equal(2, allCategoryContents.Count());
            }
        }

        [Fact]
        public void UpdateCategoryContentSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.CategoryContents.RemoveRange(context.CategoryContents);
                context.SaveChanges();

                CategoryContentRepository repository = new(context);
                CategoryContent categoryContent = new()
                {
                    CategoryContentId = 1,
                    CategoryId = 1,
                    ContentId = 1
                };
                repository.CreateCategoryContent(categoryContent);
                context.SaveChanges();

                // Act
                categoryContent.CategoryId = 2;
                var result = repository.UpdateCategoryContent(categoryContent);
                context.SaveChanges();

                // Assert
                Assert.True(result);
                Assert.Equal(2, context.CategoryContents.Single().CategoryId);
            }
        }

        [Fact]
        public void DeleteCategoryContentSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.CategoryContents.RemoveRange(context.CategoryContents);
                context.SaveChanges();

                CategoryContentRepository repository = new(context);
                CategoryContent categoryContent = new()
                {
                    CategoryContentId = 1,
                    CategoryId = 1,
                    ContentId = 1
                };
                repository.CreateCategoryContent(categoryContent);
                context.SaveChanges();

                // Act
                var deletedCategoryContent = repository.DeleteCategoryContent(1);

                // Assert
                Assert.NotNull(deletedCategoryContent);
                Assert.Equal(1, deletedCategoryContent.CategoryContentId);
            }
        }
    }
}
