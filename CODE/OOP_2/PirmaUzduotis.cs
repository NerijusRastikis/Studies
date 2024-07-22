using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    internal class PirmaUzduotis
    {
        public PirmaUzduotis()
        {

        }
        public List<int> Numbers { get; set; }
        public List<int> AddNumbers(int input)
        {
            Numbers.Add(input);
            return Numbers;
        }
        public void PrintList()
        {
            foreach (var number in Numbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine(".");
        }
    }
}
