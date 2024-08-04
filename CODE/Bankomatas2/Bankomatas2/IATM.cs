public interface IATM
{
    bool Login(string cardNumber, string pin);
    void CheckBalance();
    bool WithdrawMoney(decimal amount);
    void CheckLastTransactions();
}
