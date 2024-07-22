using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirma
{
    internal class Book
    {
        public Book()
        {
            Pavadinimas = "Geroji siela";
            Autorius = "Vėjas Naumojus";
            Metai = 2012;
        }
        public Book(string leidimoSalis)
        {
            LeidimoSalis = leidimoSalis;
        }
        public Book(string name, string author, int year, string country) : this(country)
        {
            Pavadinimas = name;
            Autorius = author;
            Metai = year;
        }
        public string Pavadinimas { get; set; }
        public string Autorius { get; set; }
        public int Metai { get; set; }
        public string LeidimoSalis { get; set; }
        public override string ToString()
        {
            return $"{Pavadinimas}, {Autorius}, {Metai}, {LeidimoSalis}";
        }
    }
}
