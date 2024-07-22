using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirma
{
    internal class Store
    {
        public Store()
        {

        }
        public Store(string name, int year, List<string> items)
        {
            Name = name;
            Year = year;
            Items = items;
        }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<string> Items { get; set; }
        public override string ToString()
        {
            return $"{Name} {Year} - {Items}";
        }
    }
}
