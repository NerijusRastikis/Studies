using Microsoft.EntityFrameworkCore;
using PhotosAPI.Models;

namespace PhotosAPI.Database
{
    public class PhotoDbContext : DbContext
    {
        public DbSet<Photo> Photos {  get; set; }
        public DbSet<Thumbnail> Thumbnails { get; set; }
        public PhotoDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}