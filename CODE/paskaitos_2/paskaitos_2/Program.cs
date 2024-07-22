namespace paskaitos_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // paskaitos data: 2024-06-03

            // FOR LOOP //

            //SimpleForLoop();
            //DecrimentalForLoop();
            //IncreaseByTwo();
            //ForLoopBreak();
            //NestedForLoop();
            //ReiksmesAkumuliatorius();
            //FirstTask();
            //SecondTask();
            //ThirdTask();
            //FourthTask();
            //PrintEvenNumbers();
            //PrintNumbersDescending();
            //Console.WriteLine(CountEvenNumbersWithError());
            //PrintFibonacciWithError();
            //Console.WriteLine(SumEvenNumbersWithError());
            //PriceTask();
            //CoffeeCheck();
            RestaurantManager();
        }
        // EXAMPLES
        #region

        static void SimpleForLoop()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void DecrimentalForLoop()
        {
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine(i);
            }
        }
        static void IncreaseByTwo()
        {
            for (int i = 0; i < 10; i += 2)
            {
                Console.WriteLine(i);
            }
        }
        static void ForLoopBreak()
        {
            int index = 5;
            for (int i = 0; i <= 10; i++)
            {
                if (i == index)
                {
                    break;
                }
                Console.WriteLine(i);
            }
        }
        static void NestedForLoop()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"i: {i}");
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine($"- j: {j}");
                }
            }
        }
        static void ReiksmesAkumuliatorius()
        {
            int suma = 0;
            for (int i = 0; i <= 10; i++)
            {
                suma += i;
            }
            Console.WriteLine($"Suma: {suma}");
        }
        #endregion
        // TASKS
        #region
        static void FirstTask()
        {
            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void SecondTask()
        {
            for (int i = 20; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
        }
        static void ThirdTask()
        {
            for (int i = 20; i > 0; i -= 3)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void FourthTask()
        {
            int stop = 13;
            for (int i = 1; i <= 15; i++)
            {
                if (i == stop)
                {
                    break;
                }
                Console.WriteLine(i);
            }
        }
        #endregion

        // Užduotis: Surasti visus lyginius skaičius intervale nuo 1 iki 20 ir atspausdinti juos.
        // Tikslas: Suprasti ciklo naudojimą ir sąlygos tikrinimą.
        public static void PrintEvenNumbers()
        {
            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        // Užduotis: Išvesti skaičius nuo 10 iki 1 mažėjančia tvarka.
        // Tikslas: Suprasti ciklo naudojimą su dekrementavimu.
        public static void PrintNumbersDescending()
        {
            for (int i = 10; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
        }

        // Užduotis: Suskaičiuoti kiek yra lyginių skaičių intervale nuo 1 iki 10.
        // Tikslas: Suprasti sąlygos tikrinimą cikle ir aptikti logines klaidas.
        public static int CountEvenNumbersWithError()
        {
            int count = 0;
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        // Užduotis: Atspausdinti pirmas 10 Fibonacio sekos skaičių.
        // Tikslas: Suprasti ciklo naudojimą generuojant seką ir aptikti logines klaidas.
        public static void PrintFibonacciWithError()
        {
            int a = 0, b = 1, c;
            Console.WriteLine(a);
            Console.WriteLine(b);

            for (int i = 1; i <= 8; i++)
            {
                c = a + b;
                a = b;
                b = c;
                Console.WriteLine(b);
            }
        }


        // Užduotis: Išvesti kiekvieno skaičiaus nuo 1 iki 10 kvadratą.
        // Tikslas: Suprasti kvadrato skaičiavimą cikle ir aptikti logines klaidas.
        public static void PrintSquaresWithError()
        {
            for (int i = 1; i >= 10; i++)
            {
                int square = i * i;
                Console.WriteLine($"Skaičius: {i}, Kvadratas: {square}");
            }
        }

        // Užduotis: Apskaičiuoti lyginių skaičių nuo 1 iki 10 sumą.
        // Tikslas: Suprasti lyginių skaičių sumavimą ir aptikti logines klaidas.
        public static int SumEvenNumbersWithError()
        {
            int sum = 0;
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
        // 1 Užduotis: Jūs esate parduotuvės savininkas ir norite atspausdinti kainas nuo 1 iki 10 dolerių.
        // Tikslas: Atspausdinti kainas nuo 1 iki 10 dolerių. Čia jau svarbu prasmingi kintamųjų pavadinimai.
        static void PriceTask()
        {
            char dollarSign = '$';
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{i}. {i}{dollarSign}");
            }
        }
        // 2 Užduotis: Jūs esate kavos aparatų technikas ir turite patikrinti 5 kavos aparatus nuo pirmo iki penkto.
        // Tikslas: Atspausdinti pranešimą apie kiekvieno aparato patikrinimą. Čia jau svarbu prasmingi kintamųjų pavadinimai.
        static void CoffeeCheck()
        {
            string isChecked = "coffee machine has been checked successfully.";
            for (int i = 1; i <= 5; i++)
            {
                switch (i)
                {
                    case 1:
                        Console.WriteLine($"The {i}st {isChecked}");
                        break;
                    case 2:
                        Console.WriteLine($"The {i}nd {isChecked}");
                        break;
                    case 3:
                        Console.WriteLine($"The {i}rd {isChecked}");
                        break;
                    default:
                        Console.WriteLine($"The {i}th {isChecked}");
                        break;
                }
            }
        }
        // 3 Užduotis: Jūs esate restorano vadybininkas ir turite patikrinti 8 staliukų rezervacijas.
        // Tikslas: Atspausdinti pranešimą apie kiekvieno staliuko rezervacijos tikrinimą. Čia jau svarbu prasmingi kintamųjų pavadinimai.
        static void RestaurantManager()
        {
            string isReserved = "table has been reserved successfully.";
            for (int i = 1; i <= 8; i++)
            {
                switch (i)
                {
                    case 1:
                        Console.WriteLine($"The {i}st {isReserved}");
                        break;
                    case 2:
                        Console.WriteLine($"The {i}nd {isReserved}");
                        break;
                    case 3:
                        Console.WriteLine($"The {i}rd {isReserved}");
                        break;
                    default:
                        Console.WriteLine($"The {i}th {isReserved}");
                        break;
                }
            }
        }
    }
}
