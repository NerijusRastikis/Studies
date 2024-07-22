using System;
using System.Collections.Generic;

namespace ketvirta
{
    public class Program
    {
        static void Main(string[] args)
        {
            var namesAndAges = new Dictionary<string, int>()
            {
                {"John", 23 },
                {"Sharon", 33 },
                {"Albert", 9 }
            };
            PrintNameAndAge(namesAndAges);

            var citiesAndCapitals = new Dictionary<string, string>()
            {
                {"germany", "Berlin" },
                {"canada", "Ottawa" },
                {"poland", "Warsaw" },
                {"latvia", "Riga" },
                {"australia", "Canberra" }
            };
            Console.Write("Enter country name: ");
            string userInput = Console.ReadLine();
            Console.WriteLine($"Capital of your chosen city: {CountryAndCapital(citiesAndCapitals, userInput)}");
            Console.WriteLine("-----------------------------------");

            var fruitDict = new Dictionary<string, int>()
            {
                {"Apple", 3 },
                {"Pear", 7 },
                {"Pineapple", 1 },
                {"Melon", 13 },
                {"Orange", 5 }
            };
            PrintFruits(fruitDict);

            foreach (var kvp in ModifyFruitBasket(fruitDict))
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value}");
            }
            Console.WriteLine("-------------------------");
            var students = new Dictionary<string, List<int>>
            {
                {"Philip", new List<int> { 1, 10, 9, 5 } },
                {"Leyla", new List<int> { 8, 8, 6, 10 } },
                {"Will", new List<int> { 9, 9, 5, 10 } }
            };
            Console.Write("Search for student: ");
            string name = Console.ReadLine();
            foreach (var kvp in students)
            {
                if (kvp.Key == name)
                {
                    foreach (var kvp2 in kvp.Value)
                    {
                        Console.Write($"{kvp2} ");
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("--------------------");
            var daysInMonth = new Dictionary<string, int>()
                {
                    { "January", 31 },
                    { "February", 28 },
                    { "March", 31 },
                    { "April", 30 },
                    { "May", 31 },
                    { "June", 30 },
                    { "July", 31 },
                    { "August", 31 },
                    { "September", 30 },
                    { "October", 31 },
                    { "November", 30 },
                    { "December", 31 }
                };
            foreach (var day in daysInMonth)
            {
                if (day.Value <= 30)
                {
                    Console.WriteLine($"{day.Key} {day.Value}");
                }    
            }
        }

        public static void PrintNameAndAge(Dictionary<string, int> dictionary)
        {
            foreach (KeyValuePair<string, int> kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} is {kvp.Value} years old.");
            }
            Console.WriteLine("----------------------------------");
        }

        public static string CountryAndCapital(Dictionary<string, string> capitals, string userInput)
        {
            userInput = userInput.ToLower();
            string answer = "";
            foreach (KeyValuePair<string, string> kvp in capitals)
            {
                if (kvp.Key == userInput)
                {
                    answer = kvp.Value;
                }
            }
            answer = answer.ToUpper();
            return answer;
        }

        public static void PrintFruits(Dictionary<string, int> myFruits)
        {
            foreach (KeyValuePair<string, int> kvp in myFruits)
            {
                Console.WriteLine($"You have {kvp.Value} of {kvp.Key}");
            }
        }

        public static Dictionary<string, int> ModifyFruitBasket(Dictionary<string, int> fruits)
        {
            Console.WriteLine("What fruit to add?");
            string answer = Console.ReadLine();
            int answer2;
            Console.WriteLine("How many?");
            if (int.TryParse(Console.ReadLine(), out answer2))
            {
                if (fruits.ContainsKey(answer))
                {
                    fruits[answer] = answer2;
                    Console.WriteLine("Key value has been modified.");
                }
                else
                {
                    fruits.Add(answer, answer2);
                    Console.WriteLine("Added successfully.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for the quantity.");
            }
            Console.WriteLine("-----------------");
            return fruits;
        }
    }
}
