using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    internal static class MyExtensions
    {
        public static int number1 = 100;
        public static bool IsPossitive(this int number)
        {
            if (number < 0) return false;
            else if (number == 0) return false;
            return true;
        }
        public static bool IsEven(this int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }
            return false;
        }
        public static bool IsMore(this int number)
        {
            if (number > number1) return true;
            return false;
        }
        public static bool HasSpaces(this string word)
        {
            if (word.Contains(" ")) return true;
            return false;
        }
        public static string CompositeEmailAddress(this string fullName, int yearOfBirth, string domain)
        {
            return $"{fullName}{yearOfBirth}@{domain}.com";
        }
        public static List<string> FindAndReturnIfEqual(this List<string> list)
        {
            List<string> answer = new List<string>();
            string word = "Vienas";
            foreach (var item in list)
            {
                if (word == item)
                {
                    answer.Add(item);
                    return answer;
                }
            }
            return null;
        }
        public static List<T> EveryOtherWord<T>(this List<T> list)
        {
            int counter = 1;
            List<T> answer = new List<T>();
            foreach (var item in list)
            {
                if (counter % 2 != 0)
                {
                    answer.Add(item);
                }
                counter++;
            }
            return answer;
        }
    }
}
