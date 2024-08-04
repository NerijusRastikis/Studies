public class ATM : IATM
{
    private readonly IFileManager _fileManager;
    private List<User> _users;
    private User _currentUser;
    private Dictionary<int, int> _atmFunds;
    private int _failedAttempts;

    public ATM(IFileManager fileManager)
    {
        _fileManager = fileManager;
        _users = _fileManager.LoadUsers();
        _atmFunds = _fileManager.LoadATMFunds();
        _failedAttempts = 0;
    }

    public bool Login(string cardNumber, string pin)
    {
        _currentUser = _users.FirstOrDefault(u => u.CardNumber == cardNumber && u.Pin == pin);
        if (_currentUser == null)
        {
            _failedAttempts++;
            if (_failedAttempts >= 3)
            {
                Console.WriteLine("Naudoti 3 bandymai. Programa dabar nutraukiama.");
                Environment.Exit(0);
            }
            return false;
        }
        _failedAttempts = 0;
        return true;
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Jūsų likutis yra: {_currentUser.Balance:C}");
    }

    public bool WithdrawMoney(decimal amount)
    {
        if (amount > _currentUser.Balance)
        {
            Console.WriteLine("Nepakanka lėšų.");
            return false;
        }

        Dictionary<int, int> withdraw = new Dictionary<int, int>();
        int[] denominations = new[] { 100, 50, 20, 10, 5 };

        foreach (var denom in denominations)
        {
            int numNotes = (int)(amount / denom);
            if (numNotes > _atmFunds[denom])
                numNotes = _atmFunds[denom];

            amount -= numNotes * denom;
            withdraw[denom] = numNotes;
        }

        if (amount > 0)
        {
            Console.WriteLine("Bankomatas negali išduoti prašomos sumos su turimais nominalais.");
            return false;
        }

        foreach (var item in withdraw)
        {
            _atmFunds[item.Key] -= item.Value;
        }

        _currentUser.Balance -= amount;
        _currentUser.AddTransaction(new Transaction(DateTime.Now, -amount, "Pinigų išėmimas"));

        _fileManager.UpdateUser(_currentUser);
        _fileManager.SaveATMFunds(_atmFunds);

        Console.WriteLine("Išėmimas sėkmingas.");
        return true;
    }

    public void CheckLastTransactions()
    {
        foreach (var transaction in _currentUser.Transactions)
        {
            Console.WriteLine(transaction.ToString());
        }
    }
}
