using System.Text;

namespace antra
{
    public class Program
    {
        static void Main(string[] args)
        {
            //YesterdaysRefresherTaskForLoops();
            //FirstTask();
            //SecondTask();
            //ThirdTask();
            //FourthTask();
            //FifthTask();
            //StringBuilderis();
            //FirstBuilder();
        }
        static void YesterdaysRefresherTaskForLoops()
        {
            //kartojimas for paskaitos užduotis
            //For loop
            //Incremental
            //Initial value 100
            //Iteration count 100
            //Step 3
            //Display Value Accumulation (variable name 'sum').
            //Use string Composite Formatting to display this result. egz. "Sum: 24850"
            //Display Iteration Count (variable name 'iterationCount').
            //Use string Interpolation to display this result. egz. "Iteration count: 100"
            int sum = 0, iterationCount = 0;
            for (int i = 100; i < 400; i+=3)
            {
                sum += i;
                iterationCount++;
            }
            Console.WriteLine("Sum: {0}", sum);
            Console.WriteLine($"Iteration count: {iterationCount}");
        }
        #region
        static void FirstTask()
        {
            int a = 10;
            int b = 5;
            int c = 8;

            int max = a;
            if (b > max)
            {
                max = b;
            }
            if (c > max)
            {
                max = c; // priskirti naujam didziausiam
            }
            Console.WriteLine("The maximum value is: " + max);
        }
        static void SecondTask() 
        {
            string firstName = "John";
            string lastName = "Doe";
            string fullName = $"{firstName} {lastName}"; // pataisytas kodas, kad spausdintu tarpa
            Console.WriteLine($"Full name: {fullName}");
        }
        static void ThirdTask()
        {
            int counter = 1; // turi buti nuo 1
            while (counter <= 10) 
            {
                Console.WriteLine("count: " + counter);
                counter++; //Is dekrementinio pataisyta i inkrementini
            }
        }
        static void FourthTask()
        {
            for (int i = 1; i <=5; i++) // pakeistas while ciklas i For cikla, kadangi ivedamos visos For dalys, tik naudojas while cikla
            {
                Console.WriteLine(i);
            }
        }
        static void FifthTask()
        {
            string name1 = "John";
            string name2 = "john";
            name1 = name1.ToLowerInvariant();
            name2 = name2.ToLowerInvariant();
            if (name1.Equals(name2))
            {
                Console.WriteLine("Names are equal.");
            }
            else
            {
                Console.WriteLine("Names are different.");
            }
        }
        #endregion
        static void StringBuilderis()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("Hello! ");
            //sb.AppendLine("How are you?");
            //sb.AppendLine("!");
            //string result = sb.ToString();
            //Console.WriteLine(sb);
            for (int i = 0; i < 10; i++)
            {
                sb.Append("0,");
            }
            Console.WriteLine(sb.ToString());
        }
        static void FirstBuilder()
        {
            StringBuilder sb = new StringBuilder();
            Console.Write("Iveskite eilute: ");
            sb.AppendLine(Console.ReadLine());
            string word1 = sb.ToString();
            char[] word2 = word1.ToCharArray();
            Array.Reverse(word2);
            Console.Write($"Apversta eilute: {word2}");
        }
        static void SecondBuilder()
        {
            //StringBuilder sb = new StringBuilder();
            //Console.Write("Iveskite eilute: ");
            //sb.AppendLine(Console.ReadLine());
            //string word1 = sb.ToString();
            //char[] word2 = word1.ToCharArray();
            // Destytojas padare be StringBuilder, tai blet... As irgi taip moku, bet galvojau reikalinga su StringBuilder butinai daryti, nes tokia gi tema
        }
        public static StringBuilder sbulder = new StringBuilder();
        public static string CreateCsvLine(string field1, string field2, string field3)
        {
            Console.Write("Add 1st field: ");
            field1 = Console.ReadLine();
            Console.Write("Add 2nd field: ");
            field2 = Console.ReadLine();
            Console.Write("Add 3rd field: ");
            field3 = Console.ReadLine();
            if (string.IsNullOrEmpty(field1) && field1.Length > 10 && field1.Contains(","))
            {
                //CreateCsvLine_ShouldThrowArgumentException_Field1Empty
                throw new ArgumentException("Field cannot be empty, takes too much space or has comma in it!");
            }
            else if (string.IsNullOrEmpty(field2) && field2.Length > 11)
            {
                //CreateCsvLine_ShouldThrowArgumentException_Field1Empty
                throw new ArgumentException("Field cannot be empty!");
            }
            else if (field3.Length > 9)
            {
                sbulder.Append(field1);
                sbulder.Append(field2);
                return sbulder.ToString();
            }
            sbulder.Append(field1);
            sbulder.Append(field2);
            sbulder.Append(field3);
            return sbulder.ToString();
            //throw new NotImplementedException();
        }
    }
}
