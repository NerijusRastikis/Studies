using OrderExecutionService.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementService.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string OrderId { get; set; }
        [Required]
        [Range(1, 20)]
        public string OrderName { get; set; }
        [Required]
        public string OrderDescription { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Range(0.0, 100)]
        public double Quantity { get; set; }
        public StatusType CurrentOrderExecutionStatus { get; set; } = StatusType.Pending;
    }
}
