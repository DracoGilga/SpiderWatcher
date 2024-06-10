using Entities.Interface;
using Entities.Poco;
using Microsoft.EntityFrameworkCore;
using RepositoryEFCore.DataContext;
using RepositoryEFCore.Repositories;
using Xunit;

namespace TestSpiderWatcher.CategoryRepositoryTest
{
    public class CategoryRepositoryUnitTest
    {
        private DbContextOptions<SpiderWatcherContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<SpiderWatcherContext>()
                .UseInMemoryDatabase(databaseName: "TestSWDB")
                .Options;
        }

        [Fact]
        public void CreateCategorySuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Categories.RemoveRange(context.Categories);
                context.SaveChanges();

                CategoryRepository repository = new(context);
                Category category = new()
                {
                    Genre = "Action",
                    MiniumAge = 12
                };

                // Act
                repository.CreateCategory(category);
                context.SaveChanges();

                // Assert
                Assert.Equal(category.Genre, context.Categories.Single().Genre);
            }
        }

        [Fact]
        public void ReadCategorySuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Categories.RemoveRange(context.Categories);
                context.SaveChanges();

                CategoryRepository repository = new(context);
                Category category = new()
                {
                    CategoryId = 1,
                    Genre = "Action",
                    MiniumAge = 12
                };
                repository.CreateCategory(category);
                context.SaveChanges();

                // Act
                var retrievedCategory = repository.ReadCategory(1);

                // Assert
                Assert.NotNull(retrievedCategory);
            }
        }

        [Fact]
        public void ReadAllCategoriesSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Categories.RemoveRange(context.Categories);
                context.SaveChanges();

                CategoryRepository repository = new(context);

                Category category1 = new()
                {
                    Genre = "Action",
                    MiniumAge = 12
                };
                Category category2 = new()
                {
                    Genre = "Comedy",
                    MiniumAge = 10
                };
                repository.CreateCategory(category1);
                repository.CreateCategory(category2);
                context.SaveChanges();

                // Act
                var allCategories = repository.ReadAllCategories();

                // Assert
                Assert.NotNull(allCategories);
                Assert.Equal(2, allCategories.Count());
            }
        }

        [Fact]
        public void UpdateCategorySuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Categories.RemoveRange(context.Categories);
                context.SaveChanges();

                CategoryRepository repository = new(context);
                Category category = new()
                {
                    CategoryId = 1,
                    Genre = "Action",
                    MiniumAge = 12
                };
                repository.CreateCategory(category);
                context.SaveChanges();

                // Act
                category.Genre = "Thriller";
                var result = repository.UpdateCategory(category);
                context.SaveChanges();

                // Assert
                Assert.True(result);
                Assert.Equal("Thriller", context.Categories.Single().Genre);
            }
        }

        [Fact]
        public void DeleteCategorySuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Categories.RemoveRange(context.Categories);
                context.SaveChanges();

                CategoryRepository repository = new(context);
                Category category = new()
                {
                    CategoryId = 1,
                    Genre = "Action",
                    MiniumAge = 12
                };
                repository.CreateCategory(category);
                context.SaveChanges();

                // Act
                var deletedCategory = repository.DeleteCategory(1);

                // Assert
                Assert.NotNull(deletedCategory);
                Assert.Equal(1, deletedCategory.CategoryId);
            }
        }
    }
}
