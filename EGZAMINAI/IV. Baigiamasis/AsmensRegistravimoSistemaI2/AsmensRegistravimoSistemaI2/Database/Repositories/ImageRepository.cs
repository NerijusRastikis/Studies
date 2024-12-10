using AsmensRegistravimoSistemaI2.Models.ImageControllerModels;

namespace AsmensRegistravimoSistemaI2.Database.Repositories
{
    public class ImageRepository
    {
        private readonly ARSDbContext _context;

        public ImageRepository(ARSDbContext context)
        {
            _context = context;
        }
        public Guid CreateImage(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }
            var isExisting = _context.Images.Any(x => x.Id == image.Id);
            if (isExisting)
        }
    }
}
