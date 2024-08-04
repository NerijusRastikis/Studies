using ProjectATM.Models;

namespace ProjectATM.Services.Interfaces;

public interface IAuthService
{
    Account? Login(Guid id, int pin);
    void Logout();
}
