namespace Delegatai_Anoniminiai_Metodai
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Paskaitos data: 2024-07-22
            Menu menu = new Menu();
            Handler1 handler1 = new Handler1();
            Handler2 handler2 = new Handler2();

            handler1.Subscribe(menu);
            handler2.Subscribe(menu);

            menu.ShowMenu();


        }
    }
    /* KLAUSIMAS ===>> Kokia bus konsolėje išvedama reikšmė? kodėl?*/
    public class Supratimo3
    {
        public delegate void MyDelegate(int number);

        public void PrintNumber(int number)
        {
            Console.WriteLine("Number: " + number);
        }

        public void A_Main()
        {
            MyDelegate del = PrintNumber;
            del(5);

            del = null;
            del.Invoke(10);
        }
    }
    /* KLAUSIMAS ===>> Kokia bus konsolėje išvedama reikšmė? kodėl?*/
    public class Supratimo4
    {
        public delegate void MyDelegate(string message);

        public void MethodOne(string message)
        {
            Console.WriteLine("MethodOne: " + message);
        }

        public void MethodTwo(string message)
        {
            Console.WriteLine("MethodTwo: " + message);
        }

        public void A_Main()
        {
            MyDelegate del = MethodOne;
            del("First Call");

            del = MethodTwo;
            del("Second Call");
        }
    }
    /* KLAUSIMAS ===>> Kokia bus konsolėje išvedama reikšmė? kodėl?*/
    public class Supratimo6
    {
        public delegate void MyDelegate(string message);

        public void MethodOne(string message)
        {
            Console.WriteLine("MethodOne: " + message);
        }

        public void MethodTwo(string message)
        {
            Console.WriteLine("MethodTwo: " + message);
        }

        public void MethodThree(string message)
        {
            Console.WriteLine("MethodThree: " + message);
        }

        public void A_Main()
        {
            MyDelegate del = MethodOne;
            del += MethodTwo;
            del += MethodThree;
            del -= MethodTwo;

            del("Hello, Multicast!");
        }
    }
    /* KLAUSIMAS ===>> Kokia bus konsolėje išvedama reikšmė? kodėl?*/
public class Supratimo8
    {
        public delegate void MyEventHandler(string message);
        public event MyEventHandler MyEvent;

        public void MethodOne(string message)
        {
            Console.WriteLine("MethodOne: " + message);
        }

        public void MethodTwo(string message)
        {
            Console.WriteLine("MethodTwo: " + message);
        }

        public void A_Main()
        {
            MyEvent += MethodOne;
            MyEvent += MethodTwo;

            OnMyEvent("Hello, Events!");
        }

        protected void OnMyEvent(string message)
        {
            if (MyEvent != null)
            {
                MyEvent(message);
            }
        }
    }
    /* KLAUSIMAS ===>>  Kokia bus konsolėje išvedama reikšmė? kur čia yra predikatas?*/
public class Supratimo5
    {
        public bool IsEvenPredicate(int number)
        {
            return number % 2 == 0;
        }

        public void A_Main()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            List<int> evenNumbers = numbers.FindAll(IsEvenPredicate);
            Console.WriteLine(string.Join(",", evenNumbers));
        }
    }
    /* KLAUSIMAS ===>> Jei vartotojas įveda "2" kaip savo pasirinkimą, kokia bus konsolėje išvedama reikšmė? kodėl?*/
    public class Menu
    {
        public event Action<int> OnMenuSelection;

        public void ShowMenu()
        {
            Console.WriteLine("Pasirinkite meniu punktą:");
            Console.WriteLine("1. Pasirinkimas 1");
            Console.WriteLine("2. Pasirinkimas 2");
            Console.WriteLine("3. Pasirinkimas 3");

            int selection = Convert.ToInt32(Console.ReadLine());

            // Suaktyviname įvykį
            OnMenuSelection?.Invoke(selection);
        }
    }
    public class Handler1
    {
        public void Subscribe(Menu menu)
        {
            menu.OnMenuSelection += HandleSelection;
        }

        private void HandleSelection(int selection)
        {
            if (selection == 1)
            {
                Console.WriteLine("Handler1: Pasirinkimas 1 apdorotas.");
            }
        }
    }
    public class Handler2
    {
        public void Subscribe(Menu menu)
        {
            menu.OnMenuSelection += HandleSelection;
        }

        private void HandleSelection(int selection)
        {
            if (selection == 2)
            {
                Console.WriteLine("Handler2: Pasirinkimas 2 apdorotas.");
            }
        }
    }
    public class Supratimo12
    {
        public static void A_Main()
        {
            Menu menu = new Menu();
            Handler1 handler1 = new Handler1();
            Handler2 handler2 = new Handler2();

            handler1.Subscribe(menu);
            handler2.Subscribe(menu);

            menu.ShowMenu();
        }
    }
}
