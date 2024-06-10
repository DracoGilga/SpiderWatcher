using Azure.Communication.Email;
using Azure;
using Entities.Interface;
using Entities.Poco;
using DTOs;

namespace RepositoryEmail.Repositories
{
    public class SentEmailRepository : ISentEmail
    {
        private readonly EmailClient emailClient;
        private readonly EmailSettings emailSettings;

        public SentEmailRepository(EmailClient emailClient, EmailSettings emailSettings) =>
            (this.emailClient, this.emailSettings) = (emailClient, emailSettings);

        public bool CreateUserEmail(User user)
        {
            string subject = "Welcome to SpiderWatcher";
            string htmlContent = GetHtmlContent("Templates/VerifyCount.html", user.Password);

            return SendEmail(user.Email, subject, htmlContent);
        }

        public bool UpdatePasswordUserEmail(User user)
        {
            string subject = "Password Updated";
            string htmlContent = GetHtmlContent("Templates/PasswordUpdate.html", user.Password);

            return SendEmail(user.Email, subject, htmlContent);
        }

        public bool UpgradeUserEmail(User user)
        {
            throw new NotImplementedException();
        }

        public bool SendEmail(string toEmail, string subject, string htmlContent)
        {
            try
            {
                EmailSendOperation emailSendOperation = emailClient.Send(
                    WaitUntil.Completed,
                    senderAddress: emailSettings.SenderAddress,
                    recipientAddress: toEmail,
                    subject: subject,
                    htmlContent: htmlContent);

                return emailSendOperation.HasCompleted;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public string GetHtmlContent(string filePath, string confirmUrl)
        {
            try
            {
                // Construir la ruta absoluta del archivo basado en el directorio de salida actual
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.Combine(basePath, filePath);

                string htmlContent = File.ReadAllText(fullPath);
                htmlContent = htmlContent.Replace("{ConfirmUrl}", confirmUrl);
                return htmlContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
}
