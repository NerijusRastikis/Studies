namespace Bankomatas1
{
    internal class Program
    {
        public static string logo = @"__________                __                         __                 
\______   \_____    ____ |  | ______   _____ _____ _/  |______    ______
 |    |  _/\__  \  /    \|  |/ /  _ \ /     \\__  \\   __\__  \  /  ___/
 |    |   \ / __ \|   |  \    <  <_> )  Y Y  \/ __ \|  |  / __ \_\___ \ 
 |______  /(____  /___|  /__|_ \____/|__|_|  (____  /__| (____  /____  >
        \/      \/     \/     \/           \/     \/          \/     \/ 

";
        static void Main(string[] args)
        {
            //Savarankiškas bandomasis darbas 2024-07-29
            string path = ".\\..\\..\\Credentials.csv";
            string pathLog = ".\\..\\..\\Logs.txt";
            var bs = new BankomatoSistema(path, pathLog);
            bs.Communicator();
        }
    }
}
