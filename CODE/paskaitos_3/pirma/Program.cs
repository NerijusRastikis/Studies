using System.Text;

namespace P13_Kartojimas
{
    public class Program
    {
        static void Main(string[] args)
        {
            int one, two;
            /* Vaisiai
            - Inicializuokite masyvą su šešiomis reikšmėmis: Obuolys, 7, Bananai, 7, Braškės, 7.
            - Atspausdinkite masyvo reikšmes ekrane.
            */
            //string[] vaisiai = null ; //null masyvas
            //string[] vaisiai = []; //tuscas masyvas
            string[] vaisiai = { "Obuolys" }; //masyvas su vienu elementu
            //string[] vaisiai = { "Obuolys", "Bananai", "Braškės" }; //masyvas su trimis elementais kaip salygoje
            //var vaisiai = new int[] { 1 }; //sito testuoti nereikia, nes reikia tik string masyvo
            //string[] vaisiai = { "" };
            //aisiai2(vaisiai);
            UserInput(out one, out two);
            Print(EnterValuesToTwoDimensionalArray(TwoDimensionalArrayCreation(one, two)));
        }


        static void Vaisiai()
        {
            string[] vaisiai = { "Obuolys", "7", "Bananai", "7", "Braškės", "7" };
            Console.WriteLine(string.Join(",", vaisiai));
        }


        /* Vaisiai
       - Sukurkite metodą kuris iš per parametrus perduoto vaisių masyvo padaro vaisių masyvą skaičiuojant pavadinimo raidžių kiekį
       - Atspausdina masyvo reikšmes ekrane.
       - Atspausdina visų skaitinių reikšmių sumą masyve.
          pvz. perduodami argumentai: Obuolys, Bananai, Braškės
          pvz. rezultatas ekrane: Obuolys, 7, Bananai, 7, Braškės, 7
                                  Viso raidžių - 21
      */

        public static void Vaisiai2(string[] vaisiai)
        {
            int raidziuSkaicius = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var vaisius in vaisiai)
            {
                sb.Append($"{vaisius}, {vaisius.Length}, ");
                raidziuSkaicius += vaisius.Length;
            }
            Console.WriteLine(sb.ToString().TrimEnd(',', ' '));
            Console.WriteLine($"Viso raidžių - {raidziuSkaicius}");
        }
        //blogybes:
        //daro daugiau nei viena uzduoti
        //metodas nieko negrazina, ty nera galimybes testuoti
        //blogo metodo pavadinimas
        //netikrinama ar argumentai nera null

        public static string[] VaisiaiCreateArrayWithLetterCount(string[] vaisiai)
        {
            throw new NotImplementedException();
        }

        public static int VaisiaiCalculateSumOfLetters(string[] vaisiai)
        {
            int raidziuSkaicius = 0;
            foreach (var vaisius in vaisiai)
            {
                raidziuSkaicius += vaisius.Length;
            }
            return raidziuSkaicius;
        }
        // MASYVAI

        public static void UserInput(out int one, out int two)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter the first value to set array size: ");
            Console.ForegroundColor = ConsoleColor.Green;
            while (!int.TryParse(Console.ReadLine(), out one))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Wrong number! Try again: ");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter the second value to set array size: ");
            Console.ForegroundColor = ConsoleColor.Green;
            while (!int.TryParse(Console.ReadLine(), out two))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Wrong number! Try again: ");
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
        public static int[,] TwoDimensionalArrayCreation(int one, int two)
        {
            int[,] superArray = new int[one, two];
            return superArray;
        }
        public static int[,] EnterValuesToTwoDimensionalArray(int[,] transportedArray)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fill in your array.");
            for (int i = 0; i < transportedArray.GetLength(0); i++)
            {
                for (int j = 0; j < transportedArray.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You are filling {i}-{j} cell: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    transportedArray[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return transportedArray;
        }
        public static void Print(int[,] arrayToBePrinted)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your array looks like this:");
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < arrayToBePrinted.GetLength(0); i++)
            {
                for (int j = 0; j < arrayToBePrinted.GetLength(1); j++)
                {
                    Console.Write($"{arrayToBePrinted[i,j]} ");
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}