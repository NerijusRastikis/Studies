using AsmensRegistravimoSistema.Database.Repositories;
using AsmensRegistravimoSistema.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsmensRegistravimoSistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly ILogger<UserRegistrationController> _logger;
        private readonly UserRepository _context;

        public UserRegistrationController(UserRepository context, ILogger<UserRegistrationController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserRequest request)
        {
            _logger.LogInformation("Trying to register new user with information: {request}", request);

        }
    }
}
