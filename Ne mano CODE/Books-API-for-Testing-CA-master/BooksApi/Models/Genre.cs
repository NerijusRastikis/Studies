using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
