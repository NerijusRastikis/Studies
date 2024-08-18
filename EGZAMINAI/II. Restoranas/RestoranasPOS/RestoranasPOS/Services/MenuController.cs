using RestoranasPOS.Interfaces;
using RestoranasPOS.Models;
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
        private readonly POS_Logic _logic;

        public MenuController(IDisplay display, IFileManager fileManager, POS_Logic pOS)
        {
            _display = display;
            _fileManager = fileManager;
            _logic = pOS;
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
                        ShowViewOrderMenu();
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
                        _fileManager.WriteTo_Reservations(_logic.ConvertToString_Reservations());
                        break;
                    case 2:
                        _display.ChangeTableStatus();
                        break;
                    case 3:
                        _logic.PrintReservations();
                        break;
                    case 0:
                        return;
                }
            }
        }
        private void ShowViewOrderMenu()
        {
            while (true)
            {
                _display.ViewOrder();
                switch (_display.MenuChoice)
                {
                    case 1:
                        _display.SelectPayment();
                        _display.ViewCheque();
                        ToPrintChequeMenu();
                        return;
                    case 2:
                        _display.SelectPayment();
                        _display.ViewCheque();
                        ToPrintChequeMenu();
                        return;
                    case 0:
                        return;
                }
            }
        }
        private void ToPrintChequeMenu()
        {
            while (true)
            {
                var chequeForClient = new PrintCheque_Client(_fileManager, _display);
                var chequeForRestaurant = new PrintCheque_Restaurant(_fileManager, _display);
                _display.ToPrintCheque_OrNot_ToPrintCheque();
                switch(_display.MenuChoice)
                {
                    case 1:
                        _fileManager.WriteTo_Cheques(chequeForClient.PrintTheCheque(), chequeForClient.PrintChequeType());
                        _fileManager.WriteTo_Cheques(chequeForRestaurant.PrintTheCheque(), chequeForRestaurant.PrintChequeType());
                        _display.ChequePrintStatus();
                        return;
                    case 2:
                        _fileManager.WriteTo_Cheques(chequeForRestaurant.PrintTheCheque(), chequeForRestaurant.PrintChequeType());
                        _display.ChequePrintStatus();
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
