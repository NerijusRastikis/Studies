using Microsoft.VisualStudio.TestTools.UnitTesting;
using P003.Database;
using P003.Enums;
using P003.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static P003.Models.Book;

namespace P003.Database.Tests
{
    [TestClass()]
    public class BooksFakeInMemoryDatabaseTests
    {
        BooksFakeInMemoryDatabase _db;

        [TestInitialize]
        public void Setup()
        {
            _db = new BooksFakeInMemoryDatabase();
        }
        [TestMethod()]
        public void GetAllBooksTest()
        {
            //ACT
            var books = _db.GetAllBooks();
            //ASSERT
            Assert.AreEqual(15, books.Count);
        }

        [TestMethod]
        public void GetBook_WithInvalidId_ShouldReturnNull()
        {
            // ARRANGE
            int invalidId = 100;

            // ACT
            var book = _db.GetBook(invalidId);

            // ASSERT
            Assert.IsNull(book);
        }

        [TestMethod]
        public void GetBookTest_WithCorrectValues()
        {
            //ARRANGE
            int bookId = 1;
            //ACT
            var book = _db.GetBook(bookId);
            //ASSERT
            Assert.IsNotNull(book);
            Assert.AreEqual("Dune", book.Title);
        }

        [TestMethod]
        public void AddBookTest()
        {
            //ARRANGE
            var bookToTest = new Book { Id = 16, Title = "Test", Author = "Test", Cover = CoverType.Hard };
            //ACT
            _db.AddBook(bookToTest);
            var newBookCount = _db.GetAllBooks().Count();
            //ASSERT
            Assert.AreEqual(16, newBookCount);
        }

        [TestMethod()]
        public void UpdateBookTest_WithCorrectValues()
        {
            //ARRANGE
            var newBook = new Book { Id = 1, Title = "Updated Dune", Author = "Frank Herbert", Cover = CoverType.Hard };
            var initialBook = _db.GetBook(1);
            //ACT
            _db.UpdateBook(newBook);
            var updatedBook = _db.GetBook(1);
            //ASSERT
            Assert.AreNotEqual(initialBook.Title, updatedBook.Title);
        }
        [TestMethod()]
        public void UpdateBookTest_WithIncorrectValues()
        {
            //ARRANGE
            var newBook = new Book { Id = 100, Title = "Test", Author = "Test", Cover = CoverType.Hard };
            var initialListOfBooks = _db.GetAllBooks();
            //ACT
            _db.UpdateBook(newBook);
            var updatedListOfBooks = _db.GetAllBooks();
            //ASSERT
            CollectionAssert.AreEqual(initialListOfBooks, updatedListOfBooks);
        }

        [TestMethod()]
        public void DeleteBookTest_CorrectId()
        {
            //ACT
            _db.DeleteBook(1);
            //ASSERT
            Assert.AreEqual(14, _db.GetAllBooks().Count);
        }
        [TestMethod()]
        public void DeleteBookTest_IncorrectId()
        {
            //ACT
            _db.DeleteBook(100);
            //ASSERT
            Assert.AreEqual(15, _db.GetAllBooks().Count);
        }
    }
}