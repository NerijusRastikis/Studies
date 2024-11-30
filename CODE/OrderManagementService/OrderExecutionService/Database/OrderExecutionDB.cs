using Microsoft.EntityFrameworkCore;
using OrderExecutionService.Models;

namespace OrderExecutionService.Database
{
    public class OrderExecutionDB : DbContext
    {
        public DbSet<OrderExecution> OrderExecutions { get; set; }

        public OrderExecutionDB(DbContextOptions<OrderExecutionDB> options) : base(options) { }
    }
}
