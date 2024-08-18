using RestoranasPOS.Interfaces;
using RestoranasPOS.Models;
using RestoranasPOS.Services;

namespace RestoranasPOS
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            #region Paths
            string alkodrinksPath = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\EGZAMINAI\\II. Restoranas\\RestoranasPOS\\RestoranasPOS\\DB\\alkodrinks.csv";
            string nonalkodrinksPath = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\EGZAMINAI\\II. Restoranas\\RestoranasPOS\\RestoranasPOS\\DB\\nonalkodrinks.csv";
            string snacksPath = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\EGZAMINAI\\II. Restoranas\\RestoranasPOS\\RestoranasPOS\\DB\\snacks.csv";
            string coldfoodPath = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\EGZAMINAI\\II. Restoranas\\RestoranasPOS\\RestoranasPOS\\DB\\coldfood.csv";
            string hotfoodPath = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\EGZAMINAI\\II. Restoranas\\RestoranasPOS\\RestoranasPOS\\DB\\hotfood.csv";
            string chequesPath = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\EGZAMINAI\\II. Restoranas\\RestoranasPOS\\RestoranasPOS\\DB\\cheques.csv";
            string clientsPath = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\EGZAMINAI\\II. Restoranas\\RestoranasPOS\\RestoranasPOS\\DB\\Reservations.csv";
            #endregion
            IEmailService emailService = new EmailService();
            IDisplay display = new Display(emailService);
            IFileManager fileManager = new FileManager(alkodrinksPath, nonalkodrinksPath, snacksPath, coldfoodPath, hotfoodPath, chequesPath, clientsPath);

            var restaurantPOS = new POS_Logic(fileManager, display);
            restaurantPOS.Start();
        }
    }
}
