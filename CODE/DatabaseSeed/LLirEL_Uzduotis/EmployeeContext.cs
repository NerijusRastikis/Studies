using LLirEL_Uzduotis.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLirEL_Uzduotis
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base() { }
        public EmployeeContext(DbContextOptions options) : base(options) { }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Project> Projects { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=EagerLoadingUzduotis;Trusted_Connection=True;");
            }
        }
    }
}
