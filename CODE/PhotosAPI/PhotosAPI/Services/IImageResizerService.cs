using PhotosAPI.Models;

namespace PhotosAPI.Services
{
    public interface IImageResizerService
    {
        Thumbnail ImageResize(Photo photo, int width, int height);
        bool RecordToThumbnailDbTable(Thumbnail thumbnail);
    }
}