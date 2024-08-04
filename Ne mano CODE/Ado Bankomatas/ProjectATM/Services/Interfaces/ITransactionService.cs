using ProjectATM.Models;

namespace ProjectATM.Services.Interfaces;

public interface ITransactionService
{
    List<Transaction> GetTransactionsForAccount(Guid accountId, int count = 0);
    void AddTransaction(Transaction transaction);
}
