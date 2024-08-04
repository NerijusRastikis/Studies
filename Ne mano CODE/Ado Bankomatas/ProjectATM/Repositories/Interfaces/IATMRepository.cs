using ProjectATM.Models;

namespace ProjectATM.Repositories.Interfaces;

public interface IATMRepository
{
    List<AutomatedTellerMachine> LoadATMs();
    AutomatedTellerMachine? GetATM(int id);
    IEnumerable<AutomatedTellerMachine> GetATMs();
    void UpdateATM(AutomatedTellerMachine atm);
    void Save(List<AutomatedTellerMachine> atms);
}
