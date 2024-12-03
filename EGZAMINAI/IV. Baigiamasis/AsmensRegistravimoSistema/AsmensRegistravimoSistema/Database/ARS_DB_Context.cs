using AsmensRegistravimoSistema.Models;
using Microsoft.EntityFrameworkCore;

namespace AsmensRegistravimoSistema.Database
{
    public class ARS_DB_Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UsersAddresses { get; set; }
        public DbSet<UserInformation> UsersInformation { get; set; }

        public ARS_DB_Context(DbContextOptions<ARS_DB_Context> options) : base(options) { }
    }
}
