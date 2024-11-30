using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class CreateBookRequest
    {
        public string Title { get; set; }

        public Guid GenreId { get; set; }

        [Required]
        public int Pages { get; set; }

        public int Year { get; set; }


        [Required]
        public string ISBN { get; set; }

        public IList<Guid> AuthorIds { get; set; }
    }
}
