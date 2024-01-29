using System.Net;
using System.Net.Mail;
using System.Text;

namespace imc_web_api.Service.EmailServices
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string email, string Subject)
        {
            //setUp SMTP server
            var UserName = "inamullahwebpro00@gmail.com";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(UserName, "yiwn smor pchv ogki"),
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };

            //Create Email Message

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(UserName);
            mailMessage.To.Add(email);
            mailMessage.Subject = Subject;
            mailMessage.IsBodyHtml = true;

            //create the body for Html content

            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<strong>Salary Promotion</strong>");
            mailMessage.Body = mailBody.ToString();

            smtpClient.Send(mailMessage);
        }
    }
}