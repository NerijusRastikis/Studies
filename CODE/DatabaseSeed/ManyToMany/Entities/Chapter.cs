using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany.Entities
{
    public class Chapter
    {
        public int ChapterId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
