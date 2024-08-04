using ProjectATM.Models;
using ProjectATM.Services.Interfaces;
using Serilog;

namespace ProjectATM.Services;

public class MenuService(IAccountService accountService, IATMService atmService, IAuthService authService) : IMenuService
{
    private readonly IAccountService _accountService = accountService;
    private readonly IATMService _atmService = atmService;
    private readonly IAuthService _authService = authService;
    private Account? _authenticatedAccount;
    private AutomatedTellerMachine? _selectedATM;

    public void Start()
    {
        while (true)
        {
            if (_authenticatedAccount == null)
            {
                ShowLogin();
            }
            else
            {
                ShowMenu();
            }
        }
    }
    public void ShowLogin()
    {
        Console.Clear();
        Console.Write("Idekite kortele arba iveskite korteles duomenis: ");
        if (!Guid.TryParse(Console.ReadLine(), out var accountId))
        {
            Console.WriteLine("Neteisingas korteles numeris");
            Console.ReadKey(true);
            return;
        }

        Console.Write("Iveskite PIN koda: ");
        if (!int.TryParse(Console.ReadLine(), out var pin))
        {
            Console.WriteLine("Neteisingas PIN");
            Console.ReadKey(true);
            return;
        }

        _authenticatedAccount = _authService.Login(accountId, pin);
        if (_authenticatedAccount != null)
        {
            Console.WriteLine("Prisijungta sekmingai");
            _selectedATM = _atmService.SelectRandomATM();
            Console.ReadKey(true);
        }
        else
        {
            Console.WriteLine("Klaidingi duomenys");
            Console.ReadKey(true);
        }
    }
    public void ShowMenu()
    {
        ShowHeader();

        Console.WriteLine("(1) -> Rodyti likuti");
        Console.WriteLine("(2) -> Operaciju istorija");
        Console.WriteLine("(3) -> Isiimti pinigu");
        Console.WriteLine("(4) -> Grazinti kortele");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                ShowBalance();
                break;
            case "2":
                ShowTransactions();
                break;
            case "3":
                Withdraw();
                break;
            case "4":
                Logout();
                break;
            default:
                Console.WriteLine("Neteisingas pasirinkimas");
                break;
        }
    }

    public void ShowBalance()
    {
        ShowHeader();

        var balance = _accountService.GetBalance(_authenticatedAccount.Id);
        Console.WriteLine($"Dabartinis likutis: {balance}");

        Console.ReadKey(true);

    }
    public void ShowTransactions()
    {
        ShowHeader();

        const int countTransactions = 5;
        var transactions = _accountService.GetTransactionsForAccount(_authenticatedAccount.Id,  countTransactions);
        Console.WriteLine($"Paskutines {countTransactions} operacijos");
        foreach (var transaction in transactions)
        {
            Console.WriteLine(transaction);
        }

        Console.ReadKey(true);
    }
    public void Withdraw()
    {
        ShowHeader();

        Console.Write("Iveskite suma kuria norite issigryninti: ");
        if (!int.TryParse(Console.ReadLine(), out var amount))
        {
            Console.WriteLine("Klaida! Netinkama suma.");
            Console.ReadKey(true);
            return;
        }

        var accountBalance = _accountService.GetBalance(_authenticatedAccount.Id);
        if (amount > accountBalance)
        {
            Console.WriteLine("Klaida! Nepakanka lesu saskaitoje");
            Console.ReadKey(true);
            return;
        }

        var (billsToDispense, errorMessage) = _atmService.DispenseCash(_selectedATM.Id, amount, _authenticatedAccount.Id);
        if (errorMessage != null)
        {
            Console.WriteLine(errorMessage);
            Console.ReadKey(true);
            return;
        }

        if(_accountService.Withdraw(_authenticatedAccount.Id, amount))
        {
            Console.WriteLine($"Sekmingai issimta: {amount}");
            Console.WriteLine("Banknotais:");
            foreach (var bill in billsToDispense)
            {
                Console.WriteLine($"{bill.Value}x{bill.Key}Eur = {bill.Key * bill.Value}");
            }
        }      
        Console.ReadKey(true);
    }
    public void Logout()
    {
        _authService.Logout();
    }
    public void ShowHeader()
    {
        if (_authenticatedAccount == null || _selectedATM == null) return;
        Console.Clear();
        Console.WriteLine("##             ATM             ##");
        
        Console.WriteLine($"             {_selectedATM.Location}");
        Console.WriteLine("#################################");
        
        Console.WriteLine($"Kortele: {_authenticatedAccount.Id}");
    }
}
