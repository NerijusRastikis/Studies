public class Transaction
{
    public DateTime Date { get; private set; }
    public decimal Amount { get; private set; }
    public string Description { get; private set; }

    public Transaction(DateTime date, decimal amount, string description)
    {
        Date = date;
        Amount = amount;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Date} - {Amount:C} - {Description}";
    }
}
