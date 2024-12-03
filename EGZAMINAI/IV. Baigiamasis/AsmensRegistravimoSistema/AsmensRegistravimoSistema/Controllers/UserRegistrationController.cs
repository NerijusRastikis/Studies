using AsmensRegistravimoSistema.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsmensRegistravimoSistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly 
        [HttpPost("{id}")]
        public IActionResult CreateUser([FromBody] UserRequest request, int id)
        {

        }
    }
}
