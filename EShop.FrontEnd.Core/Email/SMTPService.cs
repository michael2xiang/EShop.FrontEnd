using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace EShop.FrontEnd.Core.Email
{
    public class SMTPService : IEmailService
    {
        public void SendMail(string from, string to, string subject, string body)
        {
            MailMessage msg = new MailMessage();
            msg.Subject = subject;
            msg.Body = body;

            SmtpClient client = new SmtpClient();
            client.SendAsync(msg, null);
        }
    }
}
