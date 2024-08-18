using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using RestoranasPOS.Interfaces;
using System.Net.Mail;

namespace RestoranasPOS.Services
{
    public class My_EmailService : IEmailService
    {
        private readonly IFileManager _fileManager;

        public My_EmailService(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public string SendEmail()
        {
            // MANO
            int iterator = 0;
            string stringToSend = "";
            var arrayToSend = _fileManager.ReadFrom_Cheques();
            foreach ( var item in arrayToSend )
            {
                stringToSend += $"{item}\n";
            }
            // TUTORIAL

            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("C# Program", "testcsharptestingsmtp@gmail.com"));
            email.To.Add(new MailboxAddress("Nerijus", "nerijus.rastikis@codeacademylt.onmicrosoft.com"));

            email.Subject = $"Restorano čekis #{iterator++}";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"<b>{stringToSend}</b>"
            };
            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate("testcsharptestingsmtp@gmail.com", "njep evju jswv leiu");

                smtp.Send(email);
                smtp.Disconnect(true);
            }
            return "Čekis sėkmingai išsiųstas el. paštu!";
        }
    }
}
