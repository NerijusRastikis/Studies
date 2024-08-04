using System.Globalization;

public class FileManager : IFileManager
{
    private readonly string _userFilePath;
    private readonly string _atmFundsFilePath;

    public FileManager(string userFilePath, string atmFundsFilePath)
    {
        _userFilePath = userFilePath;
        _atmFundsFilePath = atmFundsFilePath;
    }

    public List<User> LoadUsers()
    {
        var users = new List<User>();
        try
        {
            var lines = File.ReadAllLines(_userFilePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    string cardNumber = parts[0];
                    string pin = parts[1];
                    decimal balance = decimal.Parse(parts[2]);
                    var transactions = parts[3].Split(';')
                                               .Select(t => t.Split('|'))
                                               .Where(t => t.Length == 3)
                                               .Select(t => new Transaction(DateTime.Parse(t[0]), decimal.Parse(t[1]), t[2]))
                                               .ToList();
                    var user = new User(cardNumber, pin, balance);
                    user.SetTransactions(transactions);
                    users.Add(user);
                }
            }
        }
        catch (PathTooLongException ex)
        {
            Console.WriteLine("KLAIDA! Kelias per ilgas.");
            Console.WriteLine(ex);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("KLAIDA! Failas nerastas.");
            Console.WriteLine(ex);
        }
        catch (Exception ex)
        {
            Console.WriteLine("KLAIDA! Nežinoma klaida.");
            Console.WriteLine(ex);
        }

        return users;
    }

    public void SaveUsers(List<User> users)
    {
        try
        {
            var lines = new List<string>();
            foreach (var user in users)
            {
                string transactions = string.Join(";", user.Transactions.Select(t => $"{t.Date}|{t.Amount}|{t.Description}"));
                lines.Add($"{user.CardNumber},{user.Pin},{user.Balance},{transactions}");
            }
            File.WriteAllLines(_userFilePath, lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine("KLAIDA! Nepavyko išsaugoti naudotojų duomenų.");
            Console.WriteLine(ex);
        }
    }

    public void UpdateUser(User user)
    {
        var users = LoadUsers();
        var existingUser = users.FirstOrDefault(u => u.CardNumber == user.CardNumber);
        if (existingUser != null)
        {
            existingUser.Balance = user.Balance;
            existingUser.SetTransactions(user.Transactions);
        }
        SaveUsers(users);
    }

    public Dictionary<int, int> LoadATMFunds()
    {
        var atmFunds = new Dictionary<int, int>();
        try
        {
            var lines = File.ReadAllLines(_atmFundsFilePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    int denomination = int.Parse(parts[0]);
                    int count = int.Parse(parts[1]);
                    atmFunds[denomination] = count;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("KLAIDA! Nepavyko įkelti bankomato lėšų.");
            Console.WriteLine(ex);
        }

        return atmFunds;
    }

    public void SaveATMFunds(Dictionary<int, int> atmFunds)
    {
        try
        {
            var lines = new List<string>();
            foreach (var fund in atmFunds)
            {
                lines.Add($"{fund.Key},{fund.Value}");
            }
            File.WriteAllLines(_atmFundsFilePath, lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine("KLAIDA! Nepavyko išsaugoti bankomato lėšų.");
            Console.WriteLine(ex);
        }
    }
}
