using AsmensRegistravimoSistemaI2.Database.InitialData;
using AsmensRegistravimoSistemaI2.Models.ImageControllerModels;
using AsmensRegistravimoSistemaI2.Models.InformationControllerModels;
using AsmensRegistravimoSistemaI2.Models.UserControllerModels;
using Microsoft.EntityFrameworkCore;

namespace AsmensRegistravimoSistemaI2.Database
{
    public class ARSDbContext(DbContextOptions<ARSDbContext> options) : DbContext(options)
    {
        public bool SkipSeeding { get; set; } = false;
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<GeneralInformation> GeneralInfos { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!SkipSeeding)
            {
                modelBuilder.Entity<User>()
                .HasData(UsersInitialData.Users);
                modelBuilder.Entity<Image>()
                    .HasData(ImagesInitialData.Images);
                modelBuilder.Entity<GeneralInformation>()
                    .HasData(GeneralInformationInitialData.GeneralInfos);
                modelBuilder.Entity<Address>()
                    .HasData(AddressesInitialData.Addresses);
            }
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserGeneralInformation)
                .WithOne(gi => gi.User)
                .HasForeignKey<GeneralInformation>(gi => gi.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GeneralInformation>()
                .HasOne(a => a.UserAddress)
                .WithOne(b => b.UserGeneralInformation)
                .HasForeignKey<GeneralInformation>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Image>()
                .HasOne(a => a.User)
                .WithOne(b => b.UserImage)
                .HasForeignKey<Image>(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
