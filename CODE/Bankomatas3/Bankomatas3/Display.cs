using Bankomatas3;

public class Display
{
    public Display(string name, decimal? funds)
    {
        Name = name;
        Funds = funds;
    }

    public string Name { get; set; }
    public decimal? Funds { get; set; }

    public string LoginCardNumber()
    {
        string cardNumber;
        do
        {
            Console.Clear();
            Console.WriteLine(Program.logo);
            Console.WriteLine("P - R - I - S - I - J - U - N - G - I - M - A - S");
            Console.WriteLine();
            Console.Write("Įveskite ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("kortelės ");
            Console.ResetColor();
            Console.Write("numerį: ");
            cardNumber = Console.ReadLine();
        } while (String.IsNullOrEmpty(cardNumber));
        return cardNumber;
    }

    public int LoginPIN()
    {
        int pin;
        do
        {
            Console.Clear();
            Console.WriteLine(Program.logo);
            Console.WriteLine("P - R - I - S - I - J - U - N - G - I - M - A - S");
            Console.WriteLine();
            Console.Write("Įveskite prisijungimo ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("PIN ");
            Console.ResetColor();
            Console.Write("kodą: ");
        } while (!int.TryParse(Console.ReadLine(), out pin));
        return pin;
    }

    public void LoginSuccessful()
    {
        Console.Clear();
        Console.WriteLine(Program.logo);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("PRISIJUNGIMAS SĖKMINGAS");
        Console.ResetColor();
    }

    public void LoginAttemptFailed(int counter)
    {
        int attempt = 3;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Neteisingas kortelės arba PIN numeris. Jums liko {attempt - counter} bandymų.");
        Console.ResetColor();
        Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti");
        Console.ReadKey();
    }

    public void LoginAttemptLimitReached()
    {
        Console.Clear();
        Console.WriteLine(Program.logo);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Neteisingas kortelės arba PIN numeris. Pasiektas neteisingų prisijungimų limitas.");
        Console.WriteLine("UŽBLOKUOTA!");
        Console.WriteLine("Spauskite bet kurį mygtuką norėdami baigti");
        Console.ResetColor();
        Console.ReadKey();
        Environment.Exit(0);
    }

    public void Welcome()
    {
        Console.Clear();
        Console.WriteLine(Program.logo);
        Console.Write($"Esate prisijungę kaip: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"{Name} ");
        Console.ResetColor();
        Console.Write(", Jūsų turimi pinigai: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"{Funds}");
        Console.ResetColor();
        Console.WriteLine("€");
        Console.WriteLine();
    }

    public void MainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("M - E - N - I - U");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("1. ");
        Console.ResetColor();
        Console.WriteLine("Peržiūrėti balansą");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("2. ");
        Console.ResetColor();
        Console.WriteLine("Išsiimti pinigų");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("3. ");
        Console.ResetColor();
        Console.WriteLine("Peržiūrėti paskutines 5 transakcijas");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("0. ");
        Console.ResetColor();
        Console.WriteLine("Išeiti");
    }

    public void ErrorInMainMenu()
    {
        Console.Clear();
        Console.WriteLine(Program.logo);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Tokio pasirinkimo nėra! Prašome pakartoti įvestį.");
        Console.ResetColor();
    }

    public void ViewBalance()
    {
        Console.WriteLine();
        Console.WriteLine("Jūsų turimi pinigai:");
        Console.WriteLine($"        {Funds}");
        Console.WriteLine();
        Console.WriteLine("Spauskite bet kurį mygtuką norėdami grįžti.");
        Console.ReadKey();
    }

    public decimal WithdrawFunds()
    {
        decimal withdrawSum;
        Console.WriteLine();
        Console.Write("Įveskite norimą išsimti pinigų sumą: ");
        while (!decimal.TryParse(Console.ReadLine(), out withdrawSum) || withdrawSum <= 0)
        {
            Console.Clear();
            Console.WriteLine(Program.logo);
            Welcome();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Netinkama suma! Pakartokite įvestį: ");
            Console.ResetColor();
        }
        return withdrawSum;
    }

    public void WithdrawSuccess()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Operacija sėkmingai įvykdyta.");
        Console.ResetColor();
        Console.WriteLine("Paimkite pinigus ir spauskite bet kurį mygtuką norėdami tęsti.");
        Console.ReadKey();
    }

    public void WithdrawError_NotEnoughFunds()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Operacija nepavyko. ");
        Console.WriteLine("Nepakankamas likutis.");
        Console.ResetColor();
        Console.WriteLine("Spauskite bet kurį mygtuką norėdami tęsti");
        Console.ReadKey();
    }

    public void ATM_OutOfDenomination()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Bankomato klaida! Baigėsi nominalai, kuriuos bankomatas bandė išduoti.");
        Console.ResetColor();
        Console.WriteLine("Spauskite bet kurį mygtuką, kad leistumėte bankomatui pabandyti išduoti pinigus skirtingais nominalais.");
        Console.ReadKey();
    }

    public void ATM_ImpossibleToWithdraw()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Bankomato klaida! Baigėsi nominalai. Deja, nėra įmanoma išduoti pageidautinos sumos.");
        Console.ResetColor();
        Console.WriteLine("Spauskite bet kurį mygtuką, kad grįžtumėte atgal į meniu. Bandykite pasirinkti kitą sumą.");
    }

    public void ATMExit()
    {
        Console.WriteLine();
        Console.WriteLine();
        Environment.Exit(0);
    }
}