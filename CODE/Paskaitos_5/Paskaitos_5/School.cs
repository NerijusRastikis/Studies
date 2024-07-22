using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirma
{
    internal class School
    {
        public School()
        {
            Pavadinimas = "Lietuvos Akademija";
            Miestas = "Vilnius";
        }
        public School(int mokSkaicius) : this()
        {
            MokSkaicius = mokSkaicius;
        }
        public string Pavadinimas { get; set; }
        public string Miestas { get; set; }
        public int MokSkaicius { get; set; }
        public override string ToString()
        {
            return $"{Pavadinimas}, {Miestas} - {MokSkaicius}";
        }
    }
}
