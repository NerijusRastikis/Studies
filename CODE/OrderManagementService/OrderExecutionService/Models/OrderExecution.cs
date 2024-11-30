using OrderExecutionService.Enums;

namespace OrderExecutionService.Models
{
    public class OrderExecution
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public List<Order> Orders { get; set; }
        public DateTime ExecutionDate { get; set; }
        public Enums.StatusType CurrentOrderExecutionStatus { get; set; }
    }
}
