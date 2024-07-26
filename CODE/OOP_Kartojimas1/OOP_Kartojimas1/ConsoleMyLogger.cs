namespace OOP_Kartojimas1
{
    public class ConsoleMyLogger : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
