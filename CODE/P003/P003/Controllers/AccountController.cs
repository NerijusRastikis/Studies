using Microsoft.AspNetCore.Mvc;
using P003.Services;
using P003.Database;
using P003.DTO;
using P003.Models;

namespace P003.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly BooksDatabase _booksDatabase;
        private readonly IJwtService _jwtService;
        private readonly Login _loginService;  // Inject Login service

        public AccountController(
            ILogger<AccountController> logger,
            IAccountService accountService, 
            BooksDatabase booksDatabase, 
            IJwtService jwtService, 
            Login loginService) // Add Login here
        {
            _logger = logger;
            _accountService = accountService;
            _booksDatabase = booksDatabase;
            _jwtService = jwtService;
            _loginService = loginService;  // Assign the injected service
        }

        // POST request for registration
        [HttpPost]
        public Task<ActionResult<Account>> Post([FromBody] LoginRequest loginRequest)
        {
            // Use the loginRequest to get the username and password
            _accountService.SignUpNewAccount(loginRequest.Username, loginRequest.Password);
            return Task.FromResult<ActionResult<Account>>(Ok());
        }
        
        // GET request for login and JWT token generation
        [HttpGet("{username}")]
        public IActionResult Get(string username, [FromQuery] string password)
        {
            if (username == null || password == null)
            {
                return BadRequest("Username or password cannot be null.");
            }
            
            // Authenticate using Login service
            if (_loginService.Authenticate(username, password))
            {
                // If authentication is successful, generate and return JWT token
                var token = _jwtService.GetJwtToken(username, "User");
                return Ok(token);
            }
            
            return Unauthorized("Invalid credentials.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AccountDto request)
        {
            if(!_loginService.LoginUser(request.Username, request.Password, out string role))
                return BadRequest($"Bad username or password.");
            
            string token = _jwtService.GetJwtToken(request.Username, role);
            return Ok(token);
        }
    }
}
