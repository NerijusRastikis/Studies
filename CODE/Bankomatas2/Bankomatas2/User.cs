public class User : IUser
{
    public string CardNumber { get; private set; }
    public string Pin { get; private set; }
    public decimal Balance { get; set; }
    public List<Transaction> Transactions { get; private set; }

    public User(string cardNumber, string pin, decimal balance)
    {
        CardNumber = cardNumber;
        Pin = pin;
        Balance = balance;
        Transactions = new List<Transaction>();
    }

    public void AddTransaction(Transaction transaction)
    {
        Transactions.Add(transaction);
        if (Transactions.Count > 5)
        {
            Transactions.RemoveAt(0);
        }
    }

    public void SetTransactions(List<Transaction> transactions)
    {
        Transactions = transactions;
    }
}
