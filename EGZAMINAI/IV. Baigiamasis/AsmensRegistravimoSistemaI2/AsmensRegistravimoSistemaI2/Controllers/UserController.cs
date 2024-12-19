using AsmensRegistravimoSistemaI2.Attributes;
using AsmensRegistravimoSistemaI2.Database.Interfaces;
using AsmensRegistravimoSistemaI2.DTOs.Requests;
using AsmensRegistravimoSistemaI2.Mappers.Interfaces;
using AsmensRegistravimoSistemaI2.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AsmensRegistravimoSistemaI2.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        private readonly IUserRepository _userRepo;
        private readonly IGIRepository _giRepo;
        private readonly IAddressRepository _addressRepo;

        private readonly IUserMapper _userMap;
        private readonly IGeneralInformationMapper _generalMap;
        private readonly IAddressMapper _addressMap;

        public UserController(ILogger<UserController> logger,
                              IUserRepository context,
                              IUserMapper map,
                              IGeneralInformationMapper generalMap,
                              IAddressMapper addressMap,
                              IGIRepository giRepo,
                              IAddressRepository addressRepo,
                              IUserService userService,
                              IJwtService jwtService)
        {
            _logger = logger;
            _userRepo = context;
            _userMap = map;
            _generalMap = generalMap;
            _addressMap = addressMap;
            _giRepo = giRepo;
            _addressRepo = addressRepo;
            _userService = userService;
            _jwtService = jwtService;
        }
        [Produces(MediaTypeNames.Text.Plain)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost("SignUp")]
        public async Task<IActionResult> CreateUser([FromForm] UserModelDTORequest request)
        {
            _logger.LogInformation("Creating new user with username: {username}", request.Username);

            // Generate unique GUIDs
            var userId = Guid.NewGuid();
            var giId = Guid.NewGuid();
            var addressId = Guid.NewGuid();

            // Create Address
            var newAddressDTO = new AddressDTORequest
            {
                Town = request.Town,
                Street = request.Street,
                HouseNumber = request.HouseNumber,
                ApartmentNumber = request.ApartmentNumber,
            };
            var newAddress = _addressMap.Map(newAddressDTO, addressId);

            // Create GeneralInformation
            byte[] imageBytes = null;
            if (request.GIImage != null)
            {
                _logger.LogInformation("Received image with size: {0} bytes", request.GIImage.Length);
                using (var memoryStream = new MemoryStream())
                {
                    await request.GIImage.CopyToAsync(memoryStream);
                    imageBytes = memoryStream.ToArray();
                }
            }
            else
            {
                _logger.LogWarning("No image received during sign-up.");
            }

            var newGIDTO = new GeneralInformationDTORequest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PersonalCode = request.PersonalCode,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                ProfilePhoto = imageBytes
            };
            var newGI = _generalMap.Map(newGIDTO, giId);
            newGI.GIAddressId = addressId;

            // Create User
            var newUserDTO = new UserDTORequest
            {
                Username = request.Username,
                Password = request.Password,
            };
            var newUser = _userMap.Map(newUserDTO, userId);
            newUser.UserGeneralInformationId = giId;
            newUser.GeneralInformation = newGI;
            newUser.Roles = RoleTypes.User;

            // Save entities in order: Address -> GI -> User
            _addressRepo.CreateAddress(newAddress);
            _giRepo.CreateGI(newGI);
            _userRepo.CreateUser(newUser);

            return Ok(userId);
        }
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Text.Plain)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpPost("Login")]
        public IActionResult Login(UserDTORequest request)
        {
            var user = _userRepo.GetUserByUsername(request.Username);
            if (user == null)
            {
                return BadRequest("User not found.");
            }
            var isPasswordValid = _userService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);
            if (!isPasswordValid)
            {
                return BadRequest("Invalid username of password.");
            }
            var jwt = _jwtService.GetJwtToken(user);
            return Ok(jwt);
        }
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            _logger.LogInformation("User is getting all system users.");
            var listOfUsers = _userRepo.GetUsers();
            if (listOfUsers is not null)
            {
                return Ok(listOfUsers);
            }
            return Ok();
        }
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetUserByUsername/{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            _logger.LogInformation("User is searching {username}", username);
            var selectedUser = _userRepo.GetUserByUsername(username);
            if (selectedUser != null)
            {
                return Ok(selectedUser);
            }
            return Ok();
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var targetUser = _userRepo.GetUserById(id);
            if (targetUser == null)
            {
                return NotFound();
            }
            if (targetUser.GeneralInformation != null)
            {
                _giRepo.DeleteGI(targetUser.GeneralInformation.Id);
            }
            if (targetUser.GeneralInformation?.GIAddress != null)
            {
                _addressRepo.DeleteAddress(targetUser.GeneralInformation.GIAddress.Id);
            }
            if (_userRepo.DeleteUser(targetUser.Id))
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpPut("{id}/Username")]
        public IActionResult ChangeUsername(Guid id, [FromBody] string username)
        {
            var selectedUser = _userRepo.GetUserById(id);
            if (selectedUser == null)
            {
                return NotFound("User not found");
            }
            selectedUser.Username = username;
            var result = _userRepo.UpdateUser(selectedUser);
            if (result) return NoContent();
            else return BadRequest("Provided new username was incorrect.");
        }
        [HttpPut("{id}/Password")]
        public IActionResult ChangePassword(Guid id, [FromBody] string password)
        {
            var selectedUser = _userRepo.GetUserById(id);
            if (selectedUser == null)
            {
                return NotFound("User not found");
            }
            _userService.CreatePasswordHash(password, out byte[] newPasswordHash, out byte[] newPasswordSalt);            
            selectedUser.PasswordHash = newPasswordHash;
            selectedUser.PasswordSalt = newPasswordSalt;
            var result = _userRepo.UpdateUser(selectedUser);
            if (result) return NoContent();
            else return BadRequest("Provided new username was incorrect.");
        }
    }
}
