namespace Project_1
{
    public class BrainBattle
    {
        static void Main(string[] args)
        {
            // Simplifying future parameters take-ins
            string gameLogo = RainbowIntro();
            string difficulty = "0";
            var accountList = new Dictionary<string, string>(AccountList());
            var userDetails = LogInDetails(accountList, gameLogo, out string userName);
            string selection = PrintMainMenu(userDetails, accountList, gameLogo);
            var questions = Quizes(difficulty);

            #region Questions - Answers assignment to variables (the boring part)
            var veryEasyQuestions = Quizes("1");
            var easyQuestions = Quizes("2");
            var mediumQuestions = Quizes("3");
            var hardQuestions = Quizes("4");
            var veryHardQuestions = Quizes("5");
            var nightmareQuestions = Quizes("6");
            var veryEasyAnswers = CorrectAnswers("1");
            var easyAnswers = CorrectAnswers("2");
            var mediumAnswers = CorrectAnswers("3");
            var hardAnswers = CorrectAnswers("4");
            var veryHardAnswers = CorrectAnswers("5");
            var nightmareAnswers = CorrectAnswers("6");
            #endregion

            int tempScore = 0;
            bool hasPlayed = false;
            var usersWithScores = Scoreboard(accountList, userDetails, hasPlayed, tempScore);
            // Protecting "selection" not to take unexpected values
            while (selection != "999")
            {
                // Logout functionality
                if (selection == "0")
                {
                    Console.Clear();
                    userDetails = LogInDetails(accountList, gameLogo, out userName);
                }
                // Calling main function, which directs flow of the program
                selection = MainMenuNavigator(
                    selection,
                    userDetails,
                    gameLogo,
                    accountList,
                #region - passing parameters Questions and Answers (the boring part)
                    veryEasyQuestions,
                    easyQuestions,
                    mediumQuestions,
                    hardQuestions,
                    veryHardQuestions,
                    nightmareQuestions,
                    veryEasyAnswers,
                    easyAnswers,
                    mediumAnswers,
                    hardAnswers,
                    veryHardAnswers,
                    nightmareAnswers,
                #endregion
                    usersWithScores,
                    out difficulty,
                    ref tempScore);
            }
        }


        #region TheTitle - RainbowIntro returns string introText
        public static string RainbowIntro()
        {
            string[] colors = { "Red", "Yellow", "Green", "Cyan", "Blue", "Magenta" };
            string introText = @"
                     ____            _       ____        _   _   _      
                    | __ ) _ __ __ _(_)_ __ | __ )  __ _| |_| |_| | ___ 
                    |  _ \| '__/ _` | | '_ \|  _ \ / _` | __| __| |/ _ \
                    | |_) | | | (_| | | | | | |_) | (_| | |_| |_| |  __/
                    |____/|_|  \__,_|_|_| |_|____/ \__,_|\__|\__|_|\___|
";

            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                foreach (var colorName in colors)
                {
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName, true);
                    Console.Clear();
                    Console.WriteLine(introText);
                    Thread.Sleep(20);
                }
            }
            Console.ResetColor();
            Console.Clear();
            return introText;
        }
        #endregion
        #region AccountList - returns dict accountList
        public static Dictionary<string, string> AccountList()
        {
            var accountList = new Dictionary<string, string>()
            {
                {"Nerijus", "Rastikis" },
                {"Admin", "Admin" },
                {"Jonas", "Jonaitis" },
                {"Petras", "Petraitis" },
                {"Tomas", "Vaitkus" },
                {"Liepa", "Lukaite" },
                {"Viktoras", "Simaitis" },
                {"Benediktas", "Vanagas" },
                {"Vytautas", "Petraitis"},
                {"Antanas", "Kazlauskas"},
                {"Lina", "Jankauskaite"},
                {"Monika", "Zukauskaite"},
                {"Marius", "Stankevicius"},
                {"Asta", "Vaitkeviciene"},
                {"Rasa", "Daugeliene"},
                {"Egle", "Sauliene"},
                {"Mindaugas", "Butkus"},
                {"Saulius", "Grigas"},
                {"Rimantas", "Kairys"},
                {"Inga", "Bieliauskaite"},
                {"Dovile", "Galdikaite"},
                {"Zilvinas", "Karalius"},
                {"Gabija", "Kudirkaite"},
                {"Edvinas", "Lukosevicius"},
                {"Simona", "Simkute"},
                {"Dainius", "Navickas"},
                {"Giedrius", "Petrauskas"},
                {"Ruta", "Ziemyte"},
                {"Viktorija", "Kvietkauskaite"},
                {"Justinas", "Lazauskas"},
                {"Raminta", "Jakutyte"},
                {"Kestutis", "Mikalauskas"},
                {"Laima", "Sakalauskaite"},
                {"Edita", "Sabaliauskaite"},
                {"Arunas", "Brazauskas"},
                {"Eimantas", "Banevicius"},
                {"Agne", "Vitkauskaite"},
                {"Paulius", "Barkauskas"},
                {"Tautvydas", "Tamulis"},
                {"Zygimantas", "Radzevičius"},
                {"Neringa", "Pociūtė"},
                {"Karolina", "Žebrauskaitė"},
                {"Ignas", "Vaitekūnas"},
                {"Jolanta", "Urbonavičienė"},
                {"Raimondas", "Aleknavičius"},
                {"Deimante", "Navickaitė"},
                {"Dovydas", "Vilkas"},
                {"Jūrate", "Skaisgirytė"},
                {"Mantas", "Klimavičius"},
                {"Aiste", "Grigaliūnaitė"},
                {"Ricardas", "Jasinskas"},
                {"Vilma", "Valatkaitė"},
                {"Kristina", "Žalnieriūtė"},
                {"Valdas", "Liaudanskas"},
                {"Ieva", "Malinauskaitė"},
                {"Tautvilė", "Rupeikaitė"},
                {"Rokas", "Kurtinaitis"},
                {"Evelina", "Vaičiulytė"},
                {"Rytis", "Gudaitis"},
                {"Justė", "Tamašauskaitė"},
                {"Gintaras", "Gailius"},
                {"Vaidotas", "Kazimieras"},
                {"Lukas", "Sadauskas"}
            };
            return accountList;
        }
        #endregion
        #region LogInDetails - returns dict (signedUser, isNewUser)

        public static (Dictionary<string, string>, bool) LogInDetails(Dictionary<string, string> accountList, string introText, out string userName)
        {
            var signedUser = new Dictionary<string, string>();
            bool isNewUser = false;

            Console.WriteLine(introText);
            Console.WriteLine("                             Please sign in / sign up to continue.");
            Console.WriteLine("");
            Console.Write("                        \tFirst name: ");
            string firstName = Console.ReadLine();
            while (string.IsNullOrEmpty(firstName))
            {
                Console.Clear();
                Console.WriteLine(introText);
                Console.WriteLine("                             Please sign in / sign up to continue.");
                Console.WriteLine("");
                Console.Write("                        \tFirst name: ");
                firstName = Console.ReadLine();
            }

            Console.Write("                            \tLast name: ");
            string lastName = Console.ReadLine();
            while (string.IsNullOrEmpty(lastName))
            {
                Console.Clear();
                Console.WriteLine(introText);
                Console.WriteLine("                             Please sign in / sign up to continue.");
                Console.WriteLine("");
                Console.WriteLine($"                        \tFirst name: {firstName}");
                Console.Write("                        \tLast name: ");
                lastName = Console.ReadLine();
            }
            userName = $"{firstName} {lastName}";
            Console.Clear();

            // CHECKING IF USER ALREADY EXISTS
            if (accountList.ContainsKey(firstName))
            {
                if (accountList[firstName] == lastName)
                {
                    signedUser.Add(firstName, lastName);
                }
                else
                {
                    Console.WriteLine("Error in LogInDetails");
                    Console.ReadKey();
                }
            }
            else
            {
                // ADDING NEW USER
                accountList.Add(firstName, lastName);
                signedUser.Add(firstName, lastName);
                isNewUser = true;
            }

            return (signedUser, isNewUser);
        }
        #endregion
        #region PrintMainMenu - returns string selection
        public static string PrintMainMenu((Dictionary<string, string>, bool) userDetails, Dictionary<string, string> listOfUsers, string introText)
        {
            string selection = "99";
            var (signedUser, isNewUser) = userDetails;
            string? firstName = signedUser.Keys.FirstOrDefault();

            string mainMenu = @"                                1. Start game

                                2. Show scoreboard
                                3. How to play

                                0. Logout
                                Q. Quit";

            Console.WriteLine(introText);

            if (isNewUser)
            {
                Console.WriteLine($"WELCOME {firstName}!");
                Console.WriteLine("(Reading instructions is recommended for new players)");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine($"WELCOME BACK {firstName}!");
                Console.WriteLine("");
            }
            Console.WriteLine(mainMenu);
            selection = Console.ReadLine();
            return selection;
        }
        #endregion

        #region MainMenuNavigator - returns string selection
        public static string MainMenuNavigator(string selection, (Dictionary<string, string>, bool) userDetails,
                                       string introText, Dictionary<string, string> listOfUsers,
        #region Questions - Answers (the boring part)
                                       Dictionary<string, List<string>> veryEasyQuestions,
                                       Dictionary<string, List<string>> easyQuestions,
                                       Dictionary<string, List<string>> mediumQuestions,
                                       Dictionary<string, List<string>> hardQuestions,
                                       Dictionary<string, List<string>> veryHardQuestions,
                                       Dictionary<string, List<string>> nightmareQuestions,
                                       Dictionary<string, string> veryEasyAnswers,
                                       Dictionary<string, string> easyAnswers,
                                       Dictionary<string, string> mediumAnswers,
                                       Dictionary<string, string> hardAnswers,
                                       Dictionary<string, string> veryHardAnswers,
                                       Dictionary<string, string> nightmareAnswers,
        #endregion
                                       Dictionary<string, int> usersWithScores,
                                       out string difficulty, ref int tempScore)
        {
            var (signedUser, isNewUser) = userDetails;
            string userName = signedUser.Keys.FirstOrDefault();
            bool hasPlayed = false;
            difficulty = "0";

            switch (selection)
            {
                case "1":
                    difficulty = GameModeSelector(userName, introText);
                    tempScore = PlayGame(introText, userName,
                    #region Questions - Answers (the boring part)
                                         veryEasyQuestions,
                                         easyQuestions,
                                         mediumQuestions,
                                         hardQuestions,
                                         veryHardQuestions,
                                         nightmareQuestions,

                                         veryEasyAnswers,
                                         easyAnswers,
                                         mediumAnswers,
                                         hardAnswers,
                                         veryHardAnswers,
                                         nightmareAnswers,
                    #endregion
                                         difficulty, out selection, out hasPlayed);
                    hasPlayed = true;
                    Console.Clear();
                    selection = "9";
                    return selection;
                case "2":
                    PrintScoreboard(userName, introText, usersWithScores, tempScore);
                    Console.Clear();
                    difficulty = "0";
                    selection = "9";
                    ScoreInjection(usersWithScores, listOfUsers, userDetails, hasPlayed, tempScore);
                    return selection;
                case "3":
                    MenuHowToPlay(userName, introText);
                    Console.Clear();
                    difficulty = "0";
                    selection = "9";
                    return selection;
                case "0":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Logged out successfully...");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    difficulty = "0";
                    selection = "9";
                    return selection;
                case "q":
                    ExitProgram();
                    difficulty = "0";
                    return selection;
                case "9":
                    selection = PrintMainMenu(userDetails, listOfUsers, introText);
                    difficulty = "0";
                    Console.Clear();
                    return selection;
                default:
                    Console.WriteLine("Error in MainMenuNavigator");
                    difficulty = "0";
                    selection = "9";
                    return selection;
            }
        }
        #endregion

        #region MenuHowToPlay - returns nothing
        public static void MenuHowToPlay(string userName, string introText)
        {
            string selection = "99";
            Console.Clear();
            Console.WriteLine(introText);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Logged in player: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{userName}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                         HOW TO PLAY");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("         The game is a quiz where you must answer questions from four given options.");
            Console.WriteLine("         Before starting, you will be asked to pick one of the game modes.");
            Thread.Sleep(1800);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                     There are currently 4 game modes:");
            Console.ResetColor();
            Thread.Sleep(1800);
            Console.WriteLine("         1. Easy - You will be presented with 10 questions ranging from \"very easy\" to \"easy\" difficulty.");
            Thread.Sleep(900);
            Console.WriteLine("         2. Progressive - You will be presented with 10 questions starting from \"very easy\" and ending with \"nightmare\" difficulty.");
            Thread.Sleep(900);
            Console.WriteLine("         3. Quick Play - You will be presented with 5 random questions from all difficulty levels.");
            Thread.Sleep(900);
            Console.WriteLine("         4. I-Know-Everything - You will be presented with 10 \"nightmare\" difficulty questions.");
            Thread.Sleep(2700);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                     Earning Points:");
            Console.ResetColor();
            Thread.Sleep(1800);
            Console.WriteLine("         There are 3 different point values:");
            Thread.Sleep(1800);
            Console.WriteLine();
            Console.WriteLine("         1 point - Awarded for answering \"very easy\" or \"easy\" questions correctly.");
            Thread.Sleep(900);
            Console.WriteLine("         2 points - Awarded for answering \"medium\" or \"hard\" questions correctly.");
            Thread.Sleep(900);
            Console.WriteLine("         3 points - Awarded for answering \"very hard\" or \"nightmare\" questions correctly.");
            Thread.Sleep(2700);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                     Good Luck!");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Type Q and press Enter to go back to the Main Menu");
            selection = Console.ReadLine();
            selection.ToLowerInvariant();
            // REPEATING INSTRUCTIONS WITHOUT DELAYS WHEN PLAYER ENTERS WRONG SELECTION
            while (selection != "q")
            {
                Console.Clear();
                Console.WriteLine(introText);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Logged in player: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"{userName}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                         HOW TO PLAY");
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine("         The game is a quiz where you must answer questions from four given options.");
                Console.WriteLine("         Before starting, you will be asked to pick one of the game modes.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                     There are currently 4 game modes:");
                Console.ResetColor();
                Console.WriteLine("         1. Easy - You will be presented with 10 questions ranging from \"very easy\" to \"easy\" difficulty.");
                Console.WriteLine("         2. Progressive - You will be presented with 10 questions starting from \"very easy\" and ending with \"nightmare\" difficulty.");
                Console.WriteLine("         3. Quick Play - You will be presented with 5 random questions from all difficulty levels.");
                Console.WriteLine("         4. I-Know-Everything - You will be presented with 10 \"nightmare\" difficulty questions.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                     Earning Points:");
                Console.ResetColor();
                Console.WriteLine("         There are 3 different point values:");
                Console.WriteLine();
                Console.WriteLine("         1 point - Awarded for answering \"very easy\" or \"easy\" questions correctly.");
                Console.WriteLine("         2 points - Awarded for answering \"medium\" or \"hard\" questions correctly.");
                Console.WriteLine("         3 points - Awarded for answering \"very hard\" or \"nightmare\" questions correctly.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                                     Good Luck!");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Type Q and press Enter to go back to the Main Menu");
                selection = Console.ReadLine();
            }
        }
        #endregion
        #region ExitProgram method - returns nothing
        public static void ExitProgram()
        {
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }
        #endregion

        #region Quizes - returns dict veryEasy|easy|medium|hard|veryHard|nightmare (string, List<string>)
        public static Dictionary<string, List<string>> Quizes(string difficultyLevel)
        {
            // Very Easy level questions
            Dictionary<string, List<string>> veryEasy = new Dictionary<string, List<string>>
            {
                { "What is 2+2?", new List<string> { "A. 3", "B. 4", "C. 5", "D. 6" } }, // Correct Answer: B. 4
                { "What color is the sky on a clear day?", new List<string> { "A. Blue", "B. Green", "C. Red", "D. Yellow" } }, // Correct Answer: A. Blue
                { "How many wheels does a standard car have?", new List<string> { "A. 2", "B. 3", "C. 4", "D. 5" } }, // Correct Answer: C. 4
                { "What is the opposite of hot?", new List<string> { "A. Warm", "B. Cold", "C. Cool", "D. Lukewarm" } }, // Correct Answer: B. Cold
                { "Which fruit is known for keeping the doctor away?", new List<string> { "A. Banana", "B. Orange", "C. Apple", "D. Grape" } }, // Correct Answer: C. Apple
                { "What is the capital of England?", new List<string> { "A. Paris", "B. Rome", "C. Berlin", "D. London" } }, // Correct Answer: D. London
                { "What animal barks?", new List<string> { "A. Cat", "B. Dog", "C. Cow", "D. Horse" } }, // Correct Answer: B. Dog
                { "Which shape has 4 equal sides?", new List<string> { "A. Circle", "B. Triangle", "C. Square", "D. Rectangle" } }, // Correct Answer: C. Square
                { "How many days are in a week?", new List<string> { "A. 5", "B. 6", "C. 7", "D. 8" } }, // Correct Answer: C. 7
                { "What is H2O commonly known as?", new List<string> { "A. Oxygen", "B. Hydrogen", "C. Helium", "D. Water" } } // Correct Answer: D. Water
            };

            // Easy level questions
            Dictionary<string, List<string>> easy = new Dictionary<string, List<string>>
            {
                { "What is the capital of France?", new List<string> { "A. Berlin", "B. Madrid", "C. Paris", "D. Rome" } }, // Correct Answer: C. Paris
                { "Which planet is known as the Red Planet?", new List<string> { "A. Earth", "B. Mars", "C. Jupiter", "D. Saturn" } }, // Correct Answer: B. Mars
                { "What is the largest mammal?", new List<string> { "A. Elephant", "B. Blue Whale", "C. Giraffe", "D. Hippopotamus" } }, // Correct Answer: B. Blue Whale
                { "Who wrote 'Romeo and Juliet'?", new List<string> { "A. Charles Dickens", "B. William Shakespeare", "C. Jane Austen", "D. Mark Twain" } }, // Correct Answer: B. William Shakespeare
                { "Which planet is closest to the sun?", new List<string> { "A. Venus", "B. Earth", "C. Mercury", "D. Mars" } }, // Correct Answer: C. Mercury
                { "What is the largest desert in the world?", new List<string> { "A. Sahara", "B. Gobi", "C. Kalahari", "D. Antarctic" } }, // Correct Answer: D. Antarctic
                { "What is the longest river in the world?", new List<string> { "A. Amazon", "B. Nile", "C. Yangtze", "D. Mississippi" } }, // Correct Answer: B. Nile
                { "Which ocean is the largest?", new List<string> { "A. Atlantic", "B. Indian", "C. Arctic", "D. Pacific" } }, // Correct Answer: D. Pacific
                { "What is the capital of Spain?", new List<string> { "A. Madrid", "B. Barcelona", "C. Seville", "D. Valencia" } }, // Correct Answer: A. Madrid
                { "Who painted the Mona Lisa?", new List<string> { "A. Vincent van Gogh", "B. Pablo Picasso", "C. Leonardo da Vinci", "D. Claude Monet" } } // Correct Answer: C. Leonardo da Vinci
            };

            // Medium level questions
            Dictionary<string, List<string>> medium = new Dictionary<string, List<string>>
            {
                { "Who wrote 'Pride and Prejudice'?", new List<string> { "A. Charlotte Bronte", "B. Emily Bronte", "C. Jane Austen", "D. Mary Shelley" } }, // Correct Answer: C. Jane Austen
                { "In which year did the Titanic sink?", new List<string> { "A. 1912", "B. 1913", "C. 1914", "D. 1915" } }, // Correct Answer: A. 1912
                { "What is the smallest prime number?", new List<string> { "A. 0", "B. 1", "C. 2", "D. 3" } }, // Correct Answer: C. 2
                { "Who discovered penicillin?", new List<string> { "A. Marie Curie", "B. Alexander Fleming", "C. Louis Pasteur", "D. Joseph Lister" } }, // Correct Answer: B. Alexander Fleming
                { "What is the capital of Canada?", new List<string> { "A. Toronto", "B. Ottawa", "C. Vancouver", "D. Montreal" } }, // Correct Answer: B. Ottawa
                { "Which element has the chemical symbol 'O'?", new List<string> { "A. Gold", "B. Silver", "C. Oxygen", "D. Osmium" } }, // Correct Answer: C. Oxygen
                { "What is the hardest natural substance on Earth?", new List<string> { "A. Gold", "B. Iron", "C. Diamond", "D. Platinum" } }, // Correct Answer: C. Diamond
                { "What is the powerhouse of the cell?", new List<string> { "A. Nucleus", "B. Ribosome", "C. Mitochondria", "D. Endoplasmic Reticulum" } }, // Correct Answer: C. Mitochondria
                { "Which planet has the most moons?", new List<string> { "A. Earth", "B. Mars", "C. Jupiter", "D. Saturn" } }, // Correct Answer: D. Saturn
                { "What is the main ingredient in traditional Japanese miso soup?", new List<string> { "A. Soybean paste", "B. Chicken broth", "C. Fish sauce", "D. Seaweed" } } // Correct Answer: A. Soybean paste
            };

            // Hard level questions
            Dictionary<string, List<string>> hard = new Dictionary<string, List<string>>
            {
                { "Who is the author of '1984'?", new List<string> { "A. Aldous Huxley", "B. George Orwell", "C. Ray Bradbury", "D. J.R.R. Tolkien" } }, // Correct Answer: B. George Orwell
                { "Which country hosted the 2016 Summer Olympics?", new List<string> { "A. China", "B. Brazil", "C. UK", "D. Russia" } }, // Correct Answer: B. Brazil
                { "Who painted the Starry Night?", new List<string> { "A. Claude Monet", "B. Pablo Picasso", "C. Vincent van Gogh", "D. Leonardo da Vinci" } }, // Correct Answer: C. Vincent van Gogh
                { "What is the heaviest naturally occurring element?", new List<string> { "A. Uranium", "B. Lead", "C. Gold", "D. Mercury" } }, // Correct Answer: A. Uranium
                { "Who is known as the father of computers?", new List<string> { "A. Charles Babbage", "B. Alan Turing", "C. John von Neumann", "D. Steve Jobs" } }, // Correct Answer: A. Charles Babbage
                { "Which element is said to keep bones strong?", new List<string> { "A. Calcium", "B. Iron", "C. Potassium", "D. Zinc" } }, // Correct Answer: A. Calcium
                { "Who was the first person to walk on the moon?", new List<string> { "A. Yuri Gagarin", "B. Buzz Aldrin", "C. Michael Collins", "D. Neil Armstrong" } }, // Correct Answer: D. Neil Armstrong
                { "Which gas is most abundant in the Earth's atmosphere?", new List<string> { "A. Oxygen", "B. Nitrogen", "C. Carbon Dioxide", "D. Hydrogen" } }, // Correct Answer: B. Nitrogen
                { "What is the square root of 144?", new List<string> { "A. 11", "B. 12", "C. 13", "D. 14" } }, // Correct Answer: B. 12
                { "What is the capital city of Australia?", new List<string> { "A. Sydney", "B. Melbourne", "C. Canberra", "D. Brisbane" } } // Correct Answer: C. Canberra
            };

            // Very Hard level questions
            Dictionary<string, List<string>> veryHard = new Dictionary<string, List<string>>
            {
                { "What is the smallest country in the world?", new List<string> { "A. Monaco", "B. Vatican City", "C. San Marino", "D. Liechtenstein" } }, // Correct Answer: B. Vatican City
                { "In computing, what does RAM stand for?", new List<string> { "A. Random Access Memory", "B. Read Access Memory", "C. Run Access Memory", "D. Real Access Memory" } }, // Correct Answer: A. Random Access Memory
                { "Who developed the theory of relativity?", new List<string> { "A. Isaac Newton", "B. Albert Einstein", "C. Galileo Galilei", "D. Nikola Tesla" } }, // Correct Answer: B. Albert Einstein
                { "Who painted the ceiling of the Sistine Chapel?", new List<string> { "A. Leonardo da Vinci", "B. Michelangelo", "C. Raphael", "D. Donatello" } }, // Correct Answer: B. Michelangelo
                { "Which planet is known as the morning star?", new List<string> { "A. Mercury", "B. Venus", "C. Mars", "D. Jupiter" } }, // Correct Answer: B. Venus
                { "What is the chemical symbol for the element with the atomic number 1?", new List<string> { "A. H", "B. He", "C. Li", "D. Be" } }, // Correct Answer: A. H
                { "What is the longest river in the world?", new List<string> { "A. Amazon", "B. Nile", "C. Yangtze", "D. Mississippi" } }, // Correct Answer: B. Nile
                { "What is the hardest known natural material?", new List<string> { "A. Iron", "B. Diamond", "C. Platinum", "D. Graphene" } }, // Correct Answer: B. Diamond
                { "Who wrote 'Pride and Prejudice'?", new List<string> { "A. Charlotte Bronte", "B. Emily Bronte", "C. Jane Austen", "D. Mary Shelley" } }, // Correct Answer: C. Jane Austen
                { "What is the capital of Canada?", new List<string> { "A. Toronto", "B. Ottawa", "C. Vancouver", "D. Montreal" } } // Correct Answer: B. Ottawa
            };

            // Nightmare level questions
            Dictionary<string, List<string>> nightmare = new Dictionary<string, List<string>>
            {
                { "What is the value of Avogadro's number?", new List<string> { "A. 6.022 x 10^23", "B. 9.109 x 10^-31", "C. 1.602 x 10^-19", "D. 3.00 x 10^8" } }, // Correct Answer: A. 6.022 x 10^23
                { "What is the Riemann Hypothesis concerned with?", new List<string> { "A. Distribution of prime numbers", "B. Theory of relativity", "C. Quantum mechanics", "D. General topology" } }, // Correct Answer: A. Distribution of prime numbers
                { "Who won the Nobel Prize in Physics in 1921?", new List<string> { "A. Niels Bohr", "B. Max Planck", "C. Albert Einstein", "D. Marie Curie" } }, // Correct Answer: C. Albert Einstein
                { "What is the capital of Burkina Faso?", new List<string> { "A. Bamako", "B. Niamey", "C. Ouagadougou", "D. Accra" } }, // Correct Answer: C. Ouagadougou
                { "What is Schrödinger's cat thought experiment intended to demonstrate?", new List<string> { "A. Uncertainty principle", "B. Paradox of superposition", "C. Relativity of simultaneity", "D. Conservation of energy" } }, // Correct Answer: B. Paradox of superposition
                { "Which language is the basis for the Uralic languages?", new List<string> { "A. Hungarian", "B. Finnish", "C. Estonian", "D. Proto-Uralic" } }, // Correct Answer: D. Proto-Uralic
                { "Who proposed the heliocentric model of the solar system?", new List<string> { "A. Galileo Galilei", "B. Johannes Kepler", "C. Nicolaus Copernicus", "D. Ptolemy" } }, // Correct Answer: C. Nicolaus Copernicus
                { "What is the Heisenberg uncertainty principle?", new List<string> { "A. Position and velocity cannot both be measured exactly", "B. Energy cannot be created or destroyed", "C. All planets orbit the sun in ellipses", "D. Every action has an equal and opposite reaction" } }, // Correct Answer: A. Position and velocity cannot both be measured exactly
                { "What is the main subject of Gödel's incompleteness theorems?", new List<string> { "A. Computability", "B. Number theory", "C. General relativity", "D. Electromagnetism" } }, // Correct Answer: B. Number theory
                { "What does the term 'quark' refer to in particle physics?", new List<string> { "A. Fundamental constituent of matter", "B. Type of electromagnetic radiation", "C. Unit of electric charge", "D. Measure of energy" } } // Correct Answer: A. Fundamental constituent of matter
            };
            switch (difficultyLevel)
            {
                case "1":
                    return veryEasy;
                case "2":
                    return easy;
                case "3":
                    return medium;
                case "4":
                    return hard;
                case "5":
                    return veryHard;
                case "6":
                    return nightmare;
                default:
                    return veryEasy;
            }
        }
        #endregion
        #region CorrectAnswers - returns dict correctAnswers (string, string)
        public static Dictionary<string, string> CorrectAnswers(string difficulty)
        {
                Dictionary<string, string> veryEasy = new Dictionary<string, string>
                {
                    { "veryEasy 1", "B. 4" },
                    { "veryEasy 2", "A. Blue" },
                    { "veryEasy 3", "C. 4" },
                    { "veryEasy 4", "B. Cold" },
                    { "veryEasy 5", "C. Apple" },
                    { "veryEasy 6", "D. London" },
                    { "veryEasy 7", "B. Dog" },
                    { "veryEasy 8", "C. Square" },
                    { "veryEasy 9", "C. 7" },
                    { "veryEasy 10", "D. Water" },
                };
            Dictionary<string, string> easy = new Dictionary<string, string>
                {
                    { "easy 1", "C. Paris" },
                    { "easy 2", "B. Mars" },
                    { "easy 3", "B. Blue Whale" },
                    { "easy 4", "B. William Shakespeare" },
                    { "easy 5", "C. Mercury" },
                    { "easy 6", "D. Antarctic" },
                    { "easy 7", "B. Nile" },
                    { "easy 8", "D. Pacific" },
                    { "easy 9", "A. Madrid" },
                    { "easy 10", "C. Leonardo da Vinci" }
                };
            Dictionary<string, string> medium = new Dictionary<string, string>
            {
                    { "medium 1", "C. Jane Austen" },
                    { "medium 2", "A. 1912" },
                    { "medium 3", "C. 2" },
                    { "medium 4", "B. Alexander Fleming" },
                    { "medium 5", "B. Ottawa" },
                    { "medium 6", "C. Oxygen" },
                    { "medium 7", "C. Diamond" },
                    { "medium 8", "C. Mitochondria" },
                    { "medium 9", "D. Saturn" },
                    { "medium 10", "A. Soybean paste" }
            };
            Dictionary<string, string> hard = new Dictionary<string, string>
            {
                    { "hard 1", "B. George Orwell" },
                    { "hard 2", "B. Brazil" },
                    { "hard 3", "C. Vincent van Gogh" },
                    { "hard 4", "A. Uranium" },
                    { "hard 5", "A. Charles Babbage" },
                    { "hard 6", "A. Calcium" },
                    { "hard 7", "D. Neil Armstrong" },
                    { "hard 8", "B. Nitrogen" },
                    { "hard 9", "B. 12" },
                    { "hard 10", "C. Canberra" }
            };
            Dictionary<string, string> veryHard = new Dictionary<string, string>
            {
                    { "veryHard 1", "B. Vatican City" },
                    { "veryHard 2", "A. Random Access Memory" },
                    { "veryHard 3", "B. Albert Einstein" },
                    { "veryHard 4", "B. Michelangelo" },
                    { "veryHard 5", "B. Venus" },
                    { "veryHard 6", "A. H" },
                    { "veryHard 7", "B. Nile" },
                    { "veryHard 8", "B. Diamond" },
                    { "veryHard 9", "C. Jane Austen" },
                    { "veryHard 10", "B. Ottawa" }
            };
            Dictionary<string, string> nightmare = new Dictionary<string, string>
            {
                    { "nightmare 1", "A. 6.022 x 10^23" },
                    { "nightmare 2", "A. Distribution of prime numbers" },
                    { "nightmare 3", "C. Albert Einstein" },
                    { "nightmare 4", "C. Ouagadougou" },
                    { "nightmare 5", "B. Paradox of superposition" },
                    { "nightmare 6", "D. Proto-Uralic" },
                    { "nightmare 7", "C. Nicolaus Copernicus" },
                    { "nightmare 8", "A. Position and velocity cannot both be measured exactly" },
                    { "nightmare 9", "B. Number theory" },
                    { "nightmare 10", "A. Fundamental constituent of matter" }
            };
            Dictionary<string, string> somethingNotRight = new Dictionary<string, string>
            {
                {"Something went wrong", "Something went wrong" }
            };
            switch (difficulty)
            {
                case "1":
                    return veryEasy;
                case "2":
                    return easy;
                case "3":
                    return medium;
                case "4":
                    return hard;
                case "5":
                    return veryHard;
                case "6":
                    return nightmare;
                default:
                    return somethingNotRight;
            }
        }
        #endregion

        #region Scoreboard - returns dict scoreboard(string, int)
        public static Dictionary<string, int> Scoreboard(Dictionary<string, string> listOfUsers,
                                                  (Dictionary<string, string>, bool) userDetails,
                                                  bool hasPlayed,
                                                  int tempScore)
        {
            var (signedUser, isNewUser) = userDetails;
            string userName = signedUser.Keys.First();
            var scoreboard = new Dictionary<string, int>();
            Random rand = new Random(5);

            foreach (var listedUser in listOfUsers)
            {
                    scoreboard.TryAdd(listedUser.Key, rand.Next(1, 100));
            }
            return scoreboard;
        }

        #endregion
        #region PrintScoreboard - returns nothing
        public static void PrintScoreboard(string userName, string gameLogo, Dictionary<string, int> scoreboard, int tempScore)
        {
            Console.WriteLine(gameLogo);
            Console.WriteLine($"Logged in as: {userName}");
            Console.WriteLine("");
            Console.WriteLine("                                         SCOREBOARD");

            if (scoreboard.ContainsKey(userName))
            {
                scoreboard[userName] += tempScore;
            }
            else
            {
                scoreboard[userName] = tempScore;
            }

            List<KeyValuePair<string, int>> sortedList = scoreboard.ToList();
            sortedList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            string selection = "99";
            while (selection != "q")
            {
                int howManyToPrint = 10;
                int count = 0;
                foreach (var user in sortedList)
                {
                    count++;
                    if (count <= howManyToPrint)
                    {
                        string stars = count <= 3 ? new string('*', count) : "";
                        Console.WriteLine($"{count}. {user.Key}{stars}\t {user.Value} points");
                    }
                    else
                    {
                        Console.WriteLine($"{count}. {user.Key}");
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("Type Q and press Enter to go back to the Main Menu");
                selection = Console.ReadLine().ToLower();
                Console.Clear();
            }
        }

        private static int CompareValues(KeyValuePair<string, int> pair1, KeyValuePair<string, int> pair2)
        {
            return pair2.Value.CompareTo(pair1.Value);
        }


        #endregion
        #region PlayGame - returns int tempScore, out string selection, out bool hasPlayed
        public static int PlayGame(string introText, string userName,
        #region - intakes Questions and Answers (the boring part)
                                   Dictionary<string, List<string>> veryEasyQuestions,
                                   Dictionary<string, List<string>> easyQuestions,
                                   Dictionary<string, List<string>> mediumQuestions,
                                   Dictionary<string, List<string>> hardQuestions,
                                   Dictionary<string, List<string>> veryHardQuestions,
                                   Dictionary<string, List<string>> nightmareQuestions,

                                   Dictionary<string, string> veryEasyAnswers,
                                   Dictionary<string, string> easyAnswers,
                                   Dictionary<string, string> mediumAnswers,
                                   Dictionary<string, string> hardAnswers,
                                   Dictionary<string, string> veryHardAnswers,
                                   Dictionary<string, string> nightmareAnswers,
        #endregion
                                   string difficulty, out string selection, out bool hasPlayed)
        {
            int tempScore = 0;
            selection = "9";
            hasPlayed = false;

            switch (difficulty)
            {
                case "1":  // QuickPlay
                    tempScore = QuickPlay(userName, introText,
                        veryEasyQuestions,
                        veryEasyAnswers, out selection, out hasPlayed);
                    return tempScore;
                case "2":  // Progressive
                    tempScore = 0;
                    hasPlayed = true;
                    //tempScore = ProgressivePlay(userName, introText, questions, correctAnswers, out selection, out hasPlayed);
                    return tempScore;
                case "3":  // Easy
                    tempScore = EasyPlay(userName, introText,
                        easyQuestions,
                        easyAnswers, out selection, out hasPlayed);
                    return tempScore;
                case "4":  // I-know-Everything
                    tempScore = IKnowEverythingPlay(userName, introText,
                        nightmareQuestions,
                        nightmareAnswers, out selection, out hasPlayed);
                    return tempScore;
                default:
                    Console.WriteLine("Invalid difficulty selection.");
                    hasPlayed = false;
                    return tempScore;
            }
        }

        #endregion
        #region ScoreInjection - returns dict (string, int) scoreboard
        public static Dictionary<string, int> ScoreInjection(Dictionary<string, int> scoreboard, Dictionary<string, string> listOfUsers,
                                                  (Dictionary<string, string>, bool) userDetails,
                                                  bool hasPlayed,
                                                  int tempScore)
        {
            var (signedUser, isNewUser) = userDetails;
            string userName = signedUser.Keys.First();
            if (isNewUser)
            {
                if (!hasPlayed)
                {
                    scoreboard.TryAdd(userName, 0);
                }
                else
                {
                    scoreboard.TryAdd(userName, tempScore);
                }
            }
            else
            {
                scoreboard.TryAdd(userName, tempScore);
            }
            return scoreboard;
        }
        #endregion
        #region GameModeSelector - returns int difficulty
        public static string GameModeSelector(string userName, string introText)
        {
            Console.Clear();
            Console.WriteLine($"{introText}\n");
            Console.WriteLine($"Welcome {userName}!\n");
            Console.WriteLine("Select game mode:\n");
            Console.WriteLine("1. QuickPlay (2 questions each from very easy, easy, medium, hard, very hard, nightmare)");
            Console.WriteLine("2. Progressive (2 questions each from very easy, easy, medium, hard, very hard, nightmare)");
            Console.WriteLine("3. Easy (10 questions from easy)");
            Console.WriteLine("4. I-know-Everything (10 questions from nightmare)\n");
            Console.WriteLine("Enter your choice: ");

            string selection = Console.ReadLine().ToLowerInvariant();
            Console.Clear();

            if (selection == "1" || selection == "2" || selection == "3" || selection == "4")
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                selection = "9";  // Default to an invalid selection if the input is not recognized
            }

            return selection;
        }
        #endregion
        #region QuickPlay2 - ChatGPT way
        //public static int QuickPlay(string userName, string introText, Dictionary<string, string> veryEasy,
        //                    Dictionary<string, string> easy, Dictionary<string, string> medium,
        //                    Dictionary<string, string> hard, Dictionary<string, string> veryHard,
        //                    Dictionary<string, string> nightmare, Dictionary<string, string> correctAnswers,
        //                    out string selection, out bool hasPlayed)
        //{
        //    int tempScore = 0;
        //    selection = "9";
        //    hasPlayed = false;

        //    var selectedQuestions = new List<string>();
        //    selectedQuestions.AddRange(veryEasy.Keys.Take(2));
        //    selectedQuestions.AddRange(easy.Keys.Take(2));
        //    selectedQuestions.AddRange(medium.Keys.Take(2));
        //    selectedQuestions.AddRange(hard.Keys.Take(2));
        //    selectedQuestions.AddRange(veryHard.Keys.Take(2));
        //    selectedQuestions.AddRange(nightmare.Keys.Take(2));

        //    var usedQuestions = new HashSet<string>();

        //    foreach (var question in selectedQuestions)
        //    {
        //        if (!usedQuestions.Contains(question))
        //        {
        //            usedQuestions.Add(question);
        //            Console.WriteLine(question);
        //            string userAnswer = Console.ReadLine();
        //            if (correctAnswers[question].Trim().Equals(userAnswer.Trim(), StringComparison.OrdinalIgnoreCase))
        //            {
        //                tempScore++;
        //                Console.WriteLine("Correct!");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Wrong! The correct answer is {correctAnswers[question]}.");
        //            }
        //        }
        //    }
        //    Console.WriteLine($"The match has finished, your total score: {tempScore}");
        //    hasPlayed = true;
        //    return tempScore;
        //}
        #endregion
        #region QuickPlay - returns int tempScore, out string selection, out bool hasPlayed
        public static int QuickPlay(string userName, string introText, Dictionary<string, List<string>> veryEasy, Dictionary<string, string> veryEasyAnswers, out string selection, out bool hasPlayed)
        {
            int tempScore = 0;
            Random rand = new Random();
            int[] questionSelector = new int[5];

            for (int i = 0; i < questionSelector.Length; i++)
            {
                int number;
                do
                {
                    number = rand.Next(0, veryEasy.Count);
                } while (questionSelector.Contains(number));

                questionSelector[i] = number;

                Console.WriteLine(introText);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Logged in player: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"{userName}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"                                                    \tQuestion: {i + 1}/{questionSelector.Length}\t\tYour score: {tempScore}");

                string question = veryEasy.Keys.ElementAt(questionSelector[i]);
                List<string> options = veryEasy.Values.ElementAt(questionSelector[i]);

                Console.WriteLine(question);
                Console.WriteLine();
                var variants = new List<string>();

                for (int j = 0; j < options.Count; j++)
                {
                    Console.WriteLine($"{options[j]}");
                    variants.Add(options[j]);
                }
                Console.WriteLine();
                string answer;
                do
                {
                    answer = Console.ReadLine().Trim().ToLower();
                } while (answer != "a" && answer != "b" && answer != "c" && answer != "d");

                string difficulty1 = "veryEasy";
                string selectQuestionInAnswers = $"{difficulty1} {i}";
                bool isCorrect = false;
                string convertedAnswers = veryEasyAnswers.Values.ElementAt(questionSelector[i]);
                foreach (string variant in variants)
                {
                    for (int k = 0; k < variants.Count; k++)
                    {
                        string formatPlayerAnswer = $"{answer.ToUpperInvariant()}. {variants[k].Substring(3).Trim()}";
                        if (formatPlayerAnswer == convertedAnswers)
                        {
                            isCorrect = true;
                        }
                    }
                }
                if (isCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!");
                    Console.ResetColor();
                    tempScore++;
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Incorrect. ");
                    Console.ResetColor();
                    Console.WriteLine($"The correct answer is: {convertedAnswers}.");
                    Console.ReadKey();
                }
                Console.Clear();
            }
            Console.Clear();
            Console.WriteLine(introText);
            Console.WriteLine($"The match has finished, your total score: {tempScore}");
            Console.WriteLine("Type Q and press Enter to go back to Main Menu.");
            selection = "";
            selection = Console.ReadLine();
            selection.ToLower();
            while (selection != "q")
            {
                Console.Write("Re-enter your selection (Q to go back to Main Menu) :");
                selection = Console.ReadLine();
                selection = selection.ToLower();
            }
            hasPlayed = true;
            selection = "9";
            return tempScore;
        }
        #endregion
        #region EasyPlay - returns int tempScore, out string selection, out bool hasPlayed
        public static int EasyPlay(string userName, string introText, Dictionary<string, List<string>> easy,
                                   Dictionary<string, string> easyAnswers,
                                   out string selection, out bool hasPlayed)
        {
            int tempScore = 0;
            Random rand = new Random();
            int[] questionSelector = new int[10];

            for (int i = 0; i < questionSelector.Length; i++)
            {
                int number;
                do
                {
                    number = rand.Next(0, easy.Count);
                } while (questionSelector.Contains(number));

                questionSelector[i] = number;

                Console.WriteLine(introText);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Logged in player: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"{userName}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"                                                    \tQuestion: {i + 1}/{questionSelector.Length}\t\tYour score: {tempScore}");

                string question = easy.Keys.ElementAt(questionSelector[i]);
                List<string> options = easy.Values.ElementAt(questionSelector[i]);

                Console.WriteLine(question);
                Console.WriteLine();
                var variants = new List<string>();

                for (int j = 0; j < options.Count; j++)
                {
                    Console.WriteLine($"{options[j]}");
                    variants.Add(options[j]);
                }
                Console.WriteLine();
                string userAnswer;
                do
                {
                    userAnswer = Console.ReadLine().Trim().ToLower();
                } while (userAnswer != "a" && userAnswer != "b" && userAnswer != "c" && userAnswer != "d");

                string difficulty2 = "easy";
                string selectQuestionInAnswers = $"{difficulty2} {i}";
                bool isCorrect = false;
                string convertedAnswers = easyAnswers.Values.ElementAt(questionSelector[i]);
                foreach (string variant in variants)
                {
                    for (int k = 0; k < variants.Count; k++)
                    {
                        string formatPlayerAnswer = $"{userAnswer.ToUpperInvariant()}. {variants[k].Substring(3).Trim()}";
                        if (formatPlayerAnswer == convertedAnswers)
                        {
                            isCorrect = true;
                        }
                    }
                }
                if (isCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!");
                    Console.ResetColor();
                    tempScore++;
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Incorrect. ");
                    Console.ResetColor();
                    Console.WriteLine($"The correct answer is: {convertedAnswers}.");
                    Console.ReadKey();
                }
                Console.Clear();
            }
            Console.Clear();
            Console.WriteLine(introText);
            Console.WriteLine($"The match has finished, your total score: {tempScore}");
            Console.WriteLine("Type Q and press Enter to go back to Main Menu.");
            selection = "";
            selection = Console.ReadLine();
            selection.ToLower();
            while (selection != "q")
            {
                Console.Write("Re-enter your selection (Q to go back to Main Menu) :");
                selection = Console.ReadLine();
                selection = selection.ToLower();
            }
            hasPlayed = true;
            selection = "9";
            return tempScore;
        }
        #endregion
        #region ProgressivePlay - returns int tempScore, out string selection, out bool hasPlayed
        //public static int ProgressivePlay(string userName, string introText, Dictionary<string, List<string>> questions, Dictionary<string, string> correctAnswers,
        //                          out string selection, out bool hasPlayed)
        //{
        //    int tempScore = 0;
        //    selection = "9";
        //    hasPlayed = false;

        //    var selectedQuestions = new List<string>();
        //    selectedQuestions.AddRange(veryEasy.Keys.Take(2));
        //    selectedQuestions.AddRange(easy.Keys.Take(2));
        //    selectedQuestions.AddRange(medium.Keys.Take(2));
        //    selectedQuestions.AddRange(hard.Keys.Take(2));
        //    selectedQuestions.AddRange(veryHard.Keys.Take(2));
        //    selectedQuestions.AddRange(nightmare.Keys.Take(2));

        //    var usedQuestions = new HashSet<string>();

        //    foreach (var question in selectedQuestions)
        //    {
        //        if (!usedQuestions.Contains(question))
        //        {
        //            usedQuestions.Add(question);
        //            Console.WriteLine(question);
        //            string userAnswer = Console.ReadLine();
        //            if (correctAnswers[question].Trim().Equals(userAnswer.Trim(), StringComparison.OrdinalIgnoreCase))
        //            {
        //                tempScore++;
        //                Console.WriteLine("Correct!");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Wrong! The correct answer is {correctAnswers[question]}.");
        //            }
        //        }
        //    }

        //    Console.WriteLine($"The match has finished, your total score: {tempScore}");
        //    hasPlayed = true;
        //    return tempScore;
        //}
        #endregion
        #region IKnowEverythingPlay - returns int tempScore, out string selection, out bool hasPlayed
        public static int IKnowEverythingPlay(string userName, string introText, Dictionary<string, List<string>> nightmare,
                            Dictionary<string, string> nightmareAnswers,
                            out string selection, out bool hasPlayed)
        {
            int tempScore = 0;
            Random rand = new Random();
            int[] questionSelector = new int[10];

            for (int i = 0; i < questionSelector.Length; i++)
            {
                int number;
                do
                {
                    number = rand.Next(0, nightmare.Count);
                } while (questionSelector.Contains(number));

                questionSelector[i] = number;

                Console.WriteLine(introText);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Logged in player: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"{userName}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"                                                    \tQuestion: {i + 1}/{questionSelector.Length}\t\tYour score: {tempScore}");

                string question = nightmare.Keys.ElementAt(questionSelector[i]);
                List<string> options = nightmare.Values.ElementAt(questionSelector[i]);

                Console.WriteLine(question);
                Console.WriteLine();
                var variants = new List<string>();

                for (int j = 0; j < options.Count; j++)
                {
                    Console.WriteLine($"{options[j]}");
                    variants.Add(options[j]);
                }
                Console.WriteLine();
                string answer;
                do
                {
                    answer = Console.ReadLine().Trim().ToLower();
                } while (answer != "a" && answer != "b" && answer != "c" && answer != "d");

                string difficulty1 = "nightmare";
                string selectQuestionInAnswers = $"{difficulty1} {i}";
                bool isCorrect = false;
                string convertedAnswers = nightmareAnswers.Values.ElementAt(questionSelector[i]);
                foreach (string variant in variants)
                {
                    for (int k = 0; k < variants.Count; k++)
                    {
                        string formatPlayerAnswer = $"{answer.ToUpperInvariant()}. {variants[k].Substring(3).Trim()}";
                        if (formatPlayerAnswer == convertedAnswers)
                        {
                            isCorrect = true;
                        }
                    }
                }
                if (isCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!");
                    Console.ResetColor();
                    tempScore += 3;
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Incorrect. ");
                    Console.ResetColor();
                    Console.WriteLine($"The correct answer is: {convertedAnswers}.");
                    Console.ReadKey();
                }
                Console.Clear();
            }
            Console.Clear();
            Console.WriteLine(introText);
            Console.WriteLine($"The match has finished, your total score: {tempScore}");
            Console.WriteLine("Type Q and press Enter to go back to Main Menu.");
            selection = "";
            selection = Console.ReadLine();
            selection.ToLower();
            while (selection != "q")
            {
                Console.Write("Re-enter your selection (Q to go back to Main Menu) :");
                selection = Console.ReadLine();
                selection = selection.ToLower();
            }
            hasPlayed = true;
            selection = "9";
            return tempScore;
        }

        #endregion
    }
}