using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    internal class Library
    {
        public List<string> Books { get; set; }
        public List<Book> Publication {  get; set; }
        public List<Book> AddBooks(string userInput)
        {
            var listOfBooks = new List<Book>();
            listOfBooks.Add(new Book(userInput));
            return listOfBooks;
        }
        public List<Book> DeleteBooks(string userInput, List<Book> listOfBooks)
        {
            Book bookToRemove = null;
            foreach (var book in listOfBooks)
            {
                if (book.Name == userInput)
                {
                    bookToRemove = book;
                    break;
                }
            }

            if (bookToRemove != null)
            {
                listOfBooks.Remove(bookToRemove);
            }

            return listOfBooks;
        }
        public void PrintBooks()
        {
            var listOfBooks = new List<Book>();
            foreach (var book in listOfBooks)
            {
                Console.WriteLine($"{book} | ");
            }
        }
    }
}
