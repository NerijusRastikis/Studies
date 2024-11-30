using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }
     
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
       
        public string? Country { get; set; }


    }
}
