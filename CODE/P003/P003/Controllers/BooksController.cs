using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P003.Database;
using P003.DTO;
using P003.Models;
using P003.Repositories;

namespace P003.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookRepository bookRepository, ILogger<BooksController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listOfBooks = _bookRepository.GetAll();
                _logger.LogInformation($"Displayed all books at {DateTime.UtcNow}");
                return Ok(listOfBooks);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while fetching all books. Time: {DateTime.UtcNow}, Error code: {ex}");
                return StatusCode(418, "Oppsy!");
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var selectedBook = _bookRepository.GetBookById(id);
                _logger.LogInformation($"Successfully displayed book with id: {id} at {DateTime.UtcNow}");
                return Ok(selectedBook);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to get book by id: {id}. Error code: {ex}");
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] BookRequest book)
        {
            try
            {
                var sculptBook = new Book
                {
                    
                    Title = book.Title,
                    Author = book.Author,
                    Cover = book.Cover,
                };
                _bookRepository.Post(sculptBook);
                _logger.LogInformation($"Successfully created new book: title - {book.Title}, author - {book.Author}, cover - {book.Cover} | Time: {DateTime.UtcNow}");
                return Created("SUKURTA", _bookRepository.GetAll().ToList().FirstOrDefault(x => x.Title == book.Title && x.Author == book.Author));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}, at time: {DateTime.UtcNow}, attempted to create new book's contents: title - {book.Title}, author - {book.Author}, cover - {book.Cover}");
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookRequest book)
        {
            try
            {
                var sculptBook = new Book
                {
                    Id = id,
                    Title = book.Title,
                    Author = book.Author,
                    Cover = book.Cover
                };
                _bookRepository.Put(sculptBook, id);
                _logger.LogInformation($"Book has been updated with new information: title - {book.Title}, author - {book.Author}, cover - {book.Cover}. At time: {DateTime.UtcNow}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to update book. Reason: {ex}, at time: {DateTime.UtcNow}");
                return BadRequest();
            }
        }
        [Authorize (Roles = "User")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _bookRepository.Delete(id);
                _logger.LogInformation($"Successfully deleted book. Id: {id}, at time: {DateTime.UtcNow}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to delete book, id: {id}, reason: {ex}, at time: {DateTime.UtcNow}");
                return BadRequest();
            }
        }
    }
}
