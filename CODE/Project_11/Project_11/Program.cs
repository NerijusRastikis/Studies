using System;
using System.Collections.Generic;
using System.Threading;

public class BrainBattle
{
    static Dictionary<string, (string LastName, int Score)> accountList = new Dictionary<string, (string, int)>()
    {
        { "Nerijus", ("Rastikis", 0) },
        { "Admin", ("Admin", 0) }
        // Add predefined users here if needed
    };

    public static void Main(string[] args)
    {
        string gameLogo = RainbowIntro();
        string difficulty = "0";
        string firstName, lastName;
        bool isNewUser;

        LogInDetails(out firstName, out lastName, out isNewUser);
        string selection = PrintMainMenu(firstName, gameLogo, isNewUser);

        while (selection != "999")
        {
            if (selection == "0")
            {
                Console.Clear();
                LogInDetails(out firstName, out lastName, out isNewUser);
            }
            selection = MainMenuNavigator(selection, firstName, gameLogo, ref difficulty);
        }
    }

    public static string RainbowIntro()
    {
        return "Welcome to BrainBattle!";
    }

    public static void LogInDetails(out string firstName, out string lastName, out bool isNewUser)
    {
        Console.WriteLine("Please sign in / sign up to continue.");
        Console.Write("First name: ");
        firstName = Console.ReadLine();
        Console.Write("Last name: ");
        lastName = Console.ReadLine();

        if (accountList.ContainsKey(firstName))
        {
            if (accountList[firstName].LastName == lastName)
            {
                isNewUser = false;
            }
            else
            {
                Console.WriteLine("Error in LogInDetails: Last name does not match.");
                isNewUser = false;
                lastName = null;
            }
        }
        else
        {
            accountList[firstName] = (lastName, 0);
            isNewUser = true;
        }
    }

    public static string PrintMainMenu(string firstName, string introText, bool isNewUser)
    {
        string selection;
        string mainMenu = @"
        1. Start game
        2. Show scoreboard
        3. How to play
        0. Logout
        Q. Quit";

        Console.WriteLine(introText);

        if (isNewUser)
        {
            Console.WriteLine($"WELCOME {firstName}!");
            Console.WriteLine("(Reading instructions is recommended for new players)");
        }
        else
        {
            Console.WriteLine($"WELCOME BACK {firstName}!");
        }
        Console.WriteLine(mainMenu);
        selection = Console.ReadLine();
        return selection;
    }

    public static string MainMenuNavigator(string selection, string firstName, string introText, ref string difficulty)
    {
        selection = selection.ToLowerInvariant();
        int tempScore = 0;
        bool hasPlayed = false;

        switch (selection)
        {
            case "1":
                difficulty = GameModeSelector(firstName, introText);
                tempScore = PlayGame(introText, firstName, difficulty, out selection, out hasPlayed);
                if (hasPlayed)
                {
                    var user = accountList[firstName];
                    accountList[firstName] = (user.LastName, user.Score + tempScore);
                }
                Console.Clear();
                return "9";

            case "2":
                PrintScoreboard(introText);
                Console.Clear();
                difficulty = "0";
                return "9";

            case "3":
                MenuHowToPlay(introText);
                Console.Clear();
                difficulty = "0";
                return "9";

            case "0":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Logged out successfully...");
                Console.ResetColor();
                Thread.Sleep(2000);
                difficulty = "0";
                return "9";

            case "q":
                ExitProgram();
                difficulty = "0";
                return selection;

            case "9":
                difficulty = "0";
                return PrintMainMenu(firstName, introText, false);

            default:
                Console.WriteLine("Error in MainMenuNavigator");
                difficulty = "0";
                return selection;
        }
    }

    public static string GameModeSelector(string firstName, string introText)
    {
        // Implement game mode selection logic
        // For simplicity, we are returning a fixed difficulty
        return "easy";
    }

    public static int PlayGame(string introText, string firstName, string difficulty, out string selection, out bool hasPlayed)
    {
        // Implement game logic here
        int score = 0;
        hasPlayed = true;

        // Sample logic to add points
        if (difficulty == "easy")
        {
            score += 10; // Assume user scored 10 points
        }

        // Set selection to go back to the main menu after playing
        selection = "9";
        return score;
    }

    public static void PrintScoreboard(string introText)
    {
        Console.Clear();
        Console.WriteLine(introText);
        Console.WriteLine("Scoreboard:");
        foreach (var user in accountList)
        {
            Console.WriteLine($"{user.Key} {user.Value.LastName}: {user.Value.Score}");
        }
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    public static void MenuHowToPlay(string introText)
    {
        // Implement how-to-play menu logic
        Console.WriteLine("How to play the game...");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    public static void ExitProgram()
    {
        Console.WriteLine("Exiting the program...");
        Thread.Sleep(2000);
        Environment.Exit(0);
    }
}
