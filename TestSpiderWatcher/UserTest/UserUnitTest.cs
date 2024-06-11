using Entities.Poco;

namespace TestSpiderWatcher.UserTest
{
    public class UserUnitTest
    {
        [Fact]
        public void UserDefaultValuesSuccess()
        {
            // Arrange & Act
            User user = new User();

            // Assert
            Assert.Equal(0, user.UserId);
            Assert.Null(user.Email);
            Assert.Null(user.Name);
            Assert.Null(user.LastName);
            Assert.False(user.AccountType);
            Assert.Equal(default(DateOnly), user.DateBirth);
            Assert.Null(user.UserName);
            Assert.Null(user.Password);
            Assert.False(user.Restore);
            Assert.False(user.Confirmation);
        }

        [Fact]
        public void UserValidDataSuccess()
        {
            // Arrange
            User user = new();
            var dateOfBirth = new DateOnly(1998, 10, 6);

            // Act
            user.UserId = 1;
            user.Email = "test@example.com";
            user.Name = "Cesar";
            user.LastName = "Gonzalez";
            user.AccountType = true;
            user.DateBirth = dateOfBirth;
            user.UserName = "DracoGilga";
            user.Password = "password";
            user.Restore = true;
            user.Confirmation = true;

            // Assert
            Assert.Equal(1, user.UserId);
            Assert.Equal("test@example.com", user.Email);
            Assert.Equal("Cesar", user.Name);
            Assert.Equal("Gonzalez", user.LastName);
            Assert.True(user.AccountType);
            Assert.Equal(dateOfBirth, user.DateBirth);
            Assert.Equal("DracoGilga", user.UserName);
            Assert.Equal("password", user.Password);
            Assert.True(user.Restore);
            Assert.True(user.Confirmation);
        }

        [Fact]
        public void UserSetValidAccountTypeSuccess()
        {
            // Arrange
            User user = new();

            // Act
            user.AccountType = true;

            // Assert
            Assert.True(user.AccountType);
        }

        [Fact]
        public void UserSetInvalidAccountTypeSuccess()
        {
            // Arrange
            User user = new();

            // Act
            user.AccountType = false;

            // Assert
            Assert.False(user.AccountType);
        }

        [Fact]
        public void UserSetValidConfirmationSuccess()
        {
            // Arrange
            User user = new();

            // Act
            user.Confirmation = true;

            // Assert
            Assert.True(user.Confirmation);
        }

        [Fact]
        public void UserSetInvalidConfirmationSuccess()
        {
            // Arrange
            User user = new User();

            // Act
            user.Confirmation = false;

            // Assert
            Assert.False(user.Confirmation);
        }

    }

}
