namespace RestoranasPOS.Interfaces
{
    public interface IDisplay
    {
        int TableStatus { get; set; }

        string IsTableTaken();
        int MainMenu();
        void SelectWaiter();
        void SelectTable();
        void TakeOrder_Alko(Dictionary<string, int> alkos);
        void TakeOrder_Cold(Dictionary<string, int> colds);
        void TakeOrder_Hot(Dictionary<string, int> hots);
        void TakeOrder_NonAlko(Dictionary<string, int> nonalkos);
        int TakeOrder_SelectCategory();
        void TakeOrder_Snacks(Dictionary<string, int> snacks);
    }
}