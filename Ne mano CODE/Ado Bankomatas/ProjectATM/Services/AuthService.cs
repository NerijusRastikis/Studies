using ProjectATM.Models;
using ProjectATM.Repositories.Interfaces;
using ProjectATM.Services.Interfaces;

namespace ProjectATM.Services;

public class AuthService(IAccountRepository accountRepository) : IAuthService
{
    private readonly IAccountRepository _accountRepository = accountRepository;

    public Account? Login(Guid id, int pin)
    {
        return _accountRepository.GetAccount(id, pin);
    }

    public void Logout()
    {
        Environment.Exit(0);
    }
}