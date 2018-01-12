using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;
using System.Threading;

namespace EMAIL
{
    public static class grey
    {
        public static void send(string emailTo, string title, string msg)
        {
            work(emailTo, title, msg);
        }

        static void work(string emailTo, string title, string msg)
        {
            try
            {
                MailMessage mail = new MailMessage("greyavenuemanila@gmail.com", emailTo, title, msg);
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("greyavenuemanila@gmail.com", "greygreyavenue");
                client.EnableSsl = true;
                client.Send(mail);
            }
            catch(Exception ex)
            {

            }
        }

    }
}
