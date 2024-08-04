using ProjectATM.Models;
using ProjectATM.Repositories.Interfaces;
using ProjectATM.Services.Interfaces;

namespace ProjectATM.Services;

public class AccountService(IAccountRepository accountRepository, ITransactionService transactionService) : IAccountService
{
    private readonly IAccountRepository _accountRepository = accountRepository;
    private readonly ITransactionService _transactionService = transactionService;

    public int GetBalance(Guid accountId)
    {
        return _accountRepository.GetAccount(accountId).Balance;
    }
    public bool Withdraw(Guid accountId, int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Klaida! Maziau negu 0 negalima isimti");
            return false;
        }

        var account = _accountRepository.GetAccount(accountId);

        if (account.Balance < amount)
        {
            Console.WriteLine("Klaida! Nepakanka lesu saskaitoje");
            return false;
        }
        _transactionService.AddTransaction(new Transaction()
        {
            Id = accountId,
            TypeOfTransaction = "Withdraw",
            Amount = amount,
            DateOfTransaction = DateTime.Now
        });

        account.Balance -= amount;
        _accountRepository.UpdateAccount(account);
        return true;
    }
    public List<Transaction> GetTransactionsForAccount(Guid accountId, int count = 0)
    {
        return _transactionService.GetTransactionsForAccount(accountId, count);
    }
}