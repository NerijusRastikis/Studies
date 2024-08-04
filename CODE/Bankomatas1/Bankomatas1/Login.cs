using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas1
{
    public class Login
    {
        public Login(string card, string password)
        {
            Card = card;
            Password = password;
        }
        //public ConsoleDisplay cd { get; set; }
        public string Card { get; set; }
        public string Password { get; set; }
        public string CurrentUserName { get; set; }
        private double CurrentMoney { get; set; }
        public int Attempt { get; set; }
        public string[] CapturedUserDetails { get; set; }

        public void CheckCredentials()
        {
            Attempt = 0;
            var fm = new FileManager();
            foreach (var userLine in listOfUsers)
            {
                var dicedLine = userLine.Split(',');
                if (dicedLine[0] == Card && dicedLine[1] == Password)
                {
                    CapturedUserDetails = dicedLine;
                }
                else Attempt++;
            }
        }
        public bool LoginChecker()
        {
            CheckCredentials();
            if (Attempt > 0 && Attempt <= 3)
            {
                Attempt++;
                return false;
            }
            else if (Attempt > 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("PASIEKTAS BANDYMŲ MAKSIMUMAS (3 kartai)! UŽBLOKUOTA!");
                Console.ResetColor();
                Console.ReadKey();
                Environment.Exit(0);
                return false;
            }
            else return true;
        }
    }
}
