using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Services
{
    public class Display
    {
        public string SelectedWaiter { get; set; }
        public string SelectedTable { get; set; }
        public decimal CurrentTableSum {  get; set; } 
        public int ArUzimtasStaliukas { get; set; }
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

        public void Header()
        {
            Console.Write(justLogo);
            Console.ReadKey();
        }
        #region SelectWaiter()
        public void SelectWaiter()
        {
            int waiterSelection = 0;
            string waiter1 = "Padavėjas 1";
            string waiter2 = "Padavėjas 2";
            string waiter3 = "Padavėjas 3";
            string waiter4 = "Padavėjas 4";

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
            if (ArUzimtasStaliukas == 0)
            {
                return "[UŽIMTAS]";
            }
            else if (ArUzimtasStaliukas == 1)
            {
                return "[REZERVUOTAS]";
            }
            else return "[LAISVAS]";
        }
        #region TableSelector()
        public void TableSelector()
        {
            int selectTable = 0;
            Console.Clear();
            Console.WriteLine(stalaiLogo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pasirinkite staliuką:");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor= ConsoleColor.Cyan;
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
            Console.WriteLine(CurrentTableSum);
            Console.ResetColor();

        }
        public int MainMenu()
        {
            while (true)
            {
                int userInput = 9;
                Console.Clear();
                Console.WriteLine(mainMenuLogo);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("#1 ");
                Console.ResetColor();
                Console.WriteLine("Pakeisti staliuką");
                Console.Write("#2 ");
                Console.ResetColor();
                Console.WriteLine("Pakeisti padavėją");
                Console.WriteLine();
                Console.Write("#3 ");
                Console.ResetColor();
                Console.WriteLine("Saskaitos peržiūra/apmokėjimas");
                Console.WriteLine();
                Console.Write("#0 ");
                Console.ResetColor();
                Console.WriteLine("Uždaryti programą");
                while (!int.TryParse(Console.ReadLine(), out userInput) && userInput != 1
                                                                        && userInput != 2
                                                                        && userInput != 3
                                                                        && userInput != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Tokio pasirinkimo nėra! ");
                    Console.ResetColor();
                    Console.Write("Pakartokite įvestį: ");
                }
            }
        }
        public void Start()
        {
            SelectWaiter();
            TableSelector();
            MainMenu();
        }
    }
}
