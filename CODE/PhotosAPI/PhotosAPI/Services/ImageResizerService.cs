using PhotosAPI.Database;
using PhotosAPI.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace PhotosAPI.Services
{
    public class ImageResizerService : IImageResizerService
    {
        private readonly ILogger<ImageResizerService> _logger;
        private readonly PhotoDbContext _photoDbContext;

        public ImageResizerService(PhotoDbContext photoDbContext, ILogger<ImageResizerService> logger)
        {
            _photoDbContext = photoDbContext;
            _logger = logger;
        }
        public Thumbnail ImageResize(Photo photo, int width, int height)
        {
            using var image = Image.Load(photo.Bytes);
            image.Mutate(x => x.Resize(width, height));

            using var memoryStream = new MemoryStream();
            image.SaveAsJpeg(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            Random random = new Random();
            var randomNumber = random.Next(1, 111111);

            while (_photoDbContext.Thumbnails.FirstOrDefault(x => x.Name == $"{photo.Name}_thumb_{randomNumber}") != null)
            {
                randomNumber = random.Next(1, 111111);
            }

            var thumbnail = new Thumbnail
            {
                Name = $"{photo.Name}_thumb_{randomNumber}",
                Bytes = memoryStream.ToArray()
            };

            return thumbnail;
        }

        public bool RecordToThumbnailDbTable(Thumbnail thumbnail)
        {
            try
            {
                _photoDbContext.Thumbnails.Add(thumbnail);
                _photoDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while adding thumbnail to database.");
                return false;
            }
        }
    }
}
