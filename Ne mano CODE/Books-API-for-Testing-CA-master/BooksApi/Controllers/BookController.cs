using BooksApi.DTOs;
using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;


namespace BooksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly IBookMapper _mapper;


        public BookController(IBookService service, IBookMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [ProducesResponseType(typeof(GetBookResult), 200)]
        [HttpGet("GetAll")]
        public ActionResult<Book> GetBooks([FromQuery] string title)
        {
            var books = _service.GetBook(title);
            var dto = _mapper.Map(books);
            return Ok(dto);
        }

        [HttpDelete("Remove")]
        public IActionResult RemoveBook([FromQuery] Guid id)
        {
            _service.RemoveBook(id);
            return NoContent();
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook(CreateBookRequest req)
        {
          
            var book = _mapper.Map(req);
            var res = _service.AddBook(book);
            return Created(nameof(AddBook), new {id = res.Message });
        }
    }
}
