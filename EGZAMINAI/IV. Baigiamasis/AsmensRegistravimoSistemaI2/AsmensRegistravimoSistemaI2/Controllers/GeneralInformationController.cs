using AsmensRegistravimoSistemaI2.Database.Interfaces;
using AsmensRegistravimoSistemaI2.Mappers.Interfaces;
using AsmensRegistravimoSistemaI2.Services.Interfaces;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsmensRegistravimoSistemaI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralInformationController : ControllerBase
    {
        private readonly ILogger<GeneralInformationController> _logger;
        private readonly IGIRepository _giRepo;
        private readonly IGeneralInformationMapper _mapper;
        private readonly IPhoneNumberConverter _phoneNumberConverter;

        public GeneralInformationController(ILogger<GeneralInformationController> logger, IGIRepository gIRepository, IGeneralInformationMapper mapper = null, IPhoneNumberConverter phoneNumberConverter = null)
        {
            _logger = logger;
            _giRepo = gIRepository;
            _mapper = mapper;
            _phoneNumberConverter = phoneNumberConverter;
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetGI(Guid id)
        {
            var selectedGI = _giRepo.GetGIById(id);
            return Ok(selectedGI);
        }
        [HttpPut("{id}/FirstName")]
        public IActionResult ChangeFirstName(Guid id, [FromBody] string firstName)
        {
            var selectedInformation = _giRepo.GetGIById(id);
            if (selectedInformation == null)
            {
                return NotFound("General information not found");
            }
            selectedInformation.FirstName = firstName;
            _giRepo.UpdateGI(selectedInformation);
            return NoContent();
        }
        [HttpPut("{id}/LastName")]
        public IActionResult ChangeLastName(Guid id, [FromBody] string lastName)
        {
            var selectedInformation = _giRepo.GetGIById(id);
            if (selectedInformation == null)
            {
                return NotFound("General information not found");
            }
            selectedInformation.LastName = lastName;
            _giRepo.UpdateGI(selectedInformation);
            return NoContent();
        }
        [HttpPut("{id}/PersonalCode")]
        public IActionResult ChangePersonalCode(Guid id, [FromBody] long personalCode)
        {
            var selectedInformation = _giRepo.GetGIById(id);
            if (selectedInformation == null)
            {
                return NotFound("General information not found");
            }
            selectedInformation.PersonalCode = personalCode;
            _giRepo.UpdateGI(selectedInformation);
            return NoContent();
        }
        [HttpPut("{id}/PhoneNumber")]
        public IActionResult ChangePhoneNumber(Guid id, [FromBody] string phoneNumber)
        {
            var selectedInformation = _giRepo.GetGIById(id);
            if (selectedInformation == null)
            {
                return NotFound("General information not found");
            }
            if (phoneNumber == null)
            {
                return BadRequest("Phone number cannot be an empty field.");
            }
            if (!phoneNumber.StartsWith("+370") || !phoneNumber.StartsWith("370") || !phoneNumber.StartsWith("8"))
            {
                return BadRequest("Format of phone number is incorrect.");
            }
            var convertedPhoneNumber = _phoneNumberConverter.ConvertPhoneNumber(phoneNumber);
            selectedInformation.LastName = convertedPhoneNumber;
            _giRepo.UpdateGI(selectedInformation);
            return NoContent();
        }
        [HttpPut("{id}/Email")]
        public IActionResult ChangeEmail(Guid id, [FromBody] string email)
        {
            var selectedInformation = _giRepo.GetGIById(id);
            if (selectedInformation == null)
            {
                return NotFound("General information not found");
            }
            selectedInformation.Email = email;
            _giRepo.UpdateGI(selectedInformation);
            return NoContent();
        }
        [HttpPut("{id}/ProfilePhoto")]
        public async Task<IActionResult> ChangeProfilePhoto(Guid id, [FromBody] IFormFile photo)
        {
            var selectedInformation = _giRepo.GetGIById(id);
            if (selectedInformation == null)
            {
                return NotFound("General information not found");
            }
            if (photo is null)
            {
                return BadRequest("Profile photo cannot be an empty field.");
            }
            byte[] imageBytes = null;
            {
                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);
                    imageBytes = memoryStream.ToArray();
                }
            }
            selectedInformation.GIImage = imageBytes;
            _giRepo.UpdateGI(selectedInformation);
            return NoContent();
        }
    }
}
