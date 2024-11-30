using System;
using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string CoverType { get; set; }

        public Guid GenreId { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int Pages { get; set; }

        public int Year { get; set; }


        [Required]
        public string ISBN { get; set; }


        public ICollection<Author> Authors { get; set; }
    }
}
