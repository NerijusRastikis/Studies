using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementService.Attributes;
using OrderManagementService.Database;
using OrderManagementService.Models;

namespace OrderManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiKeyAuth]
    [ApiController]
    public class OMSController : ControllerBase
    {
        private readonly OrderDB _context;
        private readonly ILogger<OMSController> _logger;

        public OMSController(OrderDB context, ILogger<OMSController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet("orders/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Order ID must be a positive number.");
                }

                var order = _context.Orders.FirstOrDefault(a => a.Id == id);

                if (order == null)
                {
                    return NotFound($"Order with ID {id} not found.");
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving order ID {id}: {ex}");
                return StatusCode(500, "An internal server error occurred. Please try again later.");
            }
        }
        [HttpGet("{id}/executions/")]
        public IActionResult GetOrderExecutions(int id)
        {
            try
            {
                var selectedOrder = _context.Orders.FirstOrDefault(o => o.Id == id);
                if (selectedOrder == null)
                {
                    return BadRequest($"No order with id: {id} exists!");
                }
                return Ok(selectedOrder);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Internal server error occured while getting order execution with Id: {id}. Error: {ex}");
                return StatusCode(500, "Error within server. Please try again later.");
            }
        }
        [HttpGet("orders/")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_context.Orders);
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving orders: {ex}");
                return StatusCode(500, "An internal server error occurred. Please try again later.");
            }
        }
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            try
            {
                if (order.OrderName == null)
                {
                    return BadRequest("Order name was not provided!");
                }
                if (order.CurrentOrderExecutionStatus == null)
                {
                    return BadRequest("Order execution status was not provided!");
                }
                if (order.Id != null)
                {
                    return BadRequest("Order id must be left empty!");
                }

                _context.Orders.Add(order);
                _context.SaveChanges();
                return StatusCode(201, $"Order with Id: {order.Id} created successfully!");
            }
            catch( Exception ex )
            {
                _logger.LogError($"An error occurred while creating order: {ex}");
                return StatusCode(500, "An internal server error occurred. Please try again later.");
            }
        }
        [HttpPut("orders/{id}")]
        public IActionResult UpdateOrder(int id,  [FromBody] Order order)
        {
            try
            {
                if (order.OrderName == null)
                {
                    return BadRequest("Order name was not provided!");
                }
                if (order.CurrentOrderExecutionStatus == null)
                {
                    return BadRequest("Order execution status was not provided!");
                }
                if (_context.Orders.FirstOrDefault(o => o.Id == id) == null)
                {
                    return NotFound($"Irasas su id: {id} neegzistuoja!");
                }
                var selectedOrder = _context.Orders.FirstOrDefault(o => o.Id == id);
                selectedOrder.Id = id;
                selectedOrder.OrderName = order.OrderName;
                selectedOrder.OrderDescription = order.OrderDescription;
                selectedOrder.CurrentOrderExecutionStatus = order.CurrentOrderExecutionStatus;

                _context.SaveChanges();

                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occurred while updating order with id: {id}, error: {ex}");
                return StatusCode(500, "An internal server error occurred. Please try again later.");
            }
        }
        [HttpDelete("orders/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                var order = _context.Orders.Find(id);
                if (order == null)
                {
                    return NotFound($"Order with ID {id} not found.");
                }

                _context.Orders.Remove(order);
                _context.SaveChanges();

                return Ok($"Order with ID {id} was successfully deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting order with ID: {id}, error: {ex}");
                return StatusCode(500, "An internal server error occurred. Please try again later.");
            }
        }

    }
}
