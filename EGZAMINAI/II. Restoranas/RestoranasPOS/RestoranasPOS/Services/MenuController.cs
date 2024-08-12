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

        public void FirstRun()
        {
            _display.SelectWaiter();
            _display.SelectTable();
            Controller();
        }

        public void Controller()
        {
            while (true)
            {
                _display.MainMenu();

                switch (_display.MenuChoice)
                {
                    case 1:
                        _display.SelectWaiter();
                        break;
                    case 2:
                        _display.SelectTable();
                        break;
                    case 3:
                        ShowCategoryMenu();
                        break;
                    case 4:
                        ShowManageTableMenu();
                        break;
                    case 5:
                        _display.ViewOrder();
                        break;
                    case 0:
                        _display.Exit();
                        return;
                }
            }
        }

        private void ShowCategoryMenu()
        {
            while (true)
            {
                _display.TakeOrder_SelectCategory();

                switch (_display.MenuChoice)
                {
                    case 1:
                        _display.TakeOrder_NonAlko(_fileManager.ReadFrom_Nonalkodrinks());
                        break;
                    case 2:
                        _display.TakeOrder_Alko(_fileManager.ReadFrom_Alkodrinks());
                        break;
                    case 3:
                        _display.TakeOrder_Snacks(_fileManager.ReadFrom_Snacks());
                        break;
                    case 4:
                        _display.TakeOrder_Cold(_fileManager.ReadFrom_Coldfood());
                        break;
                    case 5:
                        _display.TakeOrder_Hot(_fileManager.ReadFrom_Hotfood());
                        break;
                    case 0:
                        return;
                }
            }
        }

        private void ShowManageTableMenu()
        {
            while (true)
            {
                _display.ManageTableStatus();

                switch (_display.MenuChoice)
                {
                    case 1:
                        _display.ReserveTable();
                        break;
                    case 0:
                        return;
                }
            }
        }
    }
}
