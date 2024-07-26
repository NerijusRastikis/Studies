namespace DoomsdayWarehouse.Models
{
    public class FoodItem : InventoryItem
    {
        public DateTime ExpirationDate { get; set; }
        public int Calories { get; set; }

        public override InventoryItem FromCSV(string csvLine)
        {
            string[] values = csvLine.Split(',');
            return new FoodItem
            {
                Name = values[0],
                Weight = double.Parse(values[1].Replace("kg", "")),
                ExpirationDate = DateTime.Parse(values[2]),
                Calories = int.Parse(values[3].Replace("kcal", ""))
            };
        }

        public override string ToCSV()
        {
            return $"{Name},{Weight}kg,{ExpirationDate},{Calories}kcal";
        }
    }
}
