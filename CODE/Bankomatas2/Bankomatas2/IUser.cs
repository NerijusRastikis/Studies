public interface IUser
{
    string CardNumber { get; }
    string Pin { get; }
    decimal Balance { get; set; }
    List<Transaction> Transactions { get; }

    void AddTransaction(Transaction transaction);
}
