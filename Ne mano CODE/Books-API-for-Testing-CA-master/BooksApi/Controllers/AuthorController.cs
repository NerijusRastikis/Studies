using BooksApi.Models;
using BooksApi.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repository;
        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository;
        }


        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Author>), StatusCodes.Status200OK)]
        public IActionResult GetAuthors([FromQuery][Required] string name)
        {
            var authors = _repository.Filter(name, name).ToList();
            return Ok(authors);
        }





    }
}
