using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace HaveYouSeenMe.Models.Business
{
    public class EmailManager
    {
        public static void SendEmail(string from, string to, string subject, string body, bool IsHTML)
        {
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(from);
                message.To.Add(to);
                message.Subject = subject;
                message.IsBodyHtml = IsHTML;
                message.Body = body;
                try
                {
                    client.Send(message);
                }
                catch (SmtpException)
                {

                }
            }
        }
    }
}