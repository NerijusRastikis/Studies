using ProjectATM.Repositories;
using ProjectATM.Repositories.Interfaces;
using ProjectATM.Services;
using ProjectATM.Services.Interfaces;
using Serilog;
using Serilog.Formatting.Compact;

namespace ProjectATM
{
    internal class Program
    {
        static void Main()
        {
            ITransactionRepository transactionRepository = new TransactionRepository("transactions.txt");
            IAccountRepository accountRepository = new AccountRepository("accounts.txt");
            IATMRepository atmRepository = new ATMRepository("atms.txt");

            ITransactionService transactionService = new TransactionService(transactionRepository);
            IAccountService accountService = new AccountService(accountRepository, transactionService);
            IATMService atmService = new ATMService(atmRepository, transactionService);
            IAuthService authService = new AuthService(accountRepository);

            MenuService menuService = new(accountService, atmService, authService);
            menuService.Start();
        }
    }
}
