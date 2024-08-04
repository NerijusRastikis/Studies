namespace ProjectATM.Models;

public class Transaction
{
    public Guid Id { get; set; }
    public string TypeOfTransaction { get; set; }
    public int Amount { get; set; }
    public DateTime DateOfTransaction { get; set; }

    public override string ToString()
    {
        return $"{DateOfTransaction:yyyy/MM/dd HH:mm} {TypeOfTransaction}: {Amount}Eur {Id}";

    }
}
