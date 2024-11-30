using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {



        }

        //onModelCreating
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = new Guid("1"), Name = "Sci-fi" },
                new Genre { Id = new Guid("2"), Name = "Fantasy" },
                new Genre { Id = new Guid("3"), Name = "Mystery" },
                new Genre { Id = new Guid("4"), Name = "Romance" },
                new Genre { Id = new Guid("5"), Name = "Horror" },
                new Genre { Id = new Guid("6"), Name = "Thriller" },
                new Genre { Id = new Guid("7"), Name = "Western" },
                new Genre { Id = new Guid("8"), Name = "Dystopian" },
                new Genre { Id = new Guid("9"), Name = "Memoir" },
                new Genre { Id = new Guid("10"), Name = "Biography" });

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = new Guid("1"), FirstName = "Isaac", LastName = "Asimov", Country = "USA" },
                new Author { Id = new Guid("2"), FirstName = "Arthur", LastName = "Clarke", Country = "UK" },
                new Author { Id = new Guid("3"), FirstName = "Frank", LastName = "Herbert", Country = "USA" },
                new Author { Id = new Guid("4"), FirstName = "Philip", LastName = "Dick", Country = "USA" },
                new Author { Id = new Guid("5"), FirstName = "Ursula", LastName = "Le Guin", Country = "USA" },
                new Author { Id = new Guid("6"), FirstName = "Ray", LastName = "Bradbury", Country = "USA" },
                new Author { Id = new Guid("7"), FirstName = "H.G.", LastName = "Wells", Country = "UK" },
                new Author { Id = new Guid("8"), FirstName = "Robert", LastName = "Heinlein", Country = "USA" },
                new Author { Id = new Guid("9"), FirstName = "Margaret", LastName = "Atwood", Country = "Canada" },
                new Author { Id = new Guid("10"), FirstName = "Kim", LastName = "Robinson", Country = "USA" });

            modelBuilder.Entity<Book>().HasData(new Book
    {
        Id = new Guid("1"),
        Title = "Foundation",
        GenreId = new Guid("1"),
        Pages = 255,
        Year = 1951,
        ISBN = "978-0553293357"
    },
    new Book
    {
        Id = new Guid("2"),
        Title = "2001: A Space Odyssey",
        GenreId = new Guid("1"),
        Pages = 297,
        Year = 1968,
        ISBN = "978-0451457998"
    },
    new Book
    {
        Id = new Guid("3"),
        Title = "Dune",
        GenreId = new Guid("1"),
        Pages = 412,
        Year = 1965,
        ISBN = "978-0441172719"
    },
    new Book
    {
        Id = new Guid("4"),
        Title = "Do Androids Dream of Electric Sheep?",
        GenreId = new Guid("1"),
        Pages = 210,
        Year = 1968,
        ISBN = "978-0345404473"
    },
    new Book
    {
        Id = new Guid("5"),
        Title = "The Left Hand of Darkness",
        GenreId = new Guid("1"),
        Pages = 304,
        Year = 1969,
        ISBN = "978-0441478125"
    },
    new Book
    {
        Id = new Guid("6"),
        Title = "Fahrenheit 451",
        GenreId = new Guid("1"),
        Pages = 194,
        Year = 1953,
        ISBN = "978-1451673319"
    },
    new Book
    {
        Id = new Guid("7"),
        Title = "The War of the Worlds",
        GenreId = new Guid("1"),
        Pages = 192,
        Year = 1898,
        ISBN = "978-0451530653"
    },
    new Book
    {
        Id = new Guid("8"),
        Title = "Stranger in a Strange Land",
        GenreId = new Guid("1"),
        Pages = 408,
        Year = 1961,
        ISBN = "978-0441790340"
    },
    new Book
    {
        Id = new Guid("9"),
        Title = "The Handmaid's Tale",
        GenreId = new Guid("1"),
        Pages = 311,
        Year = 1985,
        ISBN = "978-0385490818"
    },
    new Book
    {
        Id = new Guid("10"),
        Title = "Red Mars",
        GenreId = new Guid("1"),
        Pages = 572,
        Year = 1993,
        ISBN = "978-0553560732"
    }
);

        }
    }

}
