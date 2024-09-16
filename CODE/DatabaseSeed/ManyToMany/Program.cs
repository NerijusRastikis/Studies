using ManyToMany.Entities;

namespace ManyToMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new BookContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            var adventure = new Category { Name = "Adventure" };
            var scienceFiction = new Category { Name = "Science Fiction" };
            var fantasy = new Category { Name = "Fantasy" };

            context.Categories.AddRange(adventure, scienceFiction, fantasy);
            context.SaveChanges();

            var hobbit = new Book { Name = "Hobbit", Year = 1937, Categories = { adventure, fantasy } };
            var lordOfTheRings = new Book { Name = "Lord of the Rings", Year = 1954 };
            var silmarillion = new Book { Name = "Silmarillion", Year = 1977 };
            var hitchhikersGuide = new Book { Name = "Hirchkiger's Guide to the Galaxy", Year = 1999, Categories = { adventure, scienceFiction, fantasy } };
            var dune = new Book { Name = "Dune", Year = 1965, Categories = { scienceFiction } };
            var duneHouseOfAtreides = new Book { Name = "Dune: House of Atreides", Year = 1999 };
            var duneTheButlerianJihad = new Book { Name = "Dune: The Butlerian Jihad", Year = 2002 };

            context.Books.AddRange(hobbit, lordOfTheRings, silmarillion, hitchhikersGuide, dune, duneHouseOfAtreides, duneTheButlerianJihad);
            context.SaveChanges();
        }
    }
}
