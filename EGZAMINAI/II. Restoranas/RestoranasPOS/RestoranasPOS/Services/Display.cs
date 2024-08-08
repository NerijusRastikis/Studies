using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoranasPOS.Interfaces;

namespace RestoranasPOS.Services
{
    public class Display : PrintCheque, IDisplay
    {
        public string? SelectedWaiter { get; set; }
        public string? SelectedTable { get; set; }
        public decimal CurrentTableSum { get; set; }
        public Dictionary<string, List<decimal>> OrderInfo { get; set; }
        public Dictionary<string, int> TableStatus { get; set; }
        public List <string> ClientInfo { get; set; }
        public int PaymentMethod { get; set; }
        public int ChequeNumber { get; set; }
        public decimal CashAmount { get; set; }
        public int MenuChoice {  get; set; }

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
            while (int.TryParse(Console.ReadLine(), out waiterSelection) && waiterSelection != 1
                                                                         && waiterSelection != 2
                                                                         && waiterSelection != 3
                                                                         && waiterSelection != 4)
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
        public string IsTableTaken()
        {
            if (TableStatus == null)
            {
                return "[LAISVAS]";
            }
            else
            {
                foreach (var table in TableStatus)
                {
                    if (table.Value == 0)
                    {
                        return "[UŽIMTAS]";
                    }
                    else if (table.Value == 1)
                    {
                        return "[REZERVUOTAS]";
                    }
                    else return "[LAISVAS]";
                }
                return "[LAISVAS]";
            }
        }

        #region PrintTableList()
        public void PrintTableList()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#1 ");
            Console.ResetColor();
            Console.Write("Staliukas ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("(4-vietis) ");
            if (IsTableTaken() == "[LAISVAS]")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (IsTableTaken() == "[REZERVUOTAS]")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(IsTableTaken());
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#2 ");
            Console.ResetColor();
            Console.Write("Staliukas ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("(2-vietis) ");
            if (IsTableTaken() == "[LAISVAS]")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (IsTableTaken() == "[REZERVUOTAS]")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(IsTableTaken());
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#3 ");
            Console.ResetColor();
            Console.Write("Staliukas ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("(2-vietis) ");
            if (IsTableTaken() == "[LAISVAS]")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (IsTableTaken() == "[REZERVUOTAS]")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(IsTableTaken());
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#4 ");
            Console.ResetColor();
            Console.Write("Staliukas ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"(4-vietis) ");
            if (IsTableTaken() == "[LAISVAS]")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (IsTableTaken() == "[REZERVUOTAS]")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(IsTableTaken());
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#5 ");
            Console.ResetColor();
            Console.Write("Staliukas ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"(6-vietis) ");
            if (IsTableTaken() == "[LAISVAS]")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (IsTableTaken() == "[REZERVUOTAS]")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(IsTableTaken());
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("#6 ");
            Console.ResetColor();
            Console.Write("Staliukas ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"(8-vietis) ");
            if (IsTableTaken() == "[LAISVAS]")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (IsTableTaken() == "[REZERVUOTAS]")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(IsTableTaken());
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
            Console.WriteLine("Pasirinkite staliuką:");
            Console.WriteLine();
            Console.ResetColor();
            PrintTableList();
            while (!int.TryParse(Console.ReadLine(), out selectTable))
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
        }
        #endregion

        #region TakeOrder_SelectCategory()
        public void TakeOrder_SelectCategory()
        {
            OrderInfo = new Dictionary<string, List<decimal>>();
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
            while (!int.TryParse(Console.ReadLine(), out userInput) && userInput < 0
                                                                    && userInput > iterator)
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
                    List<decimal> orderList = new List<decimal> { quantity, nonalkos.ElementAt(userInput).Value };
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
            int iterator = 0;
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
            while (!int.TryParse(Console.ReadLine(), out userInput) && userInput < 0
                                                                    && userInput > iterator)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pasirinktas: ");
            Console.ResetColor();
            Console.WriteLine($"{alkos.ElementAt(userInput).Key}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Įveskite kiekį: ");
            Console.ResetColor();
            while (int.TryParse(Console.ReadLine(), out quantity))
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
                List<decimal> orderList = new List<decimal> { quantity, alkos.ElementAt(userInput).Value };
                OrderInfo.Add(alkos.ElementAt(userInput).Key, orderList);
                CurrentTableSum += (decimal.Parse(alkos.ElementAt(userInput).Key) * quantity);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OPERACIJA SĖKMINGA!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
                Console.ResetColor();
                Console.ReadKey();
            }
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
            int iterator = 0;
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
            while (!int.TryParse(Console.ReadLine(), out userInput) && userInput < 0
                                                                    && userInput > iterator)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pasirinktas: ");
            Console.ResetColor();
            Console.WriteLine($"{snacks.ElementAt(userInput).Key}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Įveskite kiekį: ");
            Console.ResetColor();
            while (int.TryParse(Console.ReadLine(), out quantity))
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
                List<decimal> orderList = new List<decimal> { quantity, snacks.ElementAt(userInput).Value };
                OrderInfo.Add(snacks.ElementAt(userInput).Key, orderList);
                CurrentTableSum += (decimal.Parse(snacks.ElementAt(userInput).Key) * quantity);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OPERACIJA SĖKMINGA!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
                Console.ResetColor();
                Console.ReadKey();
            }
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
            int iterator = 0;
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
            while (!int.TryParse(Console.ReadLine(), out userInput) && userInput < 0
                                                                    && userInput > iterator)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pasirinktas: ");
            Console.ResetColor();
            Console.WriteLine($"{colds.ElementAt(userInput).Key}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Įveskite kiekį: ");
            Console.ResetColor();
            while (int.TryParse(Console.ReadLine(), out quantity))
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
                List<decimal> orderList = new List<decimal> { quantity, colds.ElementAt(userInput).Value };
                OrderInfo.Add(colds.ElementAt(userInput).Key, orderList);
                CurrentTableSum += (decimal.Parse(colds.ElementAt(userInput).Key) * quantity);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OPERACIJA SĖKMINGA!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
                Console.ResetColor();
                Console.ReadKey();
            }
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
            int iterator = 0;
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
            while (!int.TryParse(Console.ReadLine(), out userInput) && userInput < 0
                                                                    && userInput > iterator)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pasirinktas: ");
            Console.ResetColor();
            Console.WriteLine($"{hots.ElementAt(userInput).Key}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Įveskite kiekį: ");
            Console.ResetColor();
            while (int.TryParse(Console.ReadLine(), out quantity))
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
                List<decimal> orderList = new List<decimal> { quantity, hots.ElementAt(userInput).Value };
                OrderInfo.Add(hots.ElementAt(userInput).Key, orderList);
                CurrentTableSum += (decimal.Parse(hots.ElementAt(userInput).Key) * quantity);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OPERACIJA SĖKMINGA!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
                Console.ResetColor();
                Console.ReadKey();
            }
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
            while (!int.TryParse(Console.ReadLine(), out userInput) && userInput != 1
                                                                    && userInput != 2
                                                                    && userInput != 3
                                                                    && userInput != 4
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
        #region Exit()
        public void Exit()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Ar tikrai norite išeiti? (y/n): ");
            Console.ResetColor();
            if (Console.ReadLine() == "y")
            {
                MenuChoice = 0;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("IŠEINAMA...");
                Console.ResetColor();
                Environment.Exit(0);
            }
            else MenuChoice = 9;
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("#0 ");
            Console.ResetColor();
            Console.WriteLine("Grįžti");
            while (!int.TryParse(Console.ReadLine(), out userInput) && userInput != 1
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
        #region ReserveTable()
        public void ReserveTable()
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
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti...");
            Console.ResetColor();
            Console.ReadKey();
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
            while (!int.TryParse(Console.ReadLine(), out userInput) && userInput != 1
                                                                    && userInput != 2
                                                                    && userInput != 0)
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
            foreach (var detail in OrderInfo)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"#{iterator} ");
                Console.ResetColor();
                Console.Write($"{detail.Key} ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("x");
                Console.ResetColor();
                Console.WriteLine($"{detail.Value}");
                iterator++;
            }
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
            while (!int.TryParse(Console.ReadLine(), out userInput) && userInput != 1
                                                                    && userInput != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
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
            while (!int.TryParse(Console.ReadLine(), out userInput) && userInput != 1
                                                                    && userInput != 2
                                                                    && userInput != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Tokio pasirinkimo nėra! ");
                Console.ResetColor();
                Console.Write("Pakartokite įvestį: ");
            }
            if (userInput == 2)
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
            Console.Clear();
            Console.WriteLine(cekiaiLogo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            ChequeNumber++;
            Console.WriteLine("Suformuotas čekis");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();

            Console.WriteLine("___________________________________________");
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|          UAB \"Skonio Lobiai\"          |");
            Console.WriteLine("|       Upės g. 21, LT-08128 Vilnius      |");
            Console.WriteLine("|    PVM mokėtojo kodas: LT100010548418   |");
            Console.WriteLine("|                  KVITAS                 |");
            Console.WriteLine("|    Prekė   |   Vnt.  | Vnt. kaina (eur) |");
            foreach (var detail in OrderInfo)
            {
                Console.WriteLine($"|{detail.Key}\t{detail.Value[0]}\t{detail.Value[1]}|");

            }
            Console.WriteLine($"|   SUMA             {CurrentTableSum}eur|");
            Console.WriteLine("|   Mokėjimas:                           |");
            string paymentType;
            if (PaymentMethod == 1)
            {
                paymentType = "Grynieji";
            }
            else
            {
                paymentType = "Bankinė kortelė";
            }
            Console.WriteLine($"|   {paymentType}:          |");
            if (PaymentMethod == 2)
            {
                Console.WriteLine($"|             Sumokėta: {CashAmount} eur|");
                Console.WriteLine($"|             Grąža: {CashAmount - CurrentTableSum} eur|");
            }
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|      Skonio Lobiai – Meilė maistui      |");
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine($"|Suma be PVM: {CurrentTableSum - (CurrentTableSum * 0.21m)} eur       |");
            Console.WriteLine($"|PVM(21%): {CurrentTableSum * 0.21m} eur                                  |");
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine($"|Aptarnavo: {SelectedWaiter} | Staliukas: {SelectedTable}|");
            Console.WriteLine($"|Data: {DateTime.Now} | Kvito nr.: {ChequeNumber}|");
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|       SKANIŲ SKONIO PRISIMINIMŲ!        |");
            Console.WriteLine("|_________________________________________|");
            Console.ResetColor();
        }
        #endregion
    }
}
