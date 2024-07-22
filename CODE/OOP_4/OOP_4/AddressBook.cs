using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    public class AddressBook
    {
        public void AddContact(string path)
        {
            Console.Clear();
            Console.WriteLine("ADDING NEW CONTACT");
            Console.WriteLine("");
            string formatedContactInformation = null;
            var contact = new Contact();
            Console.Write("Add new contact's first name: ");
            contact.Name = Console.ReadLine();
            Console.Write("Add new contact's last name: ");
            contact.LastName = Console.ReadLine();
            Console.Write("Add new contact's phone number: ");
            contact.PhoneNumber = int.Parse(Console.ReadLine());
            Console.Write("Add new contact's email address");
            contact.Email = Console.ReadLine();
            // This is basic validation to enter correct details
            if (String.IsNullOrEmpty(contact.Name) ||
                String.IsNullOrEmpty(contact.LastName) ||
                String.IsNullOrEmpty(contact.Email) ||
                !contact.Email.Contains("@") ||
                contact.PhoneNumber < 100000000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Unacceptable information entered");
                Console.ResetColor();
            }
            else
            {
                formatedContactInformation += $"{contact.Name},{contact.LastName},{contact.PhoneNumber},{contact.Email}\n";
                File.AppendAllText(path, formatedContactInformation);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Contact has been added successfully!");
            Console.ResetColor();
        }
        public void ViewContacts(string path)
        {
            Console.Clear();
            Console.WriteLine("VIEWING CONTACTS");
            Console.WriteLine("");
            string[] addressBook = File.ReadAllLines(path);
            Console.WriteLine("FIRST NAME\t LAST NAME\t PHONE NUMBER\t EMAIL ADDRESS");
            foreach (string address in addressBook)
            {
                string[] tempContact = address.Split(",");
                Console.WriteLine("");
                Console.WriteLine($"{tempContact[0]}\t\t {tempContact[1]}\t\t {tempContact[2]}\t {tempContact[3]}");
            }
            Console.WriteLine("");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("END OF LIST DIPLAY");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
        public void DeleteContact(string path)
        {
            Console.Clear();
            Console.WriteLine("DELETE CONTACT");
            Console.WriteLine("");
            string[] addressBook = File.ReadAllLines(path);
            Console.WriteLine("FIRST NAME\t LAST NAME\t PHONE NUMBER\t EMAIL ADDRESS");
            foreach (string address in addressBook)
            {
                string[] tempContact = address.Split(",");
                Console.WriteLine("");
                Console.WriteLine($"{tempContact[0]}\t\t {tempContact[1]}\t\t {tempContact[2]}\t {tempContact[3]}");
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("END OF LIST DIPLAY");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("Enter contact's email in order to identify which one contact you wish to delete");
            string selectedEmail;
            selectedEmail = Console.ReadLine();
            foreach (string address in addressBook)
            {
                if (address[3] == selectedEmail)
                {

                }
            }
        }
        public void SearchContact()
        {

        }
    }
}
