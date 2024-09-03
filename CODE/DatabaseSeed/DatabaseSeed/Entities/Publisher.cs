using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSeed.Entities
{
    public class Publisher  //uzduotis
    {
        [Key]
        public int PublisherId { get; set; }
        public required string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
