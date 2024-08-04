using ProjectATM.Models;

namespace ProjectATM.Services.Interfaces;

public interface IAccountService
{
    int GetBalance(Guid accountId);
    bool Withdraw(Guid accountId, int amount);
    List<Transaction> GetTransactionsForAccount(Guid accountId, int count = 0);
}
