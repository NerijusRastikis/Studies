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

        private readonly IUserRepository _userRepo;

        private readonly IUserMapper _userMap;
        private readonly IGeneralInformationMapper _generalMap;
        private readonly IAddressMapper _addressMap;

        public UserController(ILogger<UserController> logger, IUserRepository context, IUserMapper map, IGeneralInformationMapper generalMap, IAddressMapper addressMap)
        {
            _logger = logger;
            _userRepo = context;
            _userMap = map;
            _generalMap = generalMap;
            _addressMap = addressMap;
        }
        [HttpPost("Sign Up")]
        public IActionResult CreateUser([FromBody] UserModelDTORequest request)
        {
            _logger.LogInformation("Creating new user with username: {username}", request.Username);
            var newId = new Guid();
            var newUserDTO = new UserDTORequest
            {
                Username = request.Username,
                Password = request.Password,
            };
            var newGIDTO = new GeneralInformationDTORequest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PersonalCode = request.PersonalCode,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                ProfilePhoto = request.GIImage,
            };
            var newAddressDTO = new AddressDTORequest
            {
                Town = request.Town,
                Street = request.Street,
                HouseNumber = request.HouseNumber,
                ApartmentNumber = request.ApartmentNumber,
            };
            var newAddress = _addressMap.Map(newAddressDTO, newId);
            var newGI = _generalMap.Map(newGIDTO, newId);
            newGI.GIAddress = newAddress;
            var newUser = _userMap.Map(newUserDTO, newId);

            _userRepo.CreateUser(newUser);

        }
        [HttpGet("GetAllUsernames")]
        public IActionResult GetAllUsernames()
        {
            _logger.LogInformation("User is getting all system usernames.");
            var listOfUsers = _userRepo.GetUsers();
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
            var selectedUser = _userRepo.GetUser(username);
            if (selectedUser != null)
            {
                return Ok(selectedUser);
            }
            return Ok();
        }
        
    }
}
