using AsmensRegistravimoSistemaI2.Database.Interfaces;
using AsmensRegistravimoSistemaI2.DTOs.Requests;
using AsmensRegistravimoSistemaI2.Mappers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AsmensRegistravimoSistemaI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userContext;

        private readonly IUserMapper _userMap;
        private readonly IGeneralInformationMapper _generalMap;
        private readonly IImageMapper _imageMap;
        private readonly IAddressMapper _addressMap;

        public UserController(ILogger<UserController> logger, IUserRepository context, IUserMapper map, IGeneralInformationMapper generalMap, IImageMapper imageMap, IAddressMapper addressMap)
        {
            _logger = logger;
            _context = context;
            _map = map;
            _generalMap = generalMap;
            _imageMap = imageMap;
            _addressMap = addressMap;
        }
        [HttpPost("Sign Up")]
        public IActionResult CreateUser([FromBody] UserDTORequest userRequest, [FromBody] ImageDTORequest imageRequest, [FromBody] GeneralInformationDTORequest generalRequest, [FromBody] AddressDTORequest addressRequest)
        {
            _logger.LogInformation("Creating new user with username: {username}", userRequest.Username);
            var newId = new Guid();
            var user = _userMap.Map(userRequest, newId);
            var image = _imageMap.Map(imageRequest, newId);
            var generalInfo = _generalMap.Map(generalRequest, newId);
            var address = _addressMap.Map(addressRequest, newId);
            
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
        [HttpGet("GetUserByUsername/{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            _logger.LogInformation("User is searching {username}", username);
            var selectedUser = _context.GetUser(username);
            if (selectedUser != null)
            {
                return Ok(selectedUser);
            }
            return Ok();
        }
        
    }
}
