using System;
using System.Collections.Generic;

class Program
{
    delegate void MenuAction();

    static void Main(string[] args)
    {
        IFileManager fileManager = new FileManager("C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\Bankomatas2\\Bankomatas2\\users.csv", "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\Bankomatas2\\Bankomatas2\\atm_funds.csv");
        IATM atm = new ATM(fileManager);
        Display display = new Display(atm);

        display.ShowWelcomeMessage();

        while (true)
        {
            var (cardNumber, pin) = display.GetLoginCredentials();

            if (atm.Login(cardNumber, pin))
            {
                break;
            }
            else
            {
                display.ShowLoginFailedMessage();
            }
        }

        var menuActions = new Dictionary<int, MenuAction>
        {
            { 1, atm.CheckBalance },
            { 2, () => WithdrawMoney(atm, display) },
            { 3, atm.CheckLastTransactions },
            { 4, Exit }
        };

        while (true)
        {
            display.ShowMenu();
            int option = display.GetMenuOption();
            if (menuActions.ContainsKey(option))
            {
                menuActions[option]();
            }
            else
            {
                display.ShowInvalidOptionMessage();
            }
        }
    }

    static void WithdrawMoney(IATM atm, Display display)
    {
        decimal amount = display.GetWithdrawAmount();
        if (amount > 0)
        {
            atm.WithdrawMoney(amount);
        }
    }

    static void Exit()
    {
        Display display = new Display(null);
        display.ShowExitMessage();
        Environment.Exit(0);
    }
}
