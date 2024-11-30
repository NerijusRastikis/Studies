using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderExecutionService.Database;

namespace OrderExecutionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OESController : ControllerBase
    {
        private readonly ILogger<OESController> _logger;
        private readonly OrderExecutionDB _context;

        public OESController(ILogger<OESController> logger, OrderExecutionDB context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet("order/{orderId}/execution/{id}")]
        public IActionResult Get(int id, string orderId)
        {
            try
            {
                var selectedOrder = _context.OrderExecutions.FirstOrDefault(order => order.Id == id && order.OrderId == orderId);
                if (selectedOrder == null)
                {
                    return NotFound($"No match with orderId: {orderId} and Id: {id} was found.");
                }
                return Ok(selectedOrder);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error with either orderId: {orderId} or ith Id: {id}");
                return StatusCode(500, "Internal server error occured. Please try again later.");
            }
        }
    }
}
