using ManyToMany.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany.Services
{
    public static class CsvHelper
    {
        public static List<Book> GetBooks()
        {
            var books = new List<Book>();
            string path = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\DatabaseSeed\\ManyToMany\\Files\\Books.csv";
            var bookLines = File.ReadAllLines(path);
            foreach (var line in bookLines)
            {
                var capturedLine = line.Split(',');

                var bookId = int.Parse(capturedLine[0]);
                var name = capturedLine[1];
                var year = int.Parse(capturedLine[2]);
                books.Add(new Book { BookId = bookId, Name = name, Year = year });
            }
            return books;
        }
        public static List<Category> GetCategories()
        {
            var categories = new List<Category>();
            string path = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\DatabaseSeed\\ManyToMany\\Files\\Category.csv";
            var categoriesLines = File.ReadAllLines(path);
            foreach (var line in categoriesLines)
            {
                var capturedLine = line.Split(',');

                var categoryId = int.Parse(capturedLine[0]);
                var name = capturedLine[1];
                categories.Add(new Category { CategoryId = categoryId, Name = name });
            }
            return categories;
        }
        public static List<Author> GetAuthors()
        {
            var authors = new List<Author>();
            string path = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\DatabaseSeed\\ManyToMany\\Files\\Authors.csv";
            var authorsLines = File.ReadAllLines(path);
            foreach (var line in authorsLines)
            {
                var capturedLine = line.Split(',');

                var authorId = int.Parse(capturedLine[0]);
                var firstName = capturedLine[1];
                var lastName = capturedLine[2];
                authors.Add(new Author { AuthorId = authorId, FirstName = firstName, LastName = lastName });
            }
            return authors;
        }
        public static List<Chapter> GetChapters()
        {
            var chapters = new List<Chapter>();
            string path = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\DatabaseSeed\\ManyToMany\\Files\\Chapters.csv";
            var chaptersLines = File.ReadAllLines(path);
            foreach (var line in chaptersLines)
            {
                var capturedLine = line.Split(',');

                var chapterId = int.Parse(capturedLine[0]);
                var name = capturedLine[1];
                chapters.Add(new Chapter { ChapterId = chapterId, Name = name });
            }
            return chapters;
        }
    }
}
