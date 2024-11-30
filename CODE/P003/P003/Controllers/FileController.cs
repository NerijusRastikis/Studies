using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P003.DTO;
using P003.Services;

namespace P003.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IFileMapper _fileMapper;
        private readonly ILogger _logger;

        public FileController(IFileService fileService, IFileMapper fileMapper, ILogger logger)
        {
            _fileService = fileService;
            _fileMapper = fileMapper;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get([FromHeader] string id)
        {
            if (!_fileService.UserExists(id))
            {
                _logger.LogError($"Naudotojas egzistuoja. Naudotas ID: {id}");
                return Unauthorized("Naudotojas neegzistuoja");
            }

            var todos = _fileService.ReadAllLines();
            var dto = _fileMapper.Map(todos);
            _logger.LogInformation($"Successfull retrieval. Returned: {todos}");
            return Ok(dto);
        }
        [HttpGet("${id}")]
        public IActionResult Get(int id)
        {
            if (!_fileService.UserExists(id.ToString()))
            {
                return Unauthorized("Naudotojas neegzistuoja");
            }
            var item = _fileService.ReadLine(id);
            if (item == null)
            {
                return NotFound("Ieškomas įrašas neegzistuoja");
            }
            var dto = _fileMapper.MapToResult(item);
            return Ok(dto);
        }
        [HttpPost]
        public IActionResult Create([FromHeader] string id, [FromBody] FileLineRequest req)
        {
            if (!_fileService.UserExists(id))
            {
                return Unauthorized("Naudotojas neegzistuoja");
            }
            if (string.IsNullOrEmpty(req.Content))
            {
                return BadRequest("Nenurodytas tekstas (Content)");
            }

            var item = _fileMapper.MapToRequest(req.Content);
            _fileService.WriteLine(item.Content);
                return CreatedAtAction(nameof(Get), item);
        }
        [HttpPut]
        public IActionResult Put([FromHeader] int id, [FromBody] FileLineRequest req)
        {
            if (!_fileService.UserExists(id.ToString()))
            {
                return Unauthorized("Naudotojas neegzistuoja");
            }

            var item = _fileService.ReadLine(id);
            if (item == null)
            {
                return NotFound("Toks įrašas neegzistuoja");
            }
            if (string.IsNullOrEmpty(req.Content))
            {
                return BadRequest("Nenurodytas tekstas (Content)");
            }


            _fileMapper.Project(item, req.Content);
            _fileService.ReplaceLine(item, id);
            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete([FromHeader] int id)
        {
            if (!_fileService.UserExists(id.ToString()))
            {
                return Unauthorized("Vartotojas neegzistuoja");
            }
            var lineToRemove = _fileService.ReadLine(id);
            if (lineToRemove == null)
            {
                return NotFound("Toks įrašas neegzistuoja");
            }

            _fileService.RemoveLine(id);
            return NoContent();
        }
    }
}
