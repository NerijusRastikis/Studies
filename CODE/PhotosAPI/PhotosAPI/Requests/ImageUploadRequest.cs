using PhotosAPI.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PhotosAPI.Requests
{
    public class ImageUploadRequest
    {
        public int PhotoId { get; set; }
        [MaxFileSize(10 * 1024 * 1024)]
        [AllowedFileExtentions([".jpeg", ".png", ".svg", ".jpg"])]
        public IFormFile Photo { get; set; }
    }
}
