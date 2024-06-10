using Entities.Poco;

namespace TestSpiderWatcher.CategoryContentTest
{
    public class CategoryContentUnitTest
    {
        [Fact]
        public void CategoryContentDefaultValuesSuccess()
        {
            // Arrange & Act
            CategoryContent categoryContent = new();

            // Assert
            Assert.Equal(0, categoryContent.CategoryContentId);
            Assert.Equal(0, categoryContent.CategoryId);
            Assert.Equal(0, categoryContent.ContentId);
            Assert.Null(categoryContent.Category);
            Assert.Null(categoryContent.Content);
        }

        [Fact]
        public void CategoryContentValidDataSuccess()
        {
            // Arrange
            CategoryContent categoryContent = new();

            // Act
            categoryContent.CategoryContentId = 1;
            categoryContent.CategoryId = 1;
            categoryContent.ContentId = 1;

            // Assert
            Assert.Equal(1, categoryContent.CategoryContentId);
            Assert.Equal(1, categoryContent.CategoryId);
            Assert.Equal(1, categoryContent.ContentId);
        }
    }
}
