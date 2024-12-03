using AsmensRegistravimoSistemaI2.Models.ImageControllerModels;
using AsmensRegistravimoSistemaI2.Models.InformationControllerModels;
using AsmensRegistravimoSistemaI2.Models.UserControllerModels;
using Microsoft.EntityFrameworkCore;

namespace AsmensRegistravimoSistemaI2.Database
{
    public class ARSDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<GeneralInformation> GeneralInfos { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public ARSDbContext(DbContextOptions<ARSDbContext> options) : base(options) { }
    }
}
