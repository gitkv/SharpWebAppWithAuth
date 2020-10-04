using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;

namespace WebAppWithAuth.Infrastructure.Services.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> Logger;
        IConfigurationSection SmtpConfig { get; }

        public EmailSender(IConfiguration config, ILogger<EmailSender> logger)
        {
            Logger = logger;

            try
            {
                SmtpConfig = config.GetSection("Smtp");
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.Message);
            }
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(SmtpConfig["FromName"], SmtpConfig["From"]));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(TextFormat.Html)
                {
                    Text = htmlMessage
                };

                using var client = new SmtpClient {ServerCertificateValidationCallback = (s, c, h, e) => true};
                await client.ConnectAsync(SmtpConfig["Url"], Convert.ToInt32(SmtpConfig["Port"]),
                    SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(SmtpConfig["Login"], SmtpConfig["Password"]);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.Message);
            }
        }
    }
}