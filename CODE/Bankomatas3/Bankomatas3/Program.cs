namespace Bankomatas3
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
            //Bankomato 3 iteracija
            #region --- PATHS
            string pathUsers = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\Bankomatas3\\Bankomatas3\\Users.csv";
            string pathATM = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\Bankomatas3\\Bankomatas3\\ATM_Funds.csv";
            string pathLogs = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\Bankomatas3\\Bankomatas3\\Logs.txt";
            #endregion
            var start = new ATM_Logic(pathUsers, pathATM, pathLogs);
            start.ProgramFlowController();
        }
    }
}
