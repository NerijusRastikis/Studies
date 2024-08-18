using RestoranasPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Services
{
    public class EmailService : IEmailService
    {
        public string SendEmail()
        {
            return "Čekis sėkmingai išsiųstas el. paštu!";
        }
    }
}
