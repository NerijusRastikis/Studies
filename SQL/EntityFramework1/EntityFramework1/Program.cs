using EntityFramework1.Entities;

namespace EntityFramework1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hobbit = new Book
            {
                Title = "Hobbit",
                Pages = 300,
                Year = 1937,
                Price = 10.99m
            };
            using (var context = new BookContext())
            {
                context.Books.Add(hobbit);
                context.SaveChanges();
            }
        }
    }
}
