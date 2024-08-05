using RestoranasPOS.Interfaces;
using RestoranasPOS.Models;
using RestoranasPOS.Services;

namespace RestoranasPOS
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IDisplay display = new Display();
            IFileManager fileManager = new FileManager();

            var restaurantPOS = new POS_Logic(fileManager, display);
            restaurantPOS.Start();
        }
    }
}
