namespace Extensions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            string? word = "";
            Console.Write("Enter number: ");
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(number);
            }
            Console.WriteLine($"Is number positive: {number.IsPossitive()}");
            Console.WriteLine($"Is number even: {number.IsEven()}");
            Console.WriteLine($"Is entered number more than {MyExtensions.number1}: {number.IsMore()}");
            Console.WriteLine("-----------------");
            Console.Write("Enter word or sentence: ");
            word = Console.ReadLine();
            Console.WriteLine($"Does word/sentence have any spaces: {word.HasSpaces()}");
            Console.WriteLine("-----------------");
            Console.Write("Enter fullName: ");
            string firstName = Console.ReadLine();
            var temp = firstName.Split(' ');
            string editedFirstName = "";
            foreach ( var i in temp )
            {
                editedFirstName += i;
            }
            Console.WriteLine($"Your email address should be: {editedFirstName.Trim(' ').CompositeEmailAddress(1990, "gmail")}");
            Console.WriteLine("-----------------");
            var list = new List<string>();
            list.Add("Vienas");
            list.Add("Du");
            list.Add("Trys");
            list.Add("Keturi");
            list.Add("Penki");
            foreach ( var i in list.FindAndReturnIfEqual() )
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------");
            foreach (var i in list.EveryOtherWord())
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------");
            var rFF = File.ReadAllLines("C:\\Users\\nerij\\Documents\\GitHub\\dotnet\\Extensions\\Extensions\\text.txt");
            List<object> list2 = rFF.ToList<object>();
            foreach (var i in list2.EveryOtherWord())
            {
                Console.WriteLine(i);
            }
        }
    }
}
