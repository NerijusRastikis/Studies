using ProjectATM.Models;
using ProjectATM.Repositories.Interfaces;
using ProjectATM.Services.Interfaces;

namespace ProjectATM.Services;

public class ATMService(IATMRepository atmRepository, ITransactionService transactionService) : IATMService
{
    private readonly IATMRepository _atmRepository = atmRepository;
    private readonly ITransactionService _transactionService = transactionService;

    public AutomatedTellerMachine SelectRandomATM()
    {
        var atms = _atmRepository.GetATMs().Select(x => x.Id).ToList();
        Random r = new();
        var randomIndex = r.Next(0, atms.Count);
        var randomATMId = atms[randomIndex];
        return _atmRepository.GetATM(randomATMId);
    }
    public (Dictionary<int, int>? Bills, string? ErrorMessage) DispenseCash(int atmId, int amount, Guid accountId)
    {
        if (amount <= 0)
            return (null, "Klaida! Negalima issimti neigiamo kiekio");

        if (amount % 5 != 0)
            return (null, "Klaida! Bankomate yra nominalai tik 5, 10, 20, 50, 100, 200. Taigi suma turi dalintis is 5.");

        if (amount > 1000)
            return (null, "Klaida! Vienu metu negalima issimti daugiau negu 1000Eur.");

        var transactionsCount = _transactionService.GetTransactionsForAccount(accountId)
            .Where(x => x.DateOfTransaction.Date == DateTime.Today.Date).Count();

        if (transactionsCount >= 5)
            return (null, "Klaida! Per diena galima atlikti tik 5 pinigu pervedimus.");

        var atm = _atmRepository.GetATM(atmId);
        if (atm == null)
        {
            return (null, "Klaida! Bankomatas nerastas.");
        }

        var billsToDispense = new Dictionary<int, int>();
        var remainingAmount = amount;

        var sortedBills = atm.Bills.OrderByDescending(b => b.Key).ToList();

        foreach (var bill in sortedBills)
        {
            var billValue = bill.Key;
            var availableCount = bill.Value;

            if (remainingAmount >= billValue && availableCount > 0)
            {
                var neededCount = Math.Min(remainingAmount / billValue, availableCount);
                if (neededCount > 0)
                {
                    billsToDispense[billValue] = neededCount;
                    remainingAmount -= neededCount * billValue;
                }
            }

            if (remainingAmount == 0)
                break;
        }

        if (remainingAmount == 0)
        {
            foreach (var bill in billsToDispense)
            {
                atm.Bills[bill.Key] -= bill.Value;
            }
            _atmRepository.UpdateATM(atm);

            return (billsToDispense, null);
        }

        return (null, "Klaida! Bankomatas neturi visu nominalu kuriu jums reikia.");
    }
}
