using ProjectATM.Models;

namespace ProjectATM.Services.Interfaces;

public interface IATMService
{
    AutomatedTellerMachine SelectRandomATM();
    (Dictionary<int, int>? Bills, string? ErrorMessage) DispenseCash(int atmId, int amount, Guid accountId);
}
