using ProjectATM.Models;
using ProjectATM.Repositories.Interfaces;
using ProjectATM.Services.Interfaces;

namespace ProjectATM.Services;

public class TransactionService(ITransactionRepository transactionRepository) : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;

    public void AddTransaction(Transaction transaction)
    {
        _transactionRepository.AddTransaction(transaction);
    }

    public List<Transaction> GetTransactionsForAccount(Guid accountId, int count = 0)
    {
        var transactionList = _transactionRepository.GetTransactionsByAccountId(accountId);
        if (count == 0)
        {
            return transactionList.ToList();
        }
        return transactionList.OrderByDescending(x => x.DateOfTransaction).Take(count).ToList();
    }
}
