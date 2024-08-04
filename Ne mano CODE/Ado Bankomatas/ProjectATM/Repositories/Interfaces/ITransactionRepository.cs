using ProjectATM.Models;

namespace ProjectATM.Repositories.Interfaces;

public interface ITransactionRepository
{
    List<Transaction> LoadTransactions();
    IEnumerable<Transaction> GetTransactionsByAccountId(Guid accountId);
    void AddTransaction(Transaction transaction);
    void Save();
}
