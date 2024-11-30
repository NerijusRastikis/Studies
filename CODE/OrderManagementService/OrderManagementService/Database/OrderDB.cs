using Microsoft.EntityFrameworkCore;
using OrderManagementService.Models;

namespace OrderManagementService.Database
{
    public class OrderDB : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderDB(DbContextOptions<OrderDB> options) : base(options) { }
    }
}
