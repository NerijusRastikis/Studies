using Microsoft.EntityFrameworkCore;
using P003.Models;

namespace P003.Database
{
    public class BooksDatabase : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public BooksDatabase(DbContextOptions<BooksDatabase> options) : base(options) { }
    }
}
