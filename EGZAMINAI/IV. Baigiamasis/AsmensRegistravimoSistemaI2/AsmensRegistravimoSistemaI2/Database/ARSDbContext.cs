using AsmensRegistravimoSistemaI2.Database.InitialData;
using AsmensRegistravimoSistemaI2.Models;
using Microsoft.EntityFrameworkCore;

namespace AsmensRegistravimoSistemaI2.Database
{
    public class ARSDbContext(DbContextOptions<ARSDbContext> options) : DbContext(options)
    {
        public bool SkipSeeding { get; set; } = false;
        public DbSet<User> Users { get; set; }
        public DbSet<GeneralInformation> GeneralInfos { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!SkipSeeding)
            {
                modelBuilder.Entity<Address>()
                    .HasData(AddressesInitialData.Addresses);
                modelBuilder.Entity<GeneralInformation>()
                    .HasData(GeneralInformationInitialData.GeneralInfos);
                modelBuilder.Entity<User>()
                    .HasData(UsersInitialData.Users);
            }

            // User -> GeneralInformation relationship (one-to-one)
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserGeneralInformation)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            // GeneralInformation -> Address relationship (one-to-one)
            modelBuilder.Entity<GeneralInformation>()
                .HasOne(gi => gi.GIAddress)
                .WithOne()
                .HasForeignKey<GeneralInformation>(gi => gi.UserAddressId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
