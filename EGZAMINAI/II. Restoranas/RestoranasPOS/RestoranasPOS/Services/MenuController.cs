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
        public delegate void MainMenuAction();
        public delegate void CategoryMenuAction();
        public delegate void ManageTableMenuAction();
        private readonly IDisplay _display;
        private readonly IFileManager _fileManager;

        public MenuController(IDisplay display, IFileManager fileManager)
        {
            _display = display;
            _fileManager = fileManager;
        }
        public void FirstRun()
        {
            _display.SelectWaiter();
            _display.SelectTable();
            Controller();
        }
        public void Controller()
        {
            Dictionary<int, MainMenuAction> mainMenu = new Dictionary<int, MainMenuAction>
        {
            { 1, _display.SelectWaiter },
            { 2, _display.SelectTable },
            { 3, _display.TakeOrder_SelectCategory },
            { 4, _display.ManageTableStatus },
            { 5, _display.ViewOrder },
            { 0, _display.Exit }
        };
            Dictionary<int, CategoryMenuAction> categoryMenu = new Dictionary<int, CategoryMenuAction>
        {
            { 1, () => _display.TakeOrder_NonAlko(_fileManager.ReadFrom_Nonalkodrinks()) },
            { 2, () => _display.TakeOrder_Alko(_fileManager.ReadFrom_Alkodrinks()) },
            { 3, () => _display.TakeOrder_Snacks(_fileManager.ReadFrom_Snacks()) },
            { 4, () => _display.TakeOrder_Cold(_fileManager.ReadFrom_Coldfood()) },
            { 5, () => _display.TakeOrder_Hot(_fileManager.ReadFrom_Hotfood()) },
            { 0, _display.MainMenu }
        };
            Dictionary<int, ManageTableMenuAction> menuTableMenu = new Dictionary<int, ManageTableMenuAction>
        {
            { 1, _display.ReserveTable },
            { 0, _display.MainMenu }
        };

            while (true)
            {
                mainMenu[_display.MenuChoice]();
                if (_display.MenuChoice == 3)
                {
                    categoryMenu[_display.MenuChoice]();
                }
                else if (_display.MenuChoice == 1)
                {
                    menuTableMenu[_display.MenuChoice]();
                }
            }
        }
    }
}
