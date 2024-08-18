using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoranasPOS.Interfaces;

namespace RestoranasPOS.Services
{
    public class Display : IDisplay
    {
        private readonly IEmailService _emailService;
        public string? SelectedWaiter { get; set; }
        public string? SelectedTable { get; set; }
        public decimal CurrentTableSum { get; set; }
        public Dictionary<string, List<decimal>> OrderInfo { get; set; } = new Dictionary<string, List<decimal>>();
        public Dictionary<string, int> TableStatus { get; set; } = new Dictionary<string, int>();
        public List <string> ClientInfo { get; set; }
        public int PaymentMethod { get; set; }
        public int ChequeNumber { get; set; }
        public decimal CashAmount { get; set; }
        public int MenuChoice {  get; set; }
        public decimal WaiterTips { get; set; }
        public decimal TableEarnings { get; set; }
        public List<string> FormedCheque { get; set; }

        #region Logos
        string justLogo = @"                                                                                
 ,---.  ,--.                  ,--.               ,--.          ,--.   ,--.        ,--. 
'   .-' |  |,-. ,---. ,--,--, `--' ,---.         |  |    ,---. |  |-. `--' ,--,--.`--' 
`.  `-. |     /| .-. ||      \,--.| .-. |        |  |   | .-. || .-. ',--.' ,-.  |,--. 
.-'    ||  \  \' '-' '|  ||  ||  |' '-' '        |  '--.' '-' '| `-' ||  |\ '-'  ||  | 
`-----' `--'`--'`---' `--''--'`--' `---'         `-----' `---'  `---' `--' `--`--'`--'  
";
        string mainMenuLogo = @"                                                                                
 ,---.  ,--.                  ,--.               ,--.          ,--.   ,--.        ,--. 
'   .-' |  |,-. ,---. ,--,--, `--' ,---.         |  |    ,---. |  |-. `--' ,--,--.`--' 
`.  `-. |     /| .-. ||      \,--.| .-. |        |  |   | .-. || .-. ',--.' ,-.  |,--. 
.-'    ||  \  \' '-' '|  ||  ||  |' '-' '        |  '--.' '-' '| `-' ||  |\ '-'  ||  |  _____         _
`-----' `--'`--'`---' `--''--'`--' `---'         `-----' `---'  `---' `--' `--`--'`--' |     |___ ___|_|_ _           
                                                                                       | | | | -_|   | | | |
                                                                                       |_|_|_|___|_|_|_|___|
";
        string stalaiLogo = @"                                                                                
 ,---.  ,--.                  ,--.               ,--.          ,--.   ,--.        ,--. 
'   .-' |  |,-. ,---. ,--,--, `--' ,---.         |  |    ,---. |  |-. `--' ,--,--.`--' 
`.  `-. |     /| .-. ||      \,--.| .-. |        |  |   | .-. || .-. ',--.' ,-.  |,--. 
.-'    ||  \  \' '-' '|  ||  ||  |' '-' '        |  '--.' '-' '| `-' ||  |\ '-'  ||  |  _____ _       _     _ 
`-----' `--'`--'`---' `--''--'`--' `---'         `-----' `---'  `---' `--' `--`--'`--' |   __| |_ ___| |___|_|         
                                                                                       |__   |  _| .'| | .'| |
                                                                                       |_____|_| |__,|_|__,|_|
";
        string uzkandziaiLogo = @"                                                                                
 ,---.  ,--.                  ,--.               ,--.          ,--.   ,--.        ,--. 
'   .-' |  |,-. ,---. ,--,--, `--' ,---.         |  |    ,---. |  |-. `--' ,--,--.`--' 
`.  `-. |     /| .-. ||      \,--.| .-. |        |  |   | .-. || .-. ',--.' ,-.  |,--. 
.-'    ||  \  \' '-' '|  ||  ||  |' '-' '        |  '--.' '-' '| `-' ||  |\ '-'  ||  |  _____             _       
`-----' `--'`--'`---' `--''--'`--' `---'         `-----' `---'  `---' `--' `--`--'`--' |   __|___ ___ ___| |_ ___         
                                                                                       |__   |   | .'|  _| '_|_ -|
                                                                                       |_____|_|_|__,|___|_,_|___|
";
        string saltiLogo = @"                                                                                
 ,---.  ,--.                  ,--.               ,--.          ,--.   ,--.        ,--. 
'   .-' |  |,-. ,---. ,--,--, `--' ,---.         |  |    ,---. |  |-. `--' ,--,--.`--' 
`.  `-. |     /| .-. ||      \,--.| .-. |        |  |   | .-. || .-. ',--.' ,-.  |,--. 
.-'    ||  \  \' '-' '|  ||  ||  |' '-' '        |  '--.' '-' '| `-' ||  |\ '-'  ||  |  _____     _   _ 
`-----' `--'`--'`---' `--''--'`--' `---'         `-----' `---'  `---' `--' `--`--'`--' |     |___| |_| |        
                                                                                       |   --| . | | . |
                                                                                       |_____|___|_|___|
";
        string karstiLogo = @"                                                                                
 ,---.  ,--.                  ,--.               ,--.          ,--.   ,--.        ,--. 
'   .-' |  |,-. ,---. ,--,--, `--' ,---.         |  |    ,---. |  |-. `--' ,--,--.`--' 
`.  `-. |     /| .-. ||      \,--.| .-. |        |  |   | .-. || .-. ',--.' ,-.  |,--. 
.-'    ||  \  \' '-' '|  ||  ||  |' '-' '        |  '--.' '-' '| `-' ||  |\ '-'  ||  |  _____     _   
`-----' `--'`--'`---' `--''--'`--' `---'         `-----' `---'  `---' `--' `--`--'`--' |  |  |___| |_        
                                                                                       |     | . |  _|
                                                                                       |__|__|___|_|  
";
        string alkoholiniaiLogo = @"                                                                                
 ,---.  ,--.                  ,--.               ,--.          ,--.   ,--.        ,--. 
'   .-' |  |,-. ,---. ,--,--, `--' ,---.         |  |    ,---. |  |-. `--' ,--,--.`--' 
`.  `-. |     /| .-. ||      \,--.| .-. |        |  |   | .-. || .-. ',--.' ,-.  |,--. 
.-'    ||  \  \' '-' '|  ||  ||  |' '-' '        |  '--.' '-' '| `-' ||  |\ '-'  ||  |  _____ _ _       
`-----' `--'`--'`---' `--''--'`--' `---'         `-----' `---'  `---' `--' `--`--'`--' |  _  | | |_ ___     
                                                                                       |     | | '_| . |
                                                                                       |__|__|_|_,_|___|
";
        string nealkoholiniaiLogo = @"                                                                                
 ,---.  ,--.                  ,--.               ,--.          ,--.   ,--.        ,--. 
'   .-' |  |,-. ,---. ,--,--, `--' ,---.         |  |    ,---. |  |-. `--' ,--,--.`--' 
`.  `-. |     /| .-. ||      \,--.| .-. |        |  |   | .-. || .-. ',--.' ,-.  |,--. 
.-'    ||  \  \' '-' '|  ||  ||  |' '-' '        |  '--.' '-' '| `-' ||  |\ '-'  ||  |  _____             _____ _ _       
`-----' `--'`--'`---' `--''--'`--' `---'         `-----' `---'  `---' `--' `--`--'`--' |   | |___ ___ ___|  _  | | |_ ___ 
                                                                                       | | | | . |   |___|     | | '_| . |
                                                                                       |_|___|___|_|_|   |__|__|_|_,_|___|
";
        string cekiaiLogo = @"                                                                                
 ,---.  ,--.                  ,--.               ,--.          ,--.   ,--.        ,--. 
'   .-' |  |,-. ,---. ,--,--, `--' ,---.         |  |    ,---. |  |-. `--' ,--,--.`--' 
`.  `-. |     /| .-. ||      \,--.| .-. |        |  |   | .-. || .-. ',--.' ,-.  |,--. 
.-'    ||  \  \' '-' '|  ||  ||  |' '-' '        |  '--.' '-' '| `-' ||  |\ '-'  ||  |  _____ _                   
`-----' `--'`--'`---' `--''--'`--' `---'         `-----' `---'  `---' `--' `--`--'`--' |     | |_ ___ ___ _ _ ___ 
                                                                                       |   --|   | -_| . | | | -_|
                                                                                       |_____|_|_|___|_  |___|___|
                                                                                                       |_|        
";
        string uzsakymasLogo = @"                                                                                
 ,---.  ,--.                  ,--.               ,--.          ,--.   ,--.        ,--. 
'   .-' |  |,-. ,---. ,--,--, `--' ,---.         |  |    ,---. |  |-. `--' ,--,--.`--' 
`.  `-. |     /| .-. ||      \,--.| .-. |        |  |   | .-. || .-. ',--.' ,-.  |,--. 
.-'    ||  \  \' '-' '|  ||  ||  |' '-' '        |  '--.' '-' '| `-' ||  |\ '-'  ||  |  _____       _         
`-----' `--'`--'`---' `--''--'`--' `---'         `-----' `---'  `---' `--' `--`--'`--' |     |___ _| |___ ___ 
                                                                                       |  |  |  _| . | -_|  _|
                                                                                       |_____|_| |___|___|_|          
";

        public Display(IEmailService emailService)
        {
            _emailService = emailService;
        }

        #endregion
        #region Header & Footer
        public void Header()
        {
            Console.Write("Pasirinktas padavėjas: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{SelectedWaiter} ");
            Console.ResetColor();
            Console.Write("Pasirinktas staliukas: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{SelectedTable} ");
            Console.ResetColor();
            Console.Write("Staliuko suma: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{CurrentTableSum} eur");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }
        public void Footer()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Pasirinktas padavėjas: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{SelectedWaiter} ");
            Console.ResetColor();
            Console.Write("Pasirinktas staliukas: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{SelectedTable} ");
            Console.ResetColor();
            Console.Write("Staliuko suma: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{CurrentTableSum} eur");
            Console.ResetColor();
        }
        #endregion
        #region SelectWaiter()
        public void SelectWaiter()
        {
            int waiterSelection = 0;
            string waiter1 = "Padavėjas 1";
            string waiter2 = "Padavėjas 2";
            string waiter3 = "Padavėjas 3";
            string waiter4 = "Padavėjas 4";
            Console.Clear();
            Console.WriteLine(justLogo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pasirinkite padavėją: ");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("#1 ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(waiter1);
            Console.ResetColor();
            Console.Write("#2 ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(waiter2);
            Console.ResetColor();
            Console.Write("#3 ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(waiter3);
            Console.ResetColor();
            Console.Write("#4 ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(waiter4);
            Console.ResetColor();

            // This loop will continue until a valid selection (1, 2, 3, or 4) is made
            while (!int.TryParse(Console.ReadLine(), out waiterSelection) ||
                   !(waiterSelection == 1 || waiterSelection == 2 || waiterSelection == 3 || waiterSelection == 4))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }

            switch (waiterSelection)
            {
                case 1:
                    SelectedWaiter = waiter1;
                    break;
                case 2:
                    SelectedWaiter = waiter2;
                    break;
                case 3:
                    SelectedWaiter = waiter3;
                    break;
                case 4:
                    SelectedWaiter = waiter4;
                    break;
                default:
                    SelectedWaiter = "Padavėjas 0";
                    break;
            }
        }
        #endregion
        public string IsTableTaken(string tableKey)
        {
            if (TableStatus == null || !TableStatus.ContainsKey(tableKey))
            {
                return "[LAISVAS]";
            }

            int status = TableStatus[tableKey];
            return status switch
            {
                0 => "[UŽIMTAS]",
                1 => "[REZERVUOTAS]",
                _ => "[LAISVAS]"
            };
        }
        #region PrintTableList() & PrintTable()
        public void PrintTableList()
        {
            PrintTable("#1 Staliukas", "(4-vietis)");
            PrintTable("#2 Staliukas", "(2-vietis)");
            PrintTable("#3 Staliukas", "(2-vietis)");
            PrintTable("#4 Staliukas", "(4-vietis)");
            PrintTable("#5 Staliukas", "(6-vietis)");
            PrintTable("#6 Staliukas", "(8-vietis)");
        }

        private void PrintTable(string tableKey, string tableType)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{tableKey} ");
            Console.ResetColor();
            Console.Write("Staliukas ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{tableType} ");

            string status = IsTableTaken(tableKey);
            switch (status)
            {
                case "[LAISVAS]":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "[REZERVUOTAS]":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "[UŽIMTAS]":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.WriteLine(status);
            Console.ResetColor();
        }
        #endregion
        #region SelectTable()
        public void SelectTable()
        {
            int selectTable = 0;
            Console.Clear();
            Console.WriteLine(stalaiLogo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pasirinkite staliuką: ");
            Console.WriteLine();
            Console.ResetColor();
            PrintTableList();
            while (!int.TryParse(Console.ReadLine(), out selectTable) || !(selectTable == 1
                                                                      || selectTable == 2
                                                                      || selectTable == 3
                                                                      || selectTable == 4
                                                                      || selectTable == 5
                                                                      || selectTable == 6))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Netinkamas pasirinkimas! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            switch (selectTable)
            {
                case 1:
                    SelectedTable = "#1 Staliukas";
                    break;
                case 2:
                    SelectedTable = "#2 Staliukas";
                    break;
                case 3:
                    SelectedTable = "#3 Staliukas";
                    break;
                case 4:
                    SelectedTable = "#4 Staliukas";
                    break;
                case 5:
                    SelectedTable = "#5 Staliukas";
                    break;
                case 6:
                    SelectedTable = "#6 Staliukas";
                    break;
                default:
                    SelectedTable = "Is naujo pasirinkite Staliuka";
                    break;
            }

            // JEI BUS LAIKO - Padaryk ispejima, kad renkasi rezervuota arba uzimta staliuka

            if (TableStatus.ContainsKey($"#{selectTable} Staliukas"))
            {

            }
        }
        #endregion

        #region TakeOrder_SelectCategory()
        public void TakeOrder_SelectCategory()
        {
            TableStatus[SelectedTable] = 0;
            Console.Clear();
            int userInput = 9;
            Console.WriteLine(uzsakymasLogo);
            Header();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pasirinkite kategoriją:");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#1 ");
            Console.ResetColor();
            Console.WriteLine("Nealkoholiniai gėrimai");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#2 ");
            Console.ResetColor();
            Console.WriteLine("Alkoholiniai gėrimai");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#3 ");
            Console.ResetColor();
            Console.WriteLine("Užkandžiai");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#4 ");
            Console.ResetColor();
            Console.WriteLine("Šalti patiekalai");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#5 ");
            Console.ResetColor();
            Console.WriteLine("Karšti patiekalai");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#0 ");
            Console.ResetColor();
            Console.WriteLine("Grįžti į meniu");
            while (!int.TryParse(Console.ReadLine(), out userInput) && userInput != 1
                                                                     && userInput != 2
                                                                     && userInput != 3
                                                                     && userInput != 4
                                                                     && userInput != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Prašome pakartoti įvestį: ");
            }
            MenuChoice = userInput;
        }
        #endregion

        #region TakeOrder_NonAlko
        public void TakeOrder_NonAlko(Dictionary<string, decimal> nonalkos)
        {
            Console.Clear();
            Console.WriteLine(nealkoholiniaiLogo);
            Header();
            Console.WriteLine();
            int userInput = 0;
            int iterator = 1;
            int quantity = 0;
            bool terminate = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Esate NEALKOHOLINIŲ GĖRIMŲ sąraše");
            Console.ResetColor();
            Console.WriteLine();
            foreach (var nonalko in nonalkos)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"#{iterator} ");
                Console.ResetColor();
                Console.Write($"{nonalko.Key} ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Kaina: ");
                Console.ResetColor();
                Console.WriteLine($"{nonalko.Value} eur");
                iterator++;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#0 ");
            Console.ResetColor();
            Console.WriteLine("Grįžti į meniu");
            while (!int.TryParse(Console.ReadLine(), out userInput) || !(userInput == 0
                                                                    || userInput == 1
                                                                    || userInput == 2
                                                                    || userInput == 3
                                                                    || userInput == 4
                                                                    || userInput == 5))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            Console.Clear();
            Console.WriteLine(nealkoholiniaiLogo);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (userInput != 0)
            {
                Console.Write("Pasirinktas: ");
                Console.ResetColor();
                Console.WriteLine($"{nonalkos.ElementAt(userInput - 1).Key}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Įveskite kiekį: ");
                Console.ResetColor();

                while (!int.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Tokio pasirinkimo nėra! ");
                    Console.ResetColor();
                    Console.WriteLine("Grįžtama į meniu...");
                    terminate = true;
                    continue;
                }
                Math.Abs(quantity);
                if (terminate == true)
                {
                    quantity = 0;
                }
                else
                {
                    List<decimal> orderList = new List<decimal> { quantity, nonalkos.ElementAt(userInput - 1).Value };
                    OrderInfo.Add(nonalkos.ElementAt(userInput - 1).Key, orderList);
                    CurrentTableSum += (nonalkos.ElementAt(userInput - 1).Value * quantity);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("OPERACIJA SĖKMINGA!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
            MenuChoice = userInput;
        }
        #endregion
        #region TakeOrder_Alko
        public void TakeOrder_Alko(Dictionary<string, decimal> alkos)
        {
            Console.Clear();
            Console.WriteLine(alkoholiniaiLogo);
            Header();
            Console.WriteLine();
            int userInput = 0;
            int iterator = 1;
            int quantity = 0;
            bool terminate = false;
            foreach (var alko in alkos)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"#{iterator} ");
                Console.ResetColor();
                Console.Write($"{alko.Key} ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Kaina: ");
                Console.ResetColor();
                Console.WriteLine($"{alko.Value} eur");
                iterator++;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#0 ");
            Console.ResetColor();
            Console.WriteLine("Grįžti į meniu");
            while (!int.TryParse(Console.ReadLine(), out userInput) && !(userInput == 0
                                                                    || userInput == 1
                                                                    || userInput == 2
                                                                    || userInput == 3
                                                                    || userInput == 4
                                                                    || userInput == 5))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            Console.Clear();
            Console.WriteLine(alkoholiniaiLogo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pasirinktas: ");
            Console.ResetColor();
            Console.WriteLine($"{alkos.ElementAt(userInput - 1).Key}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Įveskite kiekį: ");
            Console.ResetColor();
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.WriteLine("Grįžtama į meniu...");
                terminate = true;
                continue;
            }
            Math.Abs(quantity);
            if (terminate)
            {
                quantity = 0;
            }
            else
            {
                List<decimal> orderList = new List<decimal> { quantity, alkos.ElementAt(userInput - 1).Value };
                OrderInfo.Add(alkos.ElementAt(userInput - 1).Key, orderList);
                CurrentTableSum += alkos.ElementAt(userInput - 1).Value * quantity;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OPERACIJA SĖKMINGA!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
                Console.ResetColor();
                Console.ReadKey();
            }
            MenuChoice = userInput;
        }
        #endregion
        #region TakeOrder_Snacks
        public void TakeOrder_Snacks(Dictionary<string, decimal> snacks)
        {
            Console.Clear();
            Console.WriteLine(uzkandziaiLogo);
            Header();
            Console.WriteLine();
            int userInput = 0;
            int iterator = 1;
            int quantity = 0;
            bool terminate = false;
            foreach (var snack in snacks)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"#{iterator} ");
                Console.ResetColor();
                Console.Write($"{snack.Key} ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Kaina: ");
                Console.ResetColor();
                Console.WriteLine($"{snack.Value} eur");
                iterator++;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#0 ");
            Console.ResetColor();
            Console.WriteLine("Grįžti į meniu");
            while (!int.TryParse(Console.ReadLine(), out userInput) && !(userInput == 0
                                                                    || userInput == 1
                                                                    || userInput == 2
                                                                    || userInput == 3
                                                                    || userInput == 4
                                                                    || userInput == 5))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            Console.Clear();
            Console.WriteLine(uzkandziaiLogo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pasirinktas: ");
            Console.ResetColor();
            Console.WriteLine($"{snacks.ElementAt(userInput - 1).Key}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Įveskite kiekį: ");
            Console.ResetColor();
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.WriteLine("Grįžtama į meniu...");
                terminate = true;
                continue;
            }
            Math.Abs(quantity);
            if (terminate)
            {

            }
            else
            {
                List<decimal> orderList = new List<decimal> { quantity, snacks.ElementAt(userInput - 1).Value };
                OrderInfo.Add(snacks.ElementAt(userInput - 1).Key, orderList);
                CurrentTableSum += (snacks.ElementAt(userInput - 1).Value * quantity);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OPERACIJA SĖKMINGA!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
                Console.ResetColor();
                Console.ReadKey();
            }
            MenuChoice = userInput;
        }
        #endregion
        #region TakeOrder_Cold
        public void TakeOrder_Cold(Dictionary<string, decimal> colds)
        {
            Console.Clear();
            Console.WriteLine(alkoholiniaiLogo);
            Header();
            Console.WriteLine();
            int userInput = 0;
            int iterator = 1;
            int quantity = 0;
            bool terminate = false;
            foreach (var cold in colds)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"#{iterator} ");
                Console.ResetColor();
                Console.Write($"{cold.Key} ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Kaina: ");
                Console.ResetColor();
                Console.WriteLine($"{cold.Value} eur");
                iterator++;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#0 ");
            Console.ResetColor();
            Console.WriteLine("Grįžti į meniu");
            while (!int.TryParse(Console.ReadLine(), out userInput) && !(userInput == 0
                                                                      || userInput == 1
                                                                      || userInput == 2
                                                                      || userInput == 3
                                                                      || userInput == 4
                                                                      || userInput == 5))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            Console.Clear();
            Console.WriteLine(saltiLogo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pasirinktas: ");
            Console.ResetColor();
            Console.WriteLine($"{colds.ElementAt(userInput - 1).Key}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Įveskite kiekį: ");
            Console.ResetColor();
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.WriteLine("Grįžtama į meniu...");
                terminate = true;
                continue;
            }
            Math.Abs(quantity);
            if (terminate)
            {
                quantity = 0;
            }
            else
            {
                List<decimal> orderList = new List<decimal> { quantity, colds.ElementAt(userInput - 1).Value };
                OrderInfo.Add(colds.ElementAt(userInput - 1).Key, orderList);
                CurrentTableSum += (colds.ElementAt(userInput - 1).Value * quantity);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OPERACIJA SĖKMINGA!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
                Console.ResetColor();
                Console.ReadKey();
            }
            MenuChoice = userInput;
        }
        #endregion
        #region TakeOrder_Hot
        public void TakeOrder_Hot(Dictionary<string, decimal> hots)
        {
            Console.Clear();
            Console.WriteLine(alkoholiniaiLogo);
            Header();
            Console.WriteLine();
            int userInput = 0;
            int iterator = 1;
            int quantity = 0;
            bool terminate = false;
            foreach (var hot in hots)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"#{iterator} ");
                Console.ResetColor();
                Console.Write($"{hot.Key} ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Kaina: ");
                Console.ResetColor();
                Console.WriteLine($"{hot.Value} eur");
                iterator++;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#0 ");
            Console.ResetColor();
            Console.WriteLine("Grįžti į meniu");
            while (!int.TryParse(Console.ReadLine(), out userInput) && !(userInput == 0
                                                                    || userInput == 1
                                                                    || userInput == 2
                                                                    || userInput == 3
                                                                    || userInput == 4
                                                                    || userInput == 5))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            Console.Clear();
            Console.WriteLine(karstiLogo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pasirinktas: ");
            Console.ResetColor();
            Console.WriteLine($"{hots.ElementAt(userInput - 1).Key}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Įveskite kiekį: ");
            Console.ResetColor();
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.WriteLine("Grįžtama į meniu...");
                terminate = true;
                continue;
            }
            Math.Abs(quantity);
            if (terminate)
            {
                quantity = 0;
            }
            else
            {
                List<decimal> orderList = new List<decimal> { quantity, hots.ElementAt(userInput - 1).Value };
                OrderInfo.Add(hots.ElementAt(userInput - 1).Key, orderList);
                CurrentTableSum += (hots.ElementAt(userInput - 1).Value * quantity);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OPERACIJA SĖKMINGA!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
                Console.ResetColor();
                Console.ReadKey();
            }
            MenuChoice = userInput;
        }
        #endregion

        #region MainMenu()
        public void MainMenu()
        {
            int userInput = 9;
            Console.Clear();
            Console.WriteLine(mainMenuLogo);
            Header();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#1 ");
            Console.ResetColor();
            Console.WriteLine("Pakeisti padavėją");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#2 ");
            Console.ResetColor();
            Console.WriteLine("Pakeisti staliuką");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("#3 ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Užsakymo priėmimas");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#4 ");
            Console.ResetColor();
            Console.WriteLine("Staliukų statusų valdymas");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#5 ");
            Console.ResetColor();
            Console.WriteLine("Saskaitos peržiūra/apmokėjimas");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#0 ");
            Console.ResetColor();
            Console.WriteLine("Uždaryti programą");
            while (!int.TryParse(Console.ReadLine(), out userInput) || !(userInput == 1
                                                                    || userInput == 2
                                                                    || userInput == 3
                                                                    || userInput == 4
                                                                    || userInput == 5
                                                                    || userInput == 0))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            MenuChoice = userInput;
        }
        #endregion
        #region Exit()
        public void Exit()
        {
                MenuChoice = 0;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("IŠEINAMA...");
                Console.ResetColor();
                Environment.Exit(0);
        }
        #endregion

        #region ManageTableStatus()
        public void ManageTableStatus()
        {
            int userInput;
            Console.Clear();
            Console.WriteLine(stalaiLogo);
            Header();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Staliukų valdymas");
            Console.ResetColor();
            Console.WriteLine();
            PrintTableList();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#1 ");
            Console.ResetColor();
            Console.WriteLine("Rezervuoti staliuką");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#2 ");
            Console.ResetColor();
            Console.WriteLine("Keisti pasirinkto staliuko užimtumą");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#0 ");
            Console.ResetColor();
            Console.WriteLine("Grįžti");
            while (!int.TryParse(Console.ReadLine(), out userInput) || !(userInput == 1
                                                                    || userInput == 0))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            MenuChoice = userInput;
        }
        #endregion
        #region ChangeTableStatus()
        public void ChangeTableStatus()
        {
            int userInput;
            Console.Clear();
            Console.WriteLine(stalaiLogo);
            Header();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Keisti staliuko statusa");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#1 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[LAISVAS]");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#2 ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[REZERVUOTAS]");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#3 ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[UŽIMTAS]");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#0 ");
            Console.ResetColor();
            Console.WriteLine("Grįžti");
            while (!int.TryParse(Console.ReadLine(), out userInput) || !(userInput == 1
                                                                    || userInput == 2
                                                                    || userInput == 3
                                                                    || userInput == 0))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            switch (userInput)
            {
                case 1:
                    TableStatus[SelectedTable] = 2;
                    break;
                case 2:
                    TableStatus[SelectedTable] = 1;
                    break;
                case 3:
                    TableStatus[SelectedTable] = 0;
                    break;
                case 0:
                    break;
                default:
                    TableStatus[SelectedTable] = 2;
                    break;
            }
        }
        #endregion
        #region ReserveTable()
        public List<string> ReserveTable()
        {
            string userInput;
            var client = new List<string>();
            Console.Clear();
            Console.WriteLine(stalaiLogo);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pildote staliuko rezervaciją");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Vardas: ");
            Console.ResetColor();
            userInput = Console.ReadLine();
            while (String.IsNullOrEmpty(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Vardas negali būti tuščias! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
                userInput = Console.ReadLine();
            }
            client.Add(userInput);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Staliuko numeris: ");
            Console.ResetColor();
            userInput = Console.ReadLine();
            while (String.IsNullOrEmpty(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Staliuko numeris negali būti tuščias! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out var temp))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Staliuko numeris turi būti skaičius! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
                userInput = Console.ReadLine();
            }
            client.Add(userInput);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Laikas: ");
            Console.ResetColor();
            userInput = Console.ReadLine();
            while (String.IsNullOrEmpty(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Laikas negali būti tuščias! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
                userInput = Console.ReadLine();
            }
            client.Add(userInput);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Telefono numeris: ");
            Console.ResetColor();
            userInput = Console.ReadLine();
            while (String.IsNullOrEmpty(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Telefono numeris negali būti tuščias! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out var temp))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Telefono numeris turi būti skaičius! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out var temp) && temp.ToString().Count() != 9)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Telefono numeris turi būti 9 skaičiai! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
                userInput = Console.ReadLine();
            }
            client.Add(userInput);
            Console.Clear();
            Console.WriteLine(stalaiLogo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Vardas: ");
            Console.ResetColor();
            Console.Write($"{client[0]} | ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Staliukas: ");
            Console.ResetColor();
            Console.Write($"{client[1]} | ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Laikas: ");
            Console.ResetColor();
            Console.Write($"{client[2]} | ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Telefono numeris: ");
            Console.ResetColor();
            Console.WriteLine($"{client[3]}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("REZERVACIJA PATVIRTINTA!");

            // ---- Pakeiciamas statusas ---

            if (TableStatus.ContainsKey($"#{client[1]} Staliukas"))
            {
                TableStatus[$"#{client[1]} Staliukas"] = 1;
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
            Console.ResetColor();
            Console.ReadKey();
            return client;
        }
        #endregion

        #region ViewInvoiceOrOrderMenu()
        public int ViewInvoiceOrOrderMenu()
        {
            Console.Clear();
            int userInput;
            Console.WriteLine(mainMenuLogo);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#1 ");
            Console.ResetColor();
            Console.WriteLine("Peržiūrėti užsakymą");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#2 ");
            Console.ResetColor();
            Console.WriteLine("Peržiūrėti sąskaitą");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#0 ");
            Console.ResetColor();
            Console.WriteLine("Grįžti");
            Footer();
            while (!int.TryParse(Console.ReadLine(), out userInput) || !(userInput == 1
                                                                    || userInput == 2
                                                                    || userInput == 0))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Prašome pakartoti įvestį: ");
            }
            return userInput;
        }
        #endregion
        #region ViewOrder()
        public void ViewOrder()
        {
            int iterator = 1;
            int userInput;
            Console.Clear();
            Console.WriteLine(uzsakymasLogo);
            Console.WriteLine();
            Console.Write($"{SelectedTable} ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("užsakymo detalės:");
            Console.ResetColor();
            Console.WriteLine();
            foreach (var detail in OrderInfo)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"#{iterator} ");
                Console.ResetColor();
                Console.Write($"{detail.Key} ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("x ");
                Console.ResetColor();
                Console.WriteLine($"{detail.Value[0]}");
                iterator++;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pasirinkite: ");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#1 ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ATSISKAITYMAS");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#0 ");
            Console.ResetColor();
            Console.WriteLine("Grįžti");
            Footer();
            while (!int.TryParse(Console.ReadLine(), out userInput) || !(userInput == 1
                                                                    || userInput == 0))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            MenuChoice = userInput;
        }
        #endregion
        #region SelectPayment()
        public void SelectPayment()
        {
            int userInput;
            Console.Clear();
            Console.WriteLine(cekiaiLogo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pasirinkite mokėjimo būdą:");
            Console.WriteLine();
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.Write("#1 ");
            Console.ResetColor();
            Console.WriteLine("Grynieji");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#2 ");
            Console.ResetColor();
            Console.WriteLine("Bankinė kortelė");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#0 ");
            Console.ResetColor();
            Console.WriteLine("Grįžti");
            Footer();
            while (!int.TryParse(Console.ReadLine(), out userInput) || !(userInput == 1
                                                                    || userInput == 2
                                                                    || userInput == 0))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            if (userInput == 1)
            {
                CashAmount = PaymentIsCash();
            }
            PaymentMethod = userInput;
        }
        #endregion
        #region PaymentIsCash() returns decimal
        public decimal PaymentIsCash()
        {
            decimal userInput;
            Console.Clear();
            Console.WriteLine(cekiaiLogo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Kokia pinigų suma buvo atsiskaityta?");
            Console.ResetColor();
            Footer();
            while (!decimal.TryParse(Console.ReadLine(), out userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            return Math.Abs(userInput);
        }
        #endregion
        #region ViewCheque()
        public void ViewCheque()
        {
            // Padaryta konsultuojantis su ChatGPT

            Console.Clear();
            Console.WriteLine(cekiaiLogo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            ChequeNumber++;
            Console.WriteLine("Suformuotas čekis");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();

            int width = 43;

            var lines = new List<string>
    {
        "          UAB \"Skonio Lobiai\"          ",
        "       Upės g. 21, LT-08128 Vilnius      ",
        "    PVM mokėtojo kodas: LT100010548418   ",
        "                  KVITAS                 ",
        new string('-', width - 2),
        " Prekė                    | Vnt. | Vnt. kaina (eur) ",
        new string('-', width - 2)
    };

            foreach (var detail in OrderInfo)
            {
                lines.Add($"| {detail.Key,-30} | {detail.Value[0],3}  | {detail.Value[1],10}");
            }

            lines.Add(new string('-', width - 2));
            lines.Add($"| SUMA                            {CurrentTableSum,12:N2} eur  ");
            lines.Add(new string('-', width - 2));
            lines.Add(" Mokėjimas:                           ");
            string paymentType = PaymentMethod == 1 ? "Grynieji" : "Bankinė kortelė";
            lines.Add($"| {paymentType,-35}|");

            if (PaymentMethod == 1)
            {
                lines.Add($"|             Sumokėta: {CashAmount,10:N2} eur |");
                lines.Add($"|             Grąža:    {CashAmount - CurrentTableSum,10:N2} eur |");
            }

            lines.Add(new string('-', width - 2));
            lines.Add("      Skonio Lobiai – Meilė maistui      ");
            lines.Add(new string('-', width - 2));
            lines.Add($"| Suma be PVM:       {CurrentTableSum - (CurrentTableSum * 0.21m),10:N2} eur |");
            lines.Add($"| PVM(21%):          {CurrentTableSum * 0.21m,12:N2} eur |");
            lines.Add(new string('-', width - 2));
            lines.Add($"| Aptarnavo: {SelectedWaiter,-12} | Staliukas: {SelectedTable,-4} ");
            lines.Add($"| Data: {DateTime.Now:yyyy/MM/dd hh:mm:ss tt} | Kvito nr.: {ChequeNumber,4} |");
            lines.Add(new string('-', width - 2));
            lines.Add("       SKANIŲ SKONIO PRISIMINIMŲ!        ");

            width = lines.Max(line => line.Length);

            Console.WriteLine(new string('=', width));
            Console.WriteLine("|" + new string(' ', width - 2) + "|");
            foreach (var line in lines)
            {
                Console.WriteLine($"|{line.PadRight(width - 2)}|");
            }
            Console.WriteLine(new string('=', width));
            Console.ResetColor();

            WaiterTips =+ CurrentTableSum * 0.1m;
            TableEarnings =+ CurrentTableSum;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
            Console.ResetColor();
            Console.ReadKey();

            TableStatus[SelectedTable] = 2;
            FormedCheque = lines;
            CurrentTableSum = 0;
        }
        #endregion
        #region ChequePrintStatus()
        public void ChequePrintStatus()
        {
            if (FormedCheque == null)
            {
                Console.Clear();
                Console.WriteLine(cekiaiLogo);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Čekis nespausdintas!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{_emailService.SendEmail()}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
                Console.ResetColor();
                Console.ReadKey();
            }
            else if (MenuChoice == 1)
            {
                Console.Clear();
                Console.WriteLine(cekiaiLogo);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Čekis sėkmingai atspausdintas!");
                Console.WriteLine($"{_emailService.SendEmail()}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(cekiaiLogo);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Čekis nespausdintas!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{_emailService.SendEmail()}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        #endregion
        #region ToPrintCheque_OrNot_ToPrintCheque
        public void ToPrintCheque_OrNot_ToPrintCheque()
        {
            int userInput;
            Console.Clear();
            Console.WriteLine(cekiaiLogo);
            Console.WriteLine();
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("Ar spausdinti čekį klientui?");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#1 ");
            Console.ResetColor();
            Console.WriteLine("Taip");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#2 ");
            Console.ResetColor();
            Console.WriteLine("Ne");
            while (!int.TryParse(Console.ReadLine(), out userInput) && userInput != 1
                                                        && userInput != 2
                                                        && userInput != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            MenuChoice = userInput;
        }
        #endregion
    }
}
