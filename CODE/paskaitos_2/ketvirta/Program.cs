using System.Text;

namespace ketvirta
{
    public class ForEachLoops
    {
        static void Main(string[] args)
        {
            // Paskaitos data: 2024-06-06

            // FOREACH

            int[] numbers = { 1, 7, 4, 2, 9, 10, -15, -1, 5, -37 };
            //int[] forGPM = { 10, 100, 200, 450, 155, 3005 };

            //Console.WriteLine($"{ForEachLoopAverageNumberInArray(numbers)}");

            //int[] positiveNumbers = ForEachLoopPositiveNumbersInArray(numbers);

            //foreach (var positiveNumber in positiveNumbers)
            //{
            //    Console.WriteLine(positiveNumber);
            //}

            //Console.WriteLine(ForLoopGPM(forGPM));

            //Console.WriteLine(ManipulaticStrings());

            //string[] typeOfCards = { "Bugnu", "Cirvu", "Vynu", "Kryziu" };
            //string[] cardsStrength = { "Dviake", "Triake", "Keturake",
            //    "Penkiake", "Sesiaake", "Septinake", "Astunake", "Devinake",
            //    "Desimtake", "Bernelis", "Dama", "Karalius", "Tuzas" };
            //string resulted = (ConstructDeck(typeOfCards, cardsStrength)).ToString();
            //Console.WriteLine(resulted);
        }
        public static int ForEachLoopAverageNumberInArray(int[] numbers)
        {
            int average = 0;
            foreach (var number in numbers)
            {
                average += number;
            }
            return average;
        }
        public static int[] ForEachLoopPositiveNumbersInArray(int[] numbers)
        {
            // Suskaiciuoja kiek bus teigiamu skaiciu,
            // kad galetu sukurti butent tokio dydzio nauja masyva
            int count = 0;
            foreach (var number in numbers)
            {
                if (number > 0)
                {
                    count++;
                }
            }
            // sukuria nauja masyva tokio dydzio, kiek buvo rasta teigiamu skaiciu
            int[] positiveNumbers = new int[count];
            // atstatomas count, kad butu kaip rodykle naujam masyvui
            count = 0;
            // skaiciuoja vel is naujo teigiamus skaicius
            foreach (var number in numbers)
            {
                if (number > 0)
                {
                    // deda skaicius is seno i nauja masyva jei atitinka salyga
                    // dydziu nevirsija, nes anksciau jau suskaiciavo kiek teigiamu
                    positiveNumbers[count] = number;
                    count++;
                }
            }
            return positiveNumbers;
        }
        public static double ForLoopGPM(int[] forGPM)
        {
            double gpm = 0;
            foreach (double gpmElement in forGPM)
            {
                gpm += gpmElement;
            }
            gpm = gpm * 0.15;
            return gpm;
        }
        public static string UserInput()
        {
            Console.Write("Your Input: ");
            return Console.ReadLine();
        }
        public static StringBuilder ManipulaticStrings()
        {
            string usersSentence = UserInput();
            string[] words = usersSentence.Split(' ');
            StringBuilder sb = new StringBuilder();
            foreach (var word in words)
            {
                if (word.Length >= 5)
                {
                    sb.Append(word);
                    sb.Append(' ');
                }
            }
            return sb;
        }
        public static StringBuilder ConstructDeck(string[] types, string[] cards)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var type in types)
            {
                foreach (var card in cards)
                {
                    sb.AppendLine($"{type} {card}");
                }
            }
            return sb;
            // GitHub Test
        }
    }
}