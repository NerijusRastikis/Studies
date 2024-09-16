using Apartments.Configuration;
using Apartments.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments
{
    public class ApartmentsContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Place> Places { get; set; }

        public ApartmentsContext() : base() { }
        public ApartmentsContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=ApartmentsTask;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new FacilitiesConfiguration());
            modelBuilder.ApplyConfiguration(new InstitutionConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceConfiguration());
            modelBuilder.ApplyConfiguration(new ServicesConfiguration());

            modelBuilder.Entity<Services>().HasData
                (
                    new Services
                    {
                        ServicesId = 1,
                        Title = "Zadintuvas ryte",
                        Price = 3.50m
                    },
                    new Services
                    {
                        ServicesId = 2,
                        Title = "Maistas i kambari",
                        Price = 10m
                    },
                    new Services
                    {
                        ServicesId = 3,
                        Title = "Masazas",
                        Price = 50m
                    },
                    new Services
                    {
                        ServicesId = 4,
                        Title = "Papildomas (vizito metu) kambario tvarkymas",
                        Price = 35m
                    },
                    new Services
                    {
                        ServicesId = 5,
                        Title = "Stalo zaidimu komplekto pristatymas i kambari",
                        Price = 15m
                    },
                    new Services
                    {
                        ServicesId = 6,
                        Title = "Papildoma isskleidziama lova (ugiui iki 150 cm)",
                        Price = 20m
                    }
                );
            modelBuilder.Entity<Facilities>().HasData
                (
                    new Facilities
                    {
                        FacilitiesId = 1,
                        Title = "Dusas"
                    },
                    new Facilities
                    {
                        FacilitiesId = 2,
                        Title = "Internetas"
                    },
                    new Facilities
                    {
                        FacilitiesId = 3,
                        Title = "Papildoma patalyne"
                    },
                    new Facilities
                    {
                        FacilitiesId = 4,
                        Title = "Alkoholinis bariukas"
                    },
                    new Facilities
                    {
                        FacilitiesId= 5,
                        Title = "Saldumynu bariukas"
                    }
                );
        }
    }
}
