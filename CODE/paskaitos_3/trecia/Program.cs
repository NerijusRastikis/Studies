using System;

namespace trecia
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Paskaitos data: 2024-06-12

            // RANDOM & MULTIDIMENSIONAL ARRAYS (Replay)

            //SimpleRandomArray();

            //bool[] choice = { true, false };
            //BoolTypeRandom(choice);

            //PasswordLikeRandom();

            //SumOfRandomNumbers();

            //GuessANumber();

            //int[,] checker = TwoDimensionalArrayFiller();
            //for (int i = 0; i < checker.GetLength(0); i++)
            //{
            //    for (int j = 0; j < checker.GetLength(1); j++)
            //    {
            //        Console.WriteLine(checker[i,j]);
            //    }
            //}
        }
        public static void SimpleRandomArray()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{random.Next(1, 11)} ");
            }
        }
        public static void BoolTypeRandom(bool[] choice)
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{choice[random.Next(choice.Length)]} ");
            }
        }
        public static void PasswordLikeRandom()
        {
            // PART ONE

            //var random = new Random();
            //char[] alphabet = new char[52];
            //for (int i = 0; i < 52; i++)
            //{
            //    alphabet[i] = (char)('A' + i);
            //    alphabet[i + 26] = (char)('a' + i);
            //}
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write($"{alphabet[i + random.Next(1, 25)]} ");
            //}

            // PART TWO

            var random = new Random();
            char[] alphabet = new char[52];

            for (int i = 0; i < 26; i++)
            {
                alphabet[i] = (char)('A' + i);
                alphabet[i + 26] = (char)('a' + i);
            }

            char[] recommendation = new char[10];
            for (int i = 0; i < recommendation.Length; i++)
            {
                recommendation[i] = alphabet[random.Next(alphabet.Length)];
            }

            Console.WriteLine("Recommended password: ");
            Console.WriteLine(new string(recommendation));
        }
        public static void SumOfRandomNumbers()
        {
            var random = new Random(10);
            int sum = 0, count = 0;
            for (int i = 0; i < 100; i++)
            {
                sum += random.Next(1, 6);
                count++;
            }
            Console.WriteLine($"Skaitliukas: {count}");
            Console.WriteLine($"Galutine suma: {sum}");
        }
        public static void GuessANumber()
        {
            char more = '>';
            char less = '<';
            char choice;
            int roll;
            Console.WriteLine($"Type {more} or {less} to make your guess.");
            do
            {
                Console.WriteLine("Make your guess: ");
                while (!char.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("No such choice. Please guess again: ");
                }
                Random random = new Random();
                roll = random.Next(1, 101);
                if (roll < 50 && choice == '<')
                {
                    Console.WriteLine("NICE!!! LUCKY GUESS!");
                }
                else if (roll < 50 && choice == '>')
                {
                    Console.WriteLine("Sorry, your guess was incorrect.");
                }
                else if (roll > 50 && choice == '>')
                {
                    Console.WriteLine("NICE!!! LUCKY GUESS!");
                }
                else if (choice == 'Q')
                {
                    Console.WriteLine("Quitting...");
                }
                else
                {
                    Console.WriteLine("Sorry, your guess was incorrect.");
                }
            } while (choice != 'Q');
        }
        public static int[,] TwoDimensionalArrayFiller()
        {
            var random = new Random();
            int[,] matrix = new int[7,7];
            int from = 1;
            int to = 9;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                from++;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next((i * from), (1 * i + to));

                }
            }
            return matrix;
        }
        public static void TwoDimensionalArrayEvenOdd(int[,] matrix, out int evenCountPercentage, out int oddCountPercentage)
        {
            int evenCount = 0;
            int oddCount = 0;
            for(int i = 0;i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] % 2 == 0)
                    {
                        evenCount++;
                    }
                    else
                    {
                        oddCount++;
                    }
                }
            }
            evenCountPercentage = (evenCount / (evenCount + oddCount)) * 100;
            oddCountPercentage = (oddCount / (evenCount + oddCount)) * 100;
        }

    }
}
