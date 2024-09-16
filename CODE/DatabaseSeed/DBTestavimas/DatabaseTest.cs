using ManyToMany;
using ManyToMany.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBTestavimas
{
    [TestClass]
    public class DatabaseTests
    {
        private BookContext _context;
        private DbContextOptions<BookContext> _options;


        [TestInitialize]
        public void OnInit()
        {
            _options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "BookListDatabase" + Guid.NewGuid())
                .Options;
            _context = new BookContext(_options);
            BookContext.IsSeeding = true;
            _context.Database.EnsureCreated();
        }

        [TestCleanup]
        public void OnExit()
        {
            _context.Database.EnsureDeleted();
        }


        [TestMethod]
        public void WhenBookAdded_ShouldReturnBook()
        {
            // Arrange
            var book = new Book { Name = "Fondation", Year = 1951 };
            _context.Books.Add(book);
            _context.SaveChanges();

            // Act
            var fondation = _context.Books.FirstOrDefault(b => b.Name == "Fondation");

            // Assert
            Assert.IsNotNull(fondation);
            Assert.AreNotEqual(1, fondation.BookId);

        }

        [TestMethod]
        public void DataSeed_ShouldReturnBooks()
        {
            // Arrange
            // Act
            var books = _context.Books.ToList();

            // Assert
            Assert.AreEqual(7, books.Count);
        }
    }
}