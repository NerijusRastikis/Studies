namespace RestoranasPOS.Interfaces
{
    public interface IDisplay
    {
        Dictionary<string, int> TableStatus { get; set; }

        string IsTableTaken();
        void MainMenu();
        void SelectWaiter();
        void SelectTable();
        void TakeOrder_Alko(Dictionary<string, decimal> alkos);
        void TakeOrder_Cold(Dictionary<string, decimal> colds);
        void TakeOrder_Hot(Dictionary<string, decimal> hots);
        void TakeOrder_NonAlko(Dictionary<string, decimal> nonalkos);
        void TakeOrder_SelectCategory();
        void TakeOrder_Snacks(Dictionary<string, decimal> snacks);
        void ViewOrder();
        void ManageTableStatus();
        void ReserveTable();
        void Exit();
        Dictionary<string, List<decimal>> OrderInfo { get; set; }
        List<string> ClientInfo { get; set; }
        int MenuChoice { get; set; }
    }
}