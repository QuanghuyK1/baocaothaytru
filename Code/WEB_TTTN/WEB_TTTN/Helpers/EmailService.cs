using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using System.Drawing.Imaging;
using System.Drawing;
using System.Net.Mime;
using System.Net.Http;
using System.IO;

namespace WEB_TTTN.Helpers
{
    public class EmailService : IEmailService
    {
        private readonly EmailSetting _emailSettings;

        public EmailService(IOptions<EmailSetting> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.FromEmail, _emailSettings.FromName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            using (var smtpClient = new SmtpClient(_emailSettings.SmtpHost, _emailSettings.SmtpPort))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password);
                smtpClient.EnableSsl = true;

                await smtpClient.SendMailAsync(mailMessage);
            }
        }

        public async Task SendEmailWithQRCode(string email, string subject, string message, string qrCodeContent)
        {
            // Generate QR code image
            Bitmap qrCodeImage = QrCodeHelper.GenerateQrCode(qrCodeContent);

            // Convert the QR code image to bytes
            byte[] qrCodeBytes;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                qrCodeImage.Save(memoryStream, ImageFormat.Png);
                qrCodeBytes = memoryStream.ToArray();
            }

            // Create the attachment from the image bytes
            var qrCodeAttachment = new Attachment(new MemoryStream(qrCodeBytes), "qr_code.png", "image/png");

            // Create the email message
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.FromEmail, _emailSettings.FromName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);
            mailMessage.Attachments.Add(qrCodeAttachment);

            // Send the email with the attached QR code
            using (var smtpClient = new SmtpClient(_emailSettings.SmtpHost, _emailSettings.SmtpPort))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password);
                smtpClient.EnableSsl = true;

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
