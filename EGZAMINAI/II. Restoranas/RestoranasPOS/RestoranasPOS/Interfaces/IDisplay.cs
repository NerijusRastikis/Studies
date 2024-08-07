namespace RestoranasPOS.Interfaces
{
    public interface IDisplay
    {
        int TableStatus { get; set; }

        string IsTableTaken();
        int MainMenu();
        void SelectWaiter();
        void SelectTable();
        void TakeOrder_Alko(Dictionary<string, decimal> alkos);
        void TakeOrder_Cold(Dictionary<string, decimal> colds);
        void TakeOrder_Hot(Dictionary<string, decimal> hots);
        int TakeOrder_NonAlko(Dictionary<string, decimal> nonalkos);
        int TakeOrder_SelectCategory();
        void TakeOrder_Snacks(Dictionary<string, decimal> snacks);
        Dictionary<string, List<decimal>> OrderInfo { get; set; }
    }
}