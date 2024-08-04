using ProjectATM.Models;

namespace ProjectATM.Repositories.Interfaces;
public interface IAccountRepository
{
    List<Account> LoadAccounts();
    Account? GetAccount(Guid id);
    Account? GetAccount(Guid id, int pin);
    void UpdateAccount(Account account);
    void Save();
}
