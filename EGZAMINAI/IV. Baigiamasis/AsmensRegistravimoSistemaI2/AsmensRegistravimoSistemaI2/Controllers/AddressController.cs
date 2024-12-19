using AsmensRegistravimoSistemaI2.Database.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsmensRegistravimoSistemaI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressRepository _addressRepo;

        public AddressController(IAddressRepository addressRepo, ILogger<AddressController> logger)
        {
            _addressRepo = addressRepo;
            _logger = logger;
        }
        [HttpGet("{id}")]
        public IActionResult GetAddress(Guid id)
        {
            var selectedAddress = _addressRepo.GetAddress(id);
            if (selectedAddress == null)
            {
                return NotFound("Address was not found.");
            }
            return Ok(selectedAddress);
        }
        [HttpPut("{id}/Town")]
        public IActionResult ChangeTown(Guid id, [FromBody] string town)
        {
            var selectedAddress = _addressRepo.GetAddress(id);
            if (selectedAddress == null)
            {
                return NotFound("Address not found");
            }
            selectedAddress.Town = town;
            if (_addressRepo.UpdateAddress(selectedAddress)) return NoContent();
            else return BadRequest("New town input is incorrect.");
        }
        [HttpPut("{id}/Street")]
        public IActionResult ChangeStreet(Guid id, [FromBody] string street)
        {
            var selectedAddress = _addressRepo.GetAddress(id);
            if (selectedAddress == null)
            {
                return NotFound("Address not found");
            }
            selectedAddress.Street = street;
            if (_addressRepo.UpdateAddress(selectedAddress)) return NoContent();
            else return BadRequest("New street input is incorrect.");
        }
        [HttpPut("{id}/HouseNumber")]
        public IActionResult ChangeHouseNumber(Guid id, [FromBody] string houseNumber)
        {
            var selectedAddress = _addressRepo.GetAddress(id);
            if (selectedAddress == null)
            {
                return NotFound("Address not found");
            }
            selectedAddress.HouseNumber = houseNumber;
            if (_addressRepo.UpdateAddress(selectedAddress)) return NoContent();
            else return BadRequest("New house number input is incorrect.");
        }
        [HttpPut("{id}/ApartmentNumber")]
        public IActionResult ChangeApartmentNumber(Guid id, [FromBody] int apartmentNumber)
        {
            var selectedAddress = _addressRepo.GetAddress(id);
            if (selectedAddress == null)
            {
                return NotFound("Address not found");
            }
            selectedAddress.ApartmentNumber = apartmentNumber;
            if (_addressRepo.UpdateAddress(selectedAddress)) return NoContent();
            else return BadRequest("New apartment number input is incorrect.");
        }
    }
}