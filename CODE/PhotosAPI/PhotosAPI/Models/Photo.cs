namespace PhotosAPI.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Bytes { get; set; }
    }
}
