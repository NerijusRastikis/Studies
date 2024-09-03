namespace DatabaseSeed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new BookContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Console.WriteLine("Database created");

            var books = context.Books.ToList();
            Console.WriteLine("------------------");
            Console.WriteLine("Books from Database");
            foreach (var book in books)
            {
                Console.WriteLine($"BookId:{book.BookId} Title:{book.Title} Year:{book.Year}");
            }
            var authors = context.Authors.ToList();
            Console.WriteLine("------------------");
            foreach (var author in authors)
            {
                Console.WriteLine($"AuthorId: {author.AuthorId} Full Name: {author.FullName} Country: {author.Country}");
            }
            // Cia reikia atvaizdavimo
        }
    }
}
