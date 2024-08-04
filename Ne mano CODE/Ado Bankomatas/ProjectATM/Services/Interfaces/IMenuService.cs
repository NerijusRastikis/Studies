namespace ProjectATM.Services.Interfaces;

public interface IMenuService
{
    void Start();
    void ShowLogin();
    void ShowMenu();
    void ShowBalance();
    void ShowTransactions();
    void Withdraw();
    void Logout();
    void ShowHeader();
}
