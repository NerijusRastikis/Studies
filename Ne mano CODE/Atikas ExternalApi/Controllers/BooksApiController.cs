using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P103_ExternalApi.Dtos;
using P103_ExternalApi.Services;

namespace P103_ExternalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class BooksApiController : ControllerBase
    {
        private readonly IBooksApiClient _booksApiClient;
        private readonly IBooksMapper _mapper;

        public BooksApiController(IBooksApiClient booksApiClient, IBooksMapper mapper)
        {
            _booksApiClient = booksApiClient;
            _mapper = mapper;
        }

        
        /// <summary>
        /// Visų knygų gavimas iš API
        /// </summary>
        /// <param name="connectionId">Id iš WEB puslapio</param>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookResult>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBooks([FromHeader]string connectionId)
        {
            try
            {
                var result = await _booksApiClient.GetBooks(connectionId);
                if (result == null)
                {
                    return NotFound();
                }
                var books = _mapper.Map(result!);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBook([FromHeader] string connectionId, [FromRoute]int id)
        {
            var result = await _booksApiClient.GetBook(connectionId, id);
            if (result == null)
            {
                return NotFound();
            }
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
        public async Task<IActionResult> UpdateBook([FromHeader] string connectionId, [FromRoute] int id, [FromBody] BookRequest req)
        {
            var book = await _booksApiClient.GetBook(connectionId, id);
            if (book == null)
            {
                return NotFound();
            }

            var apiRequest = _mapper.Map(req);
            await _booksApiClient.UpdateBook(connectionId, id, apiRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBook([FromHeader] string connectionId, [FromRoute] int id)
        {
            var book = await _booksApiClient.GetBook(connectionId, id);
            if (book == null)
            {
                return NotFound();
            }

            await _booksApiClient.DeleteBook(connectionId, id);
            return NoContent();
        }
    }
}
