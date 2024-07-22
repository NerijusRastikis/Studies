public class MedicalItem : InventoryItem
{
    public DateTime ExpirationDate { get; set; }
    public string Diseases { get; set; }

    public MedicalItem(string name, double weight, DateTime expirationDate, string diseases)
        : base(name, weight)
    {
        ExpirationDate = expirationDate;
        Diseases = diseases;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {ExpirationDate:yyyy-MM-dd}, {Diseases}";
    }
}