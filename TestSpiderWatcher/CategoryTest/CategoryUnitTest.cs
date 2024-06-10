using Entities.Poco;

namespace TestSpiderWatcher.CategoryTest
{
    public class CategoryUnitTest
    {
        [Fact]
        public void CategoryDefaultValuesSuccess()
        {
            // Arrange & Act
            Category category = new();

            // Assert
            Assert.Equal(0, category.CategoryId);
            Assert.Null(category.Genre);
            Assert.Equal(0, category.MiniumAge);
        }

        [Fact]
        public void CategoryValidDataSuccess()
        {
            // Arrange
            Category category = new();

            // Act
            category.CategoryId = 1;
            category.Genre = "Action";
            category.MiniumAge = 18;

            // Assert
            Assert.Equal(1, category.CategoryId);
            Assert.Equal("Action", category.Genre);
            Assert.Equal(18, category.MiniumAge);

        }
    }
}
