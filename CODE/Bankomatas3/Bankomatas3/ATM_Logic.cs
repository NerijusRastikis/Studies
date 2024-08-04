using System;
using System.Collections.Generic;

namespace Bankomatas3
{
    public class ATM_Logic
    {
        private readonly string _pathUsers;
        private readonly string _pathATM;
        private readonly string _pathLogs;
        private FileManager _fm;
        private Display _display;

        public ATM_Logic(string pathUsers, string pathATM, string pathLogs)
        {
            _pathUsers = pathUsers;
            _pathATM = pathATM;
            _pathLogs = pathLogs;
            _fm = new FileManager(_pathUsers, _pathATM, _pathLogs);
            _display = new Display(null, null); // Ensure _display is initialized
        }

        public ATM_Logic(FileManager fileManager, Display display)
        {
            _fm = fileManager;
            _display = display;
        }

        public FileManager FM
        {
            get => _fm ??= new FileManager(_pathUsers, _pathATM, _pathLogs);
            set => _fm = value;
        }

        public string CardNumber { get; set; }
        public int PIN { get; set; }
        public decimal Funds { get; set; }
        public string Name { get; set; }
        public int Choice { get; set; }

        public void LogonAction()
        {
            int index = 0;
            bool hasUserBeenFound = false;

            do
            {
                var targetCard = _display.LoginCardNumber();
                var targetPIN = _display.LoginPIN();
                var users = FM.ReadFromUsersFile();

                foreach (var user in users)
                {
                    var dicedUserLine = user.Split(',');
                    if (dicedUserLine[0] == targetCard && int.Parse(dicedUserLine[1]) == targetPIN)
                    {
                        CardNumber = dicedUserLine[0];
                        PIN = int.Parse(dicedUserLine[1]);
                        Funds = decimal.Parse(dicedUserLine[2]);
                        Name = dicedUserLine[3];

                        _display.Name = Name;
                        _display.Funds = Funds;
                        _display.LoginSuccessful();

                        hasUserBeenFound = true;
                        break;
                    }
                }

                if (!hasUserBeenFound)
                {
                    index++;
                    _display.LoginAttemptFailed(index);
                }

                if (index >= 3)
                {
                    _display.LoginAttemptLimitReached();
                }
            } while (!hasUserBeenFound);
        }

        public void MenuNavigator()
        {
            int choice;
            _display.Welcome();
            _display.MainMenu();

            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2 && choice != 3 && choice != 0))
            {
                _display.ErrorInMainMenu();
                _display.MainMenu();
            }

            Choice = choice;
        }

        public void ProgramFlowController()
        {
            LogonAction();

            do
            {
                MenuNavigator();

                switch (Choice)
                {
                    case 1:
                        ViewBalance();
                        break;
                    case 2:
                        WithdrawFunds();
                        break;
                    case 3:
                        ViewLastTransactions();
                        break;
                    case 0:
                        _display.ATMExit();
                        break;
                    default:
                        _display.MainMenu();
                        break;
                }
            } while (true);
        }

        public void ViewBalance()
        {
            Console.Clear();
            _display.Welcome();
            _display.ViewBalance();
        }

        public void WithdrawFunds()
        {
            Console.Clear();
            _display.Welcome();
            var withdrawSum = _display.WithdrawFunds();

            if (withdrawSum <= Funds)
            {
                Funds -= withdrawSum;
                _display.Funds = Funds;
                _display.WithdrawSuccess();
                UpdateUserBalance();
            }
            else
            {
                _display.WithdrawError_NotEnoughFunds();
            }
        }

        public void UpdateUserBalance()
        {
            var users = FM.ReadFromUsersFile();
            for (int i = 0; i < users.Count(); i++)
            {
                var dicedUserLine = users[i].Split(',');
                if (dicedUserLine[0] == CardNumber)
                {
                    users[i] = $"{CardNumber},{PIN},{Funds},{Name}";
                    break;
                }
            }
            FM.WriteToUsersFile(users, CardNumber);
        }

        public void ViewLastTransactions()
        {
            
        }
    }
}