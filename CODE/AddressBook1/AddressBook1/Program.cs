namespace AddressBook1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = ".\\..\\..\\contacts.csv";
            var start = new ProgramUI();
            start.ShowMenu();
        }
    }
}
