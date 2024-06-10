using Azure.Communication.Email;
using Entities.Poco;
using DTOs;
using RepositoryEmail.Repositories;
using DTOs.UserDTO;

namespace TestSpiderWatcher.RepositoryEmailTest
{
    public class SentEmailRepositoryUnitTest
    {
        private readonly string _testTemplateDirectory = "TestTemplates";

        private string GetTestTemplateFilePath(string templateName)
        {
            return Path.Combine(_testTemplateDirectory, templateName);
        }

        [Fact]
        public void CreateUserEmail_Success()
        {
            // Arrange
            User user = new ()
            {
                Email = "zs19023590@estudiantes.uv.mx",
                UserName = "username",
            };
            var emailSettings = new EmailSettings
            {
                ConnectionString = "endpoint=https://sentemail.unitedstates.communication.azure.com/;accesskey=...",
                SenderAddress = "DoNotReply@spider-watcher.live"
            };
            var emailClient = new EmailClient(emailSettings.ConnectionString);
            var repository = new SentEmailRepository(emailClient, emailSettings);

            // Act
            var result = repository.CreateUserEmail(user);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdatePasswordUserEmail_Success()
        {
            // Arrange
            User user = new()
            {
                Email = "zs19023590@estudiantes.uv.mx",
                Password = "password"
            };
            var emailSettings = new EmailSettings
            {
                ConnectionString = "endpoint=https://sentemail.unitedstates.communication.azure.com/;accesskey=...",
                SenderAddress = "DoNotReply@spider-watcher.live"
            };
            var emailClient = new EmailClient(emailSettings.ConnectionString);
            var repository = new SentEmailRepository(emailClient, emailSettings);
            var templatePath = GetTestTemplateFilePath("PasswordUpdate.html");

            // Act
            var result = repository.UpdatePasswordUserEmail(user);

            // Assert
            Assert.True(result);
        }
    }
}
