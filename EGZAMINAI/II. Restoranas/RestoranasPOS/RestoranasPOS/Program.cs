using RestoranasPOS.Services;

namespace RestoranasPOS
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var restaurantPOS = new Display();
            restaurantPOS.Start();
        }
    }
}
