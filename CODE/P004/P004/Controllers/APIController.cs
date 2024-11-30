using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P0004.DTOs;
using P0004.Services;
using P004.DTOs;

namespace P0004.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksApiController : ControllerBase
    {
        private readonly IBooksAPIClient _booksApiClient;
        private readonly IBooksMapper _mapper;

        public BooksApiController(IBooksAPIClient booksApiClient, IBooksMapper mapper)
        {
            _booksApiClient = booksApiClient;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBooks([FromHeader] string connectionId)
        {
            var result = await _booksApiClient.GetBooks(connectionId);
            var books = _mapper.Map(result!);
            return Ok(books);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBook([FromHeader] string connectionId, [FromRoute] int id)
        {
            var result = await _booksApiClient.GetBook(connectionId, id);
            var book = _mapper.Map(result);
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateBook([FromHeader] string connectionId, [FromBody] BookRequest req)
        {
            var apiRequest = _mapper.Map(req);
            var id = await _booksApiClient.CreateBook(connectionId, apiRequest);
            return Created(nameof(GetBook), new { id });

        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put([FromHeader] string connectionId, [FromBody] BookRequest req, [FromRoute] int id)
        {
            var book = _booksApiClient.GetBook(connectionId, id);
            if (book == null)
            {
                return NotFound();
            }
            var apiRequest = _mapper.Map(req);
            await _booksApiClient.UpdateBook(connectionId, apiRequest);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBook([FromHeader] string connectionId, [FromRoute] int id)
        {
            var book = _booksApiClient.GetBook(connectionId, id);
            if (book == null)
            {
                return NotFound();
            }
            
        }
    }
}
