namespace DoomsdayWarehouse.Models
{
    public class MedicalItem : InventoryItem
    {
        public DateTime ExpirationDate { get; set; }
        public string Diseases { get; set; }

        public override InventoryItem FromCSV(string csvLine)
        {
            string[] values = csvLine.Split(',');
            return new MedicalItem
            {
                Name = values[0],
                Weight = double.Parse(values[1].Replace("kg", "")),
                ExpirationDate = DateTime.Parse(values[2]),
                Diseases = values[3]
            };
        }

        public override string ToCSV()
        {
            return $"{Name},{Weight}kg,{ExpirationDate},{Diseases}";
        }
    }

}
