using RestoranasPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Services
{
    public class MenuController
    {
        private readonly IDisplay _display;

        public MenuController(IDisplay display)
        {
            _display = display;
        }
        public int FirstRun()
        {
            _display.SelectWaiter();
            _display.SelectTable();
            return _display.MainMenu();
        }
        public void Controller()
        {
            switch (FirstRun())
            {
                case 1:
                    _display.SelectWaiter();
                    break;
                case 2:
                    _display.SelectTable();
                    break;
                case 3:
                    var tempChoice = _display.TakeOrder_SelectCategory();
                    if (tempChoice == 0)
                    {
                        _display.MainMenu();
                    }
                    
                    break;
                case 4:
                    break;
                case 0:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Ar tikrai norite išeiti? (y/n): ");
                    Console.ResetColor();
                    if (Console.ReadLine() == "y")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("IŠEINAMA...");
                        Console.ResetColor();
                        Environment.Exit(0);
                    }
                    else FirstRun();
                    break;
                default:
                    break;
            }
        }
        public int OrderFoodController()
        {
            return 0;
        }
    }
}
