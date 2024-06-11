using Entities.Poco;
using Microsoft.EntityFrameworkCore;
using RepositoryEFCore.DataContext;
using RepositoryEFCore.Repositories;

namespace TestSpiderWatcher.UserTest
{
    public class UserRepositoryUnitTest
    {
        private DbContextOptions<SpiderWatcherContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<SpiderWatcherContext>()
                .UseInMemoryDatabase(databaseName: "TestUserDB")
                .Options;
        }

        [Fact]
        public void CreateUserSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

                UserRepository repository = new(context);
                User user = new()
                {
                    Email = "test@example.com",
                    Name = "Cesar",
                    LastName = "Gonzalez",
                    AccountType = true,
                    DateBirth = new DateOnly(1198, 10, 6),
                    UserName = "DracoGilga",
                    Password = "password",
                    Restore = false,
                    Confirmation = true
                };

                // Act
                repository.CreateUser(user);

                // Assert
                Assert.Equal(user.UserId, context.Users.Single().UserId);
                Assert.Equal(user.Email, context.Users.Single().Email);
            }
        }

        [Fact]
        public void ReadUserSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

                UserRepository repository = new(context);
                User user = new()
                {
                    UserId = 1,
                    Email = "test@example.com",
                    Name = "Cesar",
                    LastName = "Gonzalez",
                    AccountType = true,
                    DateBirth = new DateOnly(1198, 10, 6),
                    UserName = "DracoGilga",
                    Password = "password",
                    Restore = false,
                    Confirmation = true
                };
                repository.CreateUser(user);

                // Act
                var retrievedUser = repository.ReadUser(1);

                // Assert
                Assert.NotNull(retrievedUser);
            }
        }

        [Fact]
        public void ReadUserNotFound()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

                UserRepository repository = new(context);

                // Act
                var retrievedUser = repository.ReadUser(999); // ID that does not exist

                // Assert
                Assert.Null(retrievedUser);
            }
        }

        [Fact]
        public void ReadAllUsersSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

                UserRepository repository = new(context);

                User user1 = new()
                {
                    Email = "test1@example.com",
                    Name = "Cesar1",
                    LastName = "Gonzalez1",
                    AccountType = true,
                    DateBirth = new DateOnly(1998, 10, 6),
                    UserName = "DracoGilga1",
                    Password = "password1",
                    Restore = false,
                    Confirmation = true
                };
                User user2 = new()
                {
                    Email = "test2@example.com",
                    Name = "Pablo",
                    LastName = "Hernan",
                    AccountType = true,
                    DateBirth = new DateOnly(2000, 6, 6),
                    UserName = "NoSoyPablo",
                    Password = "password2",
                    Restore = false,
                    Confirmation = true
                };
                repository.CreateUser(user1);
                repository.CreateUser(user2);
                context.SaveChanges();

                // Act
                var allUsers = repository.ReadAllUsers();

                // Assert
                Assert.NotNull(allUsers);
                Assert.Equal(2, allUsers.Count());
                Assert.Contains(allUsers, u => u.Email == "test1@example.com");
                Assert.Contains(allUsers, u => u.Email == "test2@example.com");
            }
        }

        [Fact]
        public void UpdateUserSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

                UserRepository repository = new(context);
                User user = new()
                {
                    Email = "test@example.com",
                    Name = "Cesar",
                    LastName = "Gonzalez",
                    AccountType = true,
                    DateBirth = new DateOnly(1198, 10, 6),
                    UserName = "DracoGilga",
                    Password = "password",
                    Restore = false,
                    Confirmation = true
                };
                repository.CreateUser(user);

                // Act
                user.Email = "newemail@example.com";
                var result = repository.UpdateUser(user);

                // Assert
                Assert.True(result);
            }
        }

        [Fact]
        public void UpdateUserPartialSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

                UserRepository repository = new(context);
                User user = new()
                {
                    Email = "test@example.com",
                    Name = "Cesar",
                    LastName = "Gonzalez",
                    AccountType = true,
                    DateBirth = new DateOnly(1198, 10, 6),
                    UserName = "DracoGilga",
                    Password = "password",
                    Restore = false,
                    Confirmation = true
                };
                repository.CreateUser(user);

                // Act
                user.Email = "newemail@example.com";
                var result = repository.UpdateUser(user);
                var updatedUser = repository.ReadUser(user.UserId);

                // Assert
                Assert.True(result);
                Assert.Equal("newemail@example.com", updatedUser.Email);
                Assert.Equal("Cesar", updatedUser.Name); // Ensure other fields are unchanged
            }
        }

        [Fact]
        public void UpgradeUserSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

                UserRepository repository = new(context);
                User user = new()
                {
                    Email = "test@example.com",
                    Name = "Cesar",
                    LastName = "Gonzalez",
                    AccountType = true,
                    DateBirth = new DateOnly(1198, 10, 6),
                    UserName = "DracoGilga",
                    Password = "password",
                    Restore = false,
                    Confirmation = true
                };
                repository.CreateUser(user);

                // Act
                user.AccountType = false;
                var result = repository.UpgradeUser(user);

                // Assert
                Assert.True(result);
            }
        }

        [Fact]
        public void DeleteUserSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

                UserRepository repository = new(context);
                User user = new()
                {
                    UserId = 1,
                    Email = "test@example.com",
                    Name = "Cesar",
                    LastName = "Gonzalez",
                    AccountType = true,
                    DateBirth = new DateOnly(1198, 10, 6),
                    UserName = "DracoGilga",
                    Password = "password",
                    Restore = false,
                    Confirmation = true
                };
                repository.CreateUser(user);

                // Act
                var deletedUser = repository.DeleteUser(1);

                // Assert
                Assert.NotNull(deletedUser);
            }
        }

        [Fact]
        public void DeleteUserNotFound()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

                UserRepository repository = new(context);

                // Act
                var deletedUser = repository.DeleteUser(999); // ID that does not exist

                // Assert
                Assert.Null(deletedUser);
            }
        }

        [Fact]
        public void LoginUserSuccess()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

                UserRepository repository = new(context);
                User user = new()
                {
                    Email = "test@example.com",
                    Name = "Cesar",
                    LastName = "Gonzalez",
                    AccountType = true,
                    DateBirth = new DateOnly(1198, 10, 6),
                    UserName = "DracoGilga",
                    Password = "password",
                    Restore = false,
                    Confirmation = true
                };
                repository.CreateUser(user);

                // Act
                var loggedInUser = repository.LoginUser("DracoGilga");

                // Assert
                Assert.NotNull(loggedInUser);
            }
        }

        [Fact]
        public void LoginUserIncorrectUsername()
        {
            // Arrange
            var options = CreateNewContextOptions();
            using (SpiderWatcherContext context = new(options))
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();

                UserRepository repository = new(context);
                User user = new()
                {
                    Email = "test@example.com",
                    Name = "Cesar",
                    LastName = "Gonzalez",
                    AccountType = true,
                    DateBirth = new DateOnly(1198, 10, 6),
                    UserName = "DracoGilga",
                    Password = "password",
                    Restore = false,
                    Confirmation = true
                };
                repository.CreateUser(user);

                // Act
                var loggedInUser = repository.LoginUser("IncorrectUsername");

                // Assert
                Assert.Null(loggedInUser);
            }
        }
    }
}