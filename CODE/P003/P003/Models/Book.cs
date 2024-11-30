using P003.Enums;

namespace P003.Models
{
    public class Book
    {

        public int Id { get; set; }
        public CoverType Cover {  get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
