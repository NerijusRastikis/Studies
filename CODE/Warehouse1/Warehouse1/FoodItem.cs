public class FoodItem : InventoryItem
{
    public DateTime ExpirationDate { get; set; }
    public int Calories { get; set; }

    public FoodItem(string name, double weight, DateTime expirationDate, int calories)
        : base(name, weight)
    {
        ExpirationDate = expirationDate;
        Calories = calories;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {ExpirationDate:yyyy-MM-dd}, {Calories}kcal";
    }
}