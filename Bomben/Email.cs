using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Bomben
{
    class Email
    {
        public void MailWithAttachement(string toMailAddress, string filename)
        {
            //New mailobject
            MailMessage mail = new MailMessage("christer.lindberg@live.se", toMailAddress, "Ny Bomben!", "Testar att skriva i bodyn");

            //Add file
            Attachment file = new Attachment(filename);

            //Add attachement to mail
            mail.Attachments.Add(file);


            //Setup smtpServer
            SmtpClient server = new SmtpClient();
            server.Host = "smtp.live.com";
            server.UseDefaultCredentials = false;
            server.Credentials = new System.Net.NetworkCredential("christer.lindberg@live.se", "Start(9)");
            server.Port = 587;
            server.EnableSsl = true;
            

            try
            {
                server.Send(mail);
            }
                catch (Exception ex) {
			        Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}", 
                    ex.ToString() );			  
			}



        }

    }
}
