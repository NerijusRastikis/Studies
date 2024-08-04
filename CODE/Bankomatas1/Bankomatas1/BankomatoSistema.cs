using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas1
{
    public class BankomatoSistema
    {
        public FileManager FM { get; set; }
        private readonly ConsoleDisplay cd;
        public int Choice { get; set; }
        public string TempUsername { get; set; }
        public string TempPassword { get; set; }
        public BankomatoSistema(string path, string pathLog)
        {
            FM = new FileManager(path, pathLog);
            cd = new ConsoleDisplay();
        }
        public void Communicator()
        {
            Prelogin();
            Menu();
        }
        public void Prelogin()
        {
            TempUsername = cd.UsernameInput();
            while (String.IsNullOrEmpty(TempUsername))
            {
                Console.Clear();
                cd.ShowMessage(Program.logo);
                Console.ForegroundColor = ConsoleColor.Red;
                cd.ShowMessage("Banko kortelės įvestis negali būti tuščias laukas! Pakartokite įvestį!");
                Console.ResetColor();
                cd.ShowMessage("Spauskite bet kurį mygtuką norėdami tęsti.");
                Console.ReadKey();
                TempUsername = cd.UsernameInput();
            }
            TempPassword = cd.PasswordInput();
            while (String.IsNullOrEmpty(TempPassword))
            {
                Console.Clear();
                cd.ShowMessage(Program.logo);
                Console.ForegroundColor = ConsoleColor.Red;
                cd.ShowMessage("Slaptažodio laukas negali būti tuščias! Pakartokite įvestį!");
                Console.ResetColor();
                cd.ShowMessage("Spauskite bet kurį mygtuką norėdami tęsti.");
                Console.ReadKey();
                TempPassword = cd.PasswordInput();
            }
        }
        public void Menu()
        {
            var login = new Login(TempUsername, TempPassword);
            do
            {
                if (login.LoginChecker())
                {
                    cd.WelcomeCurrentUser(FM.ReadFromFile()[2].Trim(), double.Parse(FM.ReadFromFile()[3]));
                    Choice = int.Parse(cd.MainMenu());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    cd.ShowMessage($"NETEISINGI PRISIJUNGIMO DUOMENYS! Jums liko {3 - login.Attempt} bandymų.");
                    Console.ResetColor();
                    Prelogin();
                }
            } while (!login.LoginChecker());

        }
    }
}
