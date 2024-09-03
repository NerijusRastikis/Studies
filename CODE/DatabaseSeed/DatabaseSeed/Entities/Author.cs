using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSeed.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public required string FullName { get; set; }
        public int BookId { get; set; }
        public  Book Book { get; set; }
        public int CountryId { get; set; }


        public virtual Country Country { get; set; } //uzduotis
    }
}
