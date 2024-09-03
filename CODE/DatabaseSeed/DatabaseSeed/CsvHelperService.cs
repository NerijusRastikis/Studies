using DatabaseSeed.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSeed
{
    public static class CsvHelperService
    {
        public static List<Book> GetBooks()
        {
            var book = new List<Book>();
            string path = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\DatabaseSeed\\DatabaseSeed\\Books.csv";
            var bookLines = File.ReadAllLines(path);
            foreach (var line in bookLines)
            {
                var capturedLine = line.Split(',');

                var bookId = int.Parse(capturedLine[0]);
                var title = capturedLine[1];
                var year = int.Parse(capturedLine[2]);
                book.Add(new Book { BookId = bookId, Title = title, Year = year, GenreId = int.Parse(capturedLine[3]), PublisherId = int.Parse(capturedLine[4]) });
            }
            return book;
        }
        public static List<Author> GetAuthors()
        {
            var authorList = new List<Author>();
            string path = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\DatabaseSeed\\DatabaseSeed\\Authors.csv";
            var authorLines = File.ReadAllLines(path);
            foreach ( var line in authorLines)
            {
                var capturedLine = line.Split(",");

                var authorId = int.Parse(capturedLine[0]);
                var fullName = capturedLine[1];
                var bookId = int.Parse(capturedLine[3]);
                authorList.Add(new Author { AuthorId = authorId, FullName = fullName, BookId = bookId, CountryId = int.Parse(capturedLine[2])});
            }
            return authorList;
        }
        public static List<Country> GetCountries()
        {
            string pathCountry = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\DatabaseSeed\\DatabaseSeed\\Countries.csv";
            var capturedCountryLines = File.ReadAllLines(pathCountry);
            var countries = new List<Country>();
            foreach (var line in capturedCountryLines)
            {
                var splitLine = line.Split(",");
                countries.Add(new Country { CountryId = int.Parse(splitLine[0]), Name = splitLine[1] });
            }
            return countries;
        }
        public static List<Publisher> GetPublishers()
        {
            string pathPublisher = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\DatabaseSeed\\DatabaseSeed\\Publishers.csv";
            var capturedPublisherLines = File.ReadAllLines(pathPublisher);
            var publishers = new List<Publisher>();
            foreach (var line in capturedPublisherLines)
            {
                var splitLine = line.Split(',');
                publishers.Add(new Publisher { PublisherId = int.Parse(splitLine[0]), Name=splitLine[1] });
            }
            return publishers;
        }
        public static List<Genre> GetGenres()
        {
            string pathGenre = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\DatabaseSeed\\DatabaseSeed\\Genre.csv";
            var capturedGenreLines = File.ReadAllLines(pathGenre);
            var genres = new List<Genre>();
            foreach (string line in capturedGenreLines)
            {
                var splitLine = line.Split(",");
                genres.Add(new Genre { GenreId = int.Parse(splitLine[0]), Name = splitLine[1] });
            }
            return genres;
        }
    }
}