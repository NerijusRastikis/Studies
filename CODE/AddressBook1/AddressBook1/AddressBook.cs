using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook1
{
    internal class AddressBook
    {
        public AddressBook(string _path)
        {
            _Path = _path;
        }
        public string _Path { get; set; }
        public string AddContact()
        {
            var contact = new Contact();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            while (name == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WRONG INPUT! Name cannot be empty!");
                Console.ResetColor();
                Console.Write("Enter Name: ");
                name = Console.ReadLine();
            }
            contact.Name = name;
            Console.Write("Enter Surname: ");
            string lastName = Console.ReadLine();
            while (lastName == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WRONG INPUT! Surname cannot be empty!");
                Console.ResetColor();
                Console.Write("Enter Surname: ");
                lastName = Console.ReadLine();
            }
            contact.Surname = lastName;
            Console.Write("Enter Phone number: ");
            int phone = 0;
            while (!int.TryParse(Console.ReadLine(), out phone) && phone.ToString().Length < 9)
            {
                if (phone.ToString().Length < 9)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("WRONG INPUT! Phone number consists of at least 9 numbers!");
                    Console.ResetColor();
                    Console.Write("Enter Phone number: ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WRONG INPUT! Phone number should consist only from numeric values!");
                    Console.ResetColor();
                    Console.Write("Enter Phone number: ");
                }
            }
            contact.PhoneNumber = phone;
            Console.Write("Enter Email address: ");
            string email;
            email = Console.ReadLine();
            while (String.IsNullOrEmpty(email) && (!email.Contains('@') && !email.Contains('.')))
            {
                if (!email.Contains('@') && !email.Contains('.'))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WRONG INPUT! Incorrect email format (missing \"@\" or \".\"!");
                    Console.ResetColor();
                    email = Console.ReadLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WRONG INPUT! Email address cannot be empty!");
                    Console.ResetColor();
                    email = Console.ReadLine();
                }
            }
            return $"{contact.Name},{contact.Surname},{contact.PhoneNumber},{contact.Email}";
        }
        public void ViewContacts()
        {
            var file = new FileManagement(_Path);
            file.ReadFromFile();
        }
        public void DeleteContact()
        {

        }
        public void SearchContact()
        {

        }
    }
}
