namespace DoomsdayWarehouse.Models
{
    public class WeaponItem : InventoryItem
    {
        public override InventoryItem FromCSV(string csvLine)
        {
            string[] values = csvLine.Split(',');
            return new WeaponItem
            {
                Name = values[0],
                Weight = double.Parse(values[1].Replace("kg", ""))
            };
        }

        public override string ToCSV()
        {
            return $"{Name},{Weight}kg";
        }
    }

}
