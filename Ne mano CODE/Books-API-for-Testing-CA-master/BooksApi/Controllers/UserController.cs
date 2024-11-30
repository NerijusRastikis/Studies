using BooksApi.DTOs;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace BooksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public ActionResult<ResponseDto> Login([FromBody] UserDto request)
        {
            var response = _userService.Login(request.Username, request.Password);
            if (!response.IsSuccess)
                return BadRequest(response.Message);
            return response;
        }

        [HttpPost("Signup")]
        public ActionResult<ResponseDto> Signup([FromBody] UserDto request)
        {
            var response = _userService.Signup(request.Username, request.Password);
            if (!response.IsSuccess)
                return BadRequest(response.Message);
            return response;
        }
    }
}
