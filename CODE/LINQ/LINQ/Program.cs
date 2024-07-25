using System.Collections.Generic;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Paskaitos data: 2024-07-23
            List<string> names = new List<string>
        {
            "Jonas",
            "Marta",
            "Petras",
            "Ana",
            "Darius"
        };
            var ordered = names.OrderBy(n => n).ThenBy(n => n.Length).ToList();
            foreach (var name in ordered)
            {
                Console.WriteLine(name);
            }
        }
    }
}
