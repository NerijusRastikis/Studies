using Microsoft.EntityFrameworkCore;
using RestoranasPOS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Services
{
    public class MenuContext : DbContext
    {
        public DbSet<MenuRepository> menus {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=RestoranasPOS;Trusted_Connection=True;");
        }
    }
}
