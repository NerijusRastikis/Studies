using static OOP_Kartojimas1.Program;

namespace OOP_Kartojimas1
{
    public class OrderService : IOrderService
    {
        private readonly List<IMyLogger> _loggers;
        public OrderService(IMyLogger logger)// Priklausomybių injekcija per konstruktorių
        {
            _loggers = new List<IMyLogger> { logger };
        }

        public OrderService(List<IMyLogger> loggers)
        {
            _loggers = loggers;
        }

        public Order PlaceOrder()
        {
            // Kažkokia biznio logika
            var order = new Order(0.1, 100);
            Log($"Order has been placed. Price={order.Price}, Ammount={order.Amount} ");
            return order;
        }

        private void Log(string message) => _loggers.ForEach(logger => logger.Log(message));

    }

}
