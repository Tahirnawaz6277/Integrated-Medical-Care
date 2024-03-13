using System.Net;
using System.Net.Mail;
using System.Text;

namespace imc_web_api.Service.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string Email, string Subject, string Description)
        {
            //setUp SMTP server

            string smtpUsername = _configuration["UserSecret:Username"];
            string smtpHost = _configuration["UserSecret:Host"];
            int smtpPort = _configuration.GetValue<int>("UserSecret:Port");

            SmtpClient smtpClient = new SmtpClient(smtpHost)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(smtpUsername, "yiwn smor pchv ogki"),
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };

            //Create Email Message

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(smtpUsername);
            mailMessage.To.Add(Email);
            mailMessage.Subject = Subject;
            mailMessage.IsBodyHtml = true;

            //create the body for Html content

            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat(Description);
            mailMessage.Body = mailBody.ToString();

            smtpClient.Send(mailMessage);
        }
    }
}