using P003.Enums;

namespace P003.DTO
{
    public class BookRequest
    {
        public CoverType Cover { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
