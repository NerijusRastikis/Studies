using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework1.Entities
{
    [Table("Authors")]
    public class Author
    {
        public Author()
        {
        }

        public Author(int bookID, string fullName)
        {
            BookID = bookID;
            FullName = fullName;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorID { get; set; }
        [ForeignKey(nameof(Book))]
        public int BookID { get; set; }
        [Required]
        public required string FullName { get; set; }
        public Book book { get; set; }
    }
}
