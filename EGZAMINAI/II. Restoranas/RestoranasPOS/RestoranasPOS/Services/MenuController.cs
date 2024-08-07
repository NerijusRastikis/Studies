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
        private readonly IFileManager _fileManager;

        public MenuController(IDisplay display, IFileManager fileManager)
        {
            _display = display;
            _fileManager = fileManager;
        }
        public int FirstRun()
        {
            _display.SelectWaiter();
            _display.SelectTable();
            return _display.MainMenu();
        }
        public void Controller()
        {
            int tempChoice = 9;
            switch (FirstRun())
            {
                case 1:
                    _display.SelectWaiter();
                    break;
                case 2:
                    _display.SelectTable();
                    break;
                case 3:
                    while (tempChoice != 0)
                    {
                        tempChoice = _display.TakeOrder_SelectCategory();
                        switch (tempChoice)
                        {
                            case 1:
                                int selection = _display.TakeOrder_NonAlko(_fileManager.ReadFrom_Nonalkodrinks());
                                tempChoice = 0;
                                break;
                            case 2:
                                _display.TakeOrder_Alko(_fileManager.ReadFrom_Alkodrinks());
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 0:
                                _display.MainMenu();
                                break;
                            default:
                                throw new Exception("Kažkas ne taip");
                        }
                    }
                    _display.MainMenu();
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
