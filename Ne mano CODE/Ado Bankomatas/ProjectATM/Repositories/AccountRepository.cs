using ProjectATM.Models;
using ProjectATM.Repositories.Interfaces;

namespace ProjectATM.Repositories;
public class AccountRepository : IAccountRepository
{
    private readonly string _fileName;
    private readonly List<Account> _accounts;

    public AccountRepository(string fileName)
    {
        _fileName = fileName;
        _accounts = LoadAccounts();
    }

    public List<Account> LoadAccounts()
    {
        var accounts = new List<Account>();
        if (!File.Exists(_fileName)) return accounts;

        try
        {
            var lines = File.ReadAllLines(_fileName);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length != 3) continue;
                if (Guid.TryParse(parts[0], out var id) &&
                    int.TryParse(parts[1], out var pin) &&
                    int.TryParse(parts[2], out var balance))
                {
                    accounts.Add(new Account
                    {
                        Id = id,
                        Pin = pin,
                        Balance = balance
                    });
                }
                else
                {
                    Console.WriteLine($"Klaida! Blogas formatas faile: {_fileName}");
                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine($"Klaida! Klaida skaitant faila: {_fileName} {e.Message}");
        }
        return accounts;
    }
    public Account? GetAccount(Guid id)
    {
        return _accounts.SingleOrDefault(acc => acc.Id == id);
    }

    public Account? GetAccount(Guid id, int pin)
    {
        return _accounts.SingleOrDefault(acc => acc.Id == id && acc.Pin == pin);
    }
    public void UpdateAccount(Account account)
    {
        var existingAccount = _accounts.SingleOrDefault(acc => acc.Id == account.Id);
        if (existingAccount != null)
        {
            existingAccount.Balance = account.Balance;
            Save();
        }
        else
        {
            Console.WriteLine($"Klaida! Nerastas vartotojas su Id: {account.Id}");
        }
    }

    public void Save()
    {
        var lines = _accounts.Select(acc => $"{acc.Id};{acc.Pin};{acc.Balance}");
        File.WriteAllLines(_fileName, lines);
    }
}