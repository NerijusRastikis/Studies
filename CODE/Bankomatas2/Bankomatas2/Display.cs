public class Display
{
    private readonly IATM _atm;

    public Display(IATM atm)
    {
        _atm = atm;
    }

    public void ShowWelcomeMessage()
    {
        Console.WriteLine("Sveiki atvykę į bankomatą!");
    }

    public (string, string) GetLoginCredentials()
    {
        Console.Write("Įveskite kortelės numerį: ");
        string cardNumber = Console.ReadLine();
        Console.Write("Įveskite PIN kodą: ");
        string pin = Console.ReadLine();
        return (cardNumber, pin);
    }

    public void ShowLoginFailedMessage()
    {
        Console.Clear();
        Console.WriteLine("Neteisingas kortelės numeris arba PIN kodas. Bandykite dar kartą.");
    }

    public void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Patikrinti likutį");
        Console.WriteLine("2. Išsiimti pinigų");
        Console.WriteLine("3. Peržiūrėti paskutines 5 operacijas");
        Console.WriteLine("4. Išeiti");
    }

    public int GetMenuOption()
    {
        Console.Write("Pasirinkite parinkti: ");
        if (int.TryParse(Console.ReadLine(), out int option))
        {
            return option;
        }
        return -1;
    }

    public void ShowInvalidOptionMessage()
    {
        Console.WriteLine("Neteisinga parinktis. Bandykite dar kartą.");
    }

    public decimal GetWithdrawAmount()
    {
        Console.Write("Įveskite sumą išgryninimui: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            return amount;
        }
        Console.WriteLine("Neteisinga suma. Bandykite dar kartą.");
        return -1;
    }

    public void ShowExitMessage()
    {
        Console.WriteLine("Programa baigė darbą.");
    }
}
