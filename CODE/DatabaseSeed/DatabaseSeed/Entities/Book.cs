using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSeed.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public required int Year { get; set; }
        public List<Author> Authors { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
