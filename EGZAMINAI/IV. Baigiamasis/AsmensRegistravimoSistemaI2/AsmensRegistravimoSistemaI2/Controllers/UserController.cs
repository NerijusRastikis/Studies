using AsmensRegistravimoSistemaI2.Database.Interfaces;
using AsmensRegistravimoSistemaI2.DTOs.Requests;
using AsmensRegistravimoSistemaI2.Mappers.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AsmensRegistravimoSistemaI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _context;
        private readonly IUserMapper _map;

        public UserController(ILogger<UserController> logger, IUserRepository context, IUserMapper map)
        {
            _logger = logger;
            _context = context;
            _map = map;
        }
        [HttpPost("Sign Up")]
        public IActionResult CreateUser([FromBody] UserDTORequest request)
        {
            _logger.LogInformation("Creating new user with username: {username}", request.Username);
            var user = _map.Map(request);
            var confirmedUsername = user.Username;
            return Created("", new { id = user.Id });
        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            _logger.LogInformation("User is getting all system usernames.");
            var listOfUsers = _context.GetUsers();
            if (listOfUsers is not null)
            {
                return Ok(listOfUsers);
            }
            return Ok();
        }
    }
}
