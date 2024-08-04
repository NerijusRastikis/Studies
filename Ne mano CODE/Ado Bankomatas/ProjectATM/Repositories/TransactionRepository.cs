using ProjectATM.Models;
using ProjectATM.Repositories.Interfaces;

namespace ProjectATM.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly string _fileName;
    private readonly List<Transaction> _transactions;

    public TransactionRepository(string fileName)
    {
        _fileName = fileName;
        _transactions = LoadTransactions();
    }

    public List<Transaction> LoadTransactions()
    {
        var transactions = new List<Transaction>();
        if (!File.Exists(_fileName)) return transactions;
        try
        {
            var lines = File.ReadAllLines(_fileName);
            foreach (var line in lines)
            {
                var parts = line.Split(';');

                if (parts.Length != 4) continue;

                if (Guid.TryParse(parts[0], out var accountId) &&
                    int.TryParse(parts[2], out var amount) &&
                    DateTime.TryParse(parts[3], out var dateOfTransaction))
                {
                    transactions.Add(new Transaction
                    {
                        Id = accountId,
                        TypeOfTransaction = parts[1],
                        Amount = amount,
                        DateOfTransaction = dateOfTransaction
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

        return transactions;
    }

    public IEnumerable<Transaction> GetTransactionsByAccountId(Guid accountId)
    {
        return _transactions.Where(t => t.Id == accountId).ToList();
    }

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
        Save();
    }

    public void Save()
    {
        var lines = _transactions.Select(t => $"{t.Id};{t.TypeOfTransaction};{t.Amount};{t.DateOfTransaction}");
        File.WriteAllLines(_fileName, lines);
    }
}