namespace OOP_Kartojimas1
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            //Paskaitos data: 2024-07-25

            //Interface

            /*
             * 
             * 1. Pakeiskite pateiką programą taip, kad vietoje ConsoleMyLogger klasės būtų naudojamas FileMyLogger klasės objektas
   - Keisti galima tik Main metodą, visą kitą kodą palikti nepakeistą.
   - Galima pridėti naują klasę, bet nekeisti esamų.
             *
             */
            //IMyLogger logger = new ConsoleMyLogger();
            //OrderService orderService = new OrderService(logger);
            //orderService.PlaceOrder();

            IMyLogger logger = new FileMyLogger("file.txt");
            OrderService orderService = new OrderService(logger);
            orderService.PlaceOrder();
        }
    }
}
