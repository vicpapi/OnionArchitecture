using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Onion.Infrastructure.ApplicationLog.Helper
{
    public static class EmailLogger
    {
        public static bool SendEmail(string body)
        {
            var to = new MailAddress(ConfigurationManager.LOG4NET_EMAIL_TO);

            var from = new MailAddress(ConfigurationManager.LOG4NET_EMAIL_FROM);

            var mail = new MailMessage(from, to);

            mail.Subject = ConfigurationManager.LOG4NET_EMAIL_SUBJECT;

            mail.Body = ConfigurationManager.LOG4NET_EMAIL_BODY;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.LOG4NET_EMAIL_SMTPHOST;
            smtp.Port = ConfigurationManager.LOG4NET_EMAIL_PORT;
            smtp.EnableSsl = ConfigurationManager.LOG4NET_EMAIL_ENABLEDSSL;

            smtp.Credentials = new NetworkCredential(
               ConfigurationManager.LOG4NET_EMAIL_USERNAME,
               ConfigurationManager.LOG4NET_EMAIL_PASSWORD);

            smtp.Send(mail);

            return true;
        }
    }
}
