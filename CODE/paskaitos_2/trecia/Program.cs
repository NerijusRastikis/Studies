using System;

namespace trecia
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Paskaitos data: 2024-06-05

            // ARRAYS

            //int Min = 0;
            //int Max = 100;

            //int[] randomIntNumbers = new int[10];

            //Random randNum = new Random();
            //for (int i = 0; i < randomIntNumbers.Length; i++)
            //{
            //    randomIntNumbers[i] = randNum.Next(Min, Max);
            //}
            int[] simpleArray = { 1, 2, 3, 4, 5, 6, 7, 8 };
            #region Execution of methods
            //FirstOfFirst();
            //SecondOfFirst();
            //ThirdofFirst();
            //FourthOfFIrst();

            //StringArrayToCharArray(UserInput());
            //Console.WriteLine($"{SentenceFirstLetterToChar(UserInput())}");
            //Console.WriteLine($"{SentenceLastLetterToChar(UserInput())}");

            #region SortingNumbersAscending
            //for (int i = 0; i < randomIntNumbers.Length; i++)
            //{
            //    Console.Write($"{randomIntNumbers[i]} ");
            //}
            //Console.WriteLine();
            //int[] gettingSortedNumbers = SortingNumbersAscending(randomIntNumbers);
            //for (int i = 0; i < gettingSortedNumbers.Length; i++)
            //{
            //    Console.Write($"{gettingSortedNumbers[i]} ");
            //}
            #endregion
            #region SortingNumbersDescending
            //for (int i = 0; i < randomIntNumbers.Length; i++)
            //{
            //    Console.Write($"{randomIntNumbers[i]} ");
            //}
            //Console.WriteLine();
            //int[] gettingSortedNumbers = SortingNumbersDescending(randomIntNumbers);
            //for (int i = 0; i < gettingSortedNumbers.Length; i++)
            //{
            //    Console.Write($"{gettingSortedNumbers[i]} ");
            //}
            #endregion
            #region InsertingNumberIntoArray
            //int[] arrayToBePrinted = InsertingNumberIntoArray(simpleArray);
            //for (int i = 0; i < arrayToBePrinted.Length; i++)
            //{
            //    Console.Write($"{arrayToBePrinted[i]} ");
            //}
            #endregion
            #region RemovingNumberFromArray
            //for (int i = 0; i < simpleArray.Length; i++)
            //{
            //    Console.Write($"{simpleArray[i]} ");
            //}
            //int[] arrayToBePrinted = RemovingNumberFromArray(simpleArray);
            //for (int i = 0; i < arrayToBePrinted.Length; i++)
            //{
            //    Console.Write($"{arrayToBePrinted[i]} ");
            //}

            #endregion
            #endregion
        }

        #region Simple Array Tasks (4)
        static void FirstOfFirst()
        {
            int[] array1 = { 1, 2, 3 };
            int[] array2 = new int[3];
            for (int i = 0; i < array1.Length; i++)
            {
                array2[i] = array1[i] * array1[i];
                Console.WriteLine(array2[i]);
            }
        }
        static void SecondOfFirst()
        {
            int sum = 0;
            int[] array1 = { 1, 2, 3 };
            for (int i = 0; i < array1.Length; i++)
            {
                sum = sum + array1[i];
            }
            Console.WriteLine(sum);
        }
        static void ThirdofFirst()
        {
            int max = int.MinValue;
            int[] array1 = { 1, 2, 3 };
            for (int i = 0; i < array1.Length; i++)
            {
                if (max <= array1[i])
                {
                    max = array1[i];
                }
            }
            Console.WriteLine(max);
        }
        static void FourthOfFIrst()
        {
            int[] array1 = { 1, 2, 3 };
            for (int i = array1.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(array1[i]);
            }
        }
        #endregion
        #region Advanced Array Tasks (7)
        static string UserInput()
        {
            Console.Write("Your input: ");
            string userInput = Console.ReadLine();
            return userInput;
        }
        static char[] StringArrayToCharArray(string word)
        {
            char[] wordToChars = word.ToCharArray();
            // optional //
            for (int i = 0; i < wordToChars.Length; i++)
            {
                Console.WriteLine(wordToChars[i]);
            }
            // end of optional //
            return wordToChars;
        }
        static char SentenceFirstLetterToChar(string sentence)
        {
            char[] wordToChars = sentence.ToCharArray();

            return wordToChars[0];
        }
        static char SentenceLastLetterToChar(string sentence)
        {
            char[] wordToChars = sentence.ToCharArray();

            return wordToChars[wordToChars.Length - 1];
        }
        static int[] SortingNumbersAscending(int[] numbers)
        {
            int length = numbers.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            return numbers;
        }
        static int[] SortingNumbersDescending(int[] numbers)
        {
            int length = numbers.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (numbers[j] < numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            return numbers;
        }
        static int[] InsertingNumberIntoArray(int[] numbers)
        {
            int getUserInput = int.Parse(UserInput());
            int[] newArray = new int[numbers.Length + 1];
            for (int i = 0; i < numbers.Length; i++)
            {
                newArray[i] = numbers[i];
            }
            newArray[numbers.Length] = getUserInput;
            return newArray;
        }
        static int[] RemovingNumberFromArray(int[] numbers)
        {
            Console.WriteLine("Enter array element to be removed.");
            int getUserInput = int.Parse(UserInput());
            int[] newArray = new int[numbers.Length - 1];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == getUserInput)
                {
                    numbers[i] = 101;
                }
            }
            for (int i = 0; i < newArray.Length; i++)
            {
                if (numbers[i] != 101)
                {
                    newArray[i] = numbers[i];
                }
            }
            return newArray;
        }
        #endregion
    }
}
