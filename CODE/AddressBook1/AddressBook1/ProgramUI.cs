using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook1
{
    internal class ProgramUI
    {
        public int ShowMenu()
        {
            int choice;
            string mainMenu = @"M E N U

1. Pridėti kontaktą
2. Peržiūrėti kontaktus
3. Ištrinti kontaktą
4. Ieškoti kontakto

0. Išeiti";
            Console.WriteLine(mainMenu);
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WRONG INPUT!");
                Console.ResetColor();
                Console.WriteLine(choice);
            }
            return choice;
        }
        public void HandleUserChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("<> PRIDETI KONTAKTĄ <>");
                    Console.WriteLine();

                    ShowMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("<> PERŽIŪRĖTI KONTAKTUS <>");
                    Console.WriteLine();

                    ShowMenu();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("<> IŠTRINTI KONTAKTĄ <>");

                    ShowMenu();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("<> IEŠKOTI KONTAKTO <>");

                    ShowMenu();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Adresų knyga uždaroma...");
                    Environment.Exit(0);
                    break;
                default:
                    choice = 9;
                    ShowMenu();
                    break;
            }

        }
    }
}