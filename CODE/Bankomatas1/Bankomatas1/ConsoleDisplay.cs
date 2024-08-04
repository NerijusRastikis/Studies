using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas1
{
    public class ConsoleDisplay : IDisplay
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        public string UsernameInput()
        {
            Console.Clear();
            ShowMessage(Program.logo);
            ShowMessage("Sveiki atvyke i Bankomata!");
            ShowMessage("Iveskite korteles numeri:");
            return Console.ReadLine();
        }
        public string PasswordInput()
        {
            Console.Clear();
            ShowMessage(Program.logo);
            ShowMessage("Sveiki atvyke i Bankomata!");
            ShowMessage("Iveskite slaptazodi:");
            return Console.ReadLine();
        }
        public void WelcomeCurrentUser(string name, double money)
        {
            Console.Clear();
            ShowMessage(Program.logo);
            ShowMessage($"Sveiki, {name}!");
            Console.WriteLine();
            ShowMessage($"Jusu esami pinigai: {money}€");
        }
        public string MainMenu()
        {
            ShowMessage("--> M E N I U <--");
            Console.WriteLine();
            ShowMessage("1. <== Tikrinti pinigų balansą");
            ShowMessage("2. <== Paskutinės 5 transakcijos");
            ShowMessage("3. <== Išsiimti pinigus");
            ShowMessage("0. <== Išeiti");
            return Console.ReadLine();
        }
    }
}
