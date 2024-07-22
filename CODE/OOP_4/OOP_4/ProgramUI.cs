using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    public class ProgramUI
    {
        public void ShowMenu()
        {
            Console.Clear();
            Console.Beep();
            string theMenu = @"     M E N U

1. Add Contact
2. View Contacts
3. Delete COntact
4. Search Contact

5. Exit";
            int choice = 0;
            Console.WriteLine(theMenu);
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine(theMenu);
                Console.WriteLine("");
                Console.Write("Wrong selection! Please re-enter: ");
            }
            HandleUserChoice(choice);
        }
        public void HandleUserChoice(int choice)
        {
            string path = "C:\\Users\\nerij\\Documents\\GitHub\\dotnet\\OOP_4\\OOP_4\\contacts.csv";
            var contactManipulation = new AddressBook();
            switch (choice)
            {
                case 1:

                    contactManipulation.AddContact(path);
                    choice = 0;
                    ShowMenu();
                    break;
                case 2:
                    contactManipulation.ViewContacts(path);
                    choice = 0;
                    ShowMenu();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    // Beep() just for fun, was interested what does it do. Feel free to remove it if it gets annoying.
                    Console.Beep();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quitting...");
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;
                default:
                    choice = 0;
                    ShowMenu();
                    break;
            }

        }
    }
}
