using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotosAPI.Database;
using PhotosAPI.Models;
using PhotosAPI.Requests;
using PhotosAPI.Services;

namespace PhotosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly ILogger<PhotosController> _logger;
        private readonly PhotoDbContext _photoDbContext;
        private readonly IImageResizerService _imageResizerService;

        public PhotosController(ILogger<PhotosController> logger, PhotoDbContext photoDbContext, IImageResizerService imageResizerService)
        {
            _logger = logger;
            _photoDbContext = photoDbContext;
            _imageResizerService = imageResizerService;
        }
        [HttpGet("Photo/{id}")]
        public IActionResult GetPhotoById(int id)
        {
            try
            {
                var photo = _photoDbContext.Photos.FirstOrDefault(p => p.Id == id);
                if (photo == null)
                {
                    return NotFound($"Photo with id: {id} does not exist.");
                }
                return File(photo.Bytes, "image/jpeg");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting Id: {id}, error: {ex}");
                return StatusCode(500, "Internal server error occured, please try again later.");
            }
        }
        [HttpPost("Photo/")]
        public IActionResult UploadPhoto([FromForm] ImageUploadRequest request)
        {
            try
            {
                Random rand = new Random();
                using var memoryStream = new MemoryStream();
                request.Photo.CopyTo(memoryStream);
                var imageBytes = memoryStream.ToArray();

                var photo = _photoDbContext.Photos.FirstOrDefault(x => x.Id == request.PhotoId);
                if (photo is not null)
                {
                    return BadRequest("Record already exists!");
                }
                else
                {
                    photo = new Photo { Name = $"photo_{rand.Next(1, 9999)}", Bytes = imageBytes };
                    _photoDbContext.Photos.Add(photo);
                    _photoDbContext.SaveChanges();
                    _logger.LogInformation($"Photo with ID {photo.Id} saved successfully.");
                }

                // Process thumbnail
                var thumbnail = _imageResizerService.ImageResize(photo, 150, 150);
                bool isThumbnailSaved = _imageResizerService.RecordToThumbnailDbTable(thumbnail);
                if (isThumbnailSaved)
                {
                    _logger.LogInformation($"Thumbnail for photo {photo.Name} saved successfully.");
                }
                else
                {
                    _logger.LogError($"Failed to save thumbnail for photo {photo.Name}.");
                }

                return Ok("Image saved successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred while uploading photo: {ex}");
                return StatusCode(500, "Internal server error.");
            }
        }
        [HttpGet("Thumbnail/{id}")]
        public IActionResult GetThumbnailById(int id)
        {
            try
            {
                var thumbnail = _photoDbContext.Thumbnails.FirstOrDefault(t => t.Id == id);
                if (thumbnail == null)
                {
                    return NotFound($"Thumbnail with id: {id} does not exist.");
                }
                return File(thumbnail.Bytes, "image/jpeg");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting id: {id}, error: {ex}");
                return StatusCode(500, "Internal server error occured. Please try again later.");
            }
        }
    }
}
