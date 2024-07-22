using Pirma;
using System.Security.Cryptography.X509Certificates;

namespace Paskaitos_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Paskaitos data: 2024-06-26

            // OOP

            // Ir klases

            #region -- 1.1 --
            Person people = new Person("Jonas", 18, 187);
            List<Person> list = new List<Person>();
            list.Add(people);
            foreach (Person person in list)
            {
                Console.WriteLine("------------");
                Console.WriteLine(person);
                Console.WriteLine("------------");
            }
            #endregion
            #region -- 1.2 --
            School school = new School(1000);
            List<School> schools = new List<School>();
            schools.Add(school);
            foreach (School school1 in schools)
            {
                Console.WriteLine("<><><><><>");
                Console.WriteLine(school1);
                Console.WriteLine("<><><><><>");
            }
            #endregion

            #region -- 2.1 --
            Book book1 = new Book();
            List<Book> listOfBooks1 = new List<Book>();
            listOfBooks1.Add(book1);
            foreach (Book books in listOfBooks1)
            {
                Console.WriteLine(books);
                Console.WriteLine("-------");
            }
            #endregion
            #region -- 2.2 --
            Book book2 = new Book("Olandija");
            List<Book> listOfBooks2 = new List<Book>();
            listOfBooks1.Add(book2);
            foreach (Book books in listOfBooks2)
            {
                Console.WriteLine(books);
                Console.WriteLine("-------");
            }
            #endregion
            #region -- 2.3 --
            Book book3 = new Book("Vienas", "Autorius1", 2012, "Lietuva");
            listOfBooks1.Add(book3);
            Book book4 = new Book("Du", "Autorius2", 2022, "Vokietija");
            listOfBooks1.Add(book4);
            static List<Book> SearchByName(string name, List<Book> list)
            {
                List<Book> list2 = new List<Book>();
                foreach (Book book in list)
                {
                    if (book.Autorius == "Autorius1")
                    {
                        list2.Add(book);
                        return list2;
                    }
                }
                return list2;
            }
            List<Book> returnedBook = new List<Book>();
            returnedBook = SearchByName("Autorius1", listOfBooks1);
            foreach (Book book in returnedBook)
            {
                Console.WriteLine("|||||||||||||");
                Console.WriteLine(book);
            }
            #endregion
            #region -- 2.4 --
            List<string> items1 = new List<string> { "Tomatoes", "Cucumbers", "Potatoes", "Carrots", "Cabbages" };
            List<string> items2 = new List<string> { "Oranges", "Blueberries", "Lemons", "Melons", "Pineapples" };
            List<string> items3 = new List<string> { "Dark Chocolate", "White Chocolate", "Brownies", "Cookies", "Home-made snack bars" };
            Store store1 = new Store("Silas", 2008, items1);
            Store store2 = new Store("IKI", 1998, items2);
            Store store3 = new Store("Maxima", 1989, items3);
            List<Store> storesInformation = new List<Store>();
            storesInformation.Add(store1);
            storesInformation.Add(store2);
            storesInformation.Add(store3);
            Console.WriteLine("S T O R E S");
            foreach (Store info in storesInformation)
            {
                Console.Write($"{info.Name} {info.Year} - ");
                foreach (string item in info.Items)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
                Console.WriteLine("----------");
            }
            #endregion

            #region -- 3.1 --
            Dog dog1 = new Dog("Aras", new DateTime(2015, 10, 10), "Mix");
            Cat cat1 = new Cat("Mėmius", new DateTime(2023, 01, 17), "R.I.P. (Aras)");
            Hamster hamster1 = new Hamster("Troškinys", new DateTime(2024, 03, 21), "R.I.P. (Mėmius)");
            Dog dog2 = new Dog("Dora", new DateTime(1999, 7, 13), "Woof");
            Hamster hamster2 = new Hamster("Šuo", new DateTime(2024, 5, 1), "Rat");
            List<Dog> dogs = new List<Dog>();
            dogs.Add(dog1);
            dogs.Add(dog2);
            List<Cat> cats = new List<Cat>();
            cats.Add(cat1);
            List<Hamster> hamsters = new List<Hamster>();
            hamsters.Add(hamster1);
            hamsters.Add(hamster2);

            Console.WriteLine("-- 3.1 --");
            foreach (string animal in Animals(dog1, cat1, hamster1))
            {
                Console.WriteLine($"{animal} ");
            }
            #endregion
            #region -- 3.2 --
            Console.WriteLine("--- ANIMALS COUNT ---");
            foreach (var kvp in CountAnimals(dogs, cats, hamsters))
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value}");
            }
            #endregion
            #region -- 3.3 --
            Square square = new Square();
            Triangle triangle = new Triangle();
            CIrcle cIrcle = new CIrcle();
            Console.WriteLine("-- 3.3 --");
            Console.WriteLine($"Square - Area: {(CalcSquare(square, 1).ToString("F2"))}, Perimeter: {(CalcSquare(square, 2).ToString("F2"))}");
            Console.WriteLine($"Triangle - Area: {(CalcTriangle(triangle, 1).ToString("F2"))}, Perimeter: {(CalcTriangle(triangle, 2).ToString("F2"))}");
            Console.WriteLine($"Circle - Area: {(CalcCircle(cIrcle, 1).ToString("F2"))}, Perimeter: {(CalcCircle(cIrcle, 2).ToString("F2"))}");
            #endregion
            #region -- 4.1 --
            Car car1 = new Car()
            {
                Engine = new Engine(true)
            };
            #endregion
        }

        //
        // O T H E R
        // M E T H O D S
        //

        public static List<string> Animals(Dog dog1, Cat cat1, Hamster hamster1)
        {
            List<string> listOfAnimals = new List<string>();
            listOfAnimals.Add(dog1.Name);
            listOfAnimals.Add(cat1.Name);
            listOfAnimals.Add(hamster1.Name);
            return listOfAnimals;
        }
        public static Dictionary<string, int> CountAnimals(List<Dog> dogs, List<Cat> cats, List<Hamster> hamsters)
        {
            Dictionary<string, int> animalsCount = new Dictionary<string, int>();
            int count = 1;
            foreach (Dog dog in dogs)
            {
                if (animalsCount.ContainsKey("Dog"))
                {
                    animalsCount["Dog"]++;
                }
                else
                {
                    animalsCount["Dog"] = 1;
                }
            }
            count = 1;
            foreach (Cat cat in cats)
                {
                if (animalsCount.ContainsKey("Cat"))
                {
                    animalsCount["Cat"]++;
                }
                else
                {
                    animalsCount["Cat"] = 1;
                }
            }
            count = 1;
            foreach (Hamster hamster in hamsters)
            {
                if (animalsCount.ContainsKey("Hamster"))
                {
                    animalsCount["Hamster"]++;
                }
                else
                {
                    animalsCount["Hamster"] = 1;
                }
            }
            return animalsCount;
        }
        public static double CalcSquare(Square square, int areaOrPerimeter)
        {
            switch (areaOrPerimeter)
            {
                case 1:
                    return square.Side1 * square.Side2;
                case 2:
                    return square.Side1 + square.Side2;
                default:
                    return 0;
            }
        }
        public static double CalcTriangle(Triangle triangle, int areaOrPerimeter)
        {
            switch (areaOrPerimeter)
            {
                case 1:
                    return (triangle.Base * triangle.Height) / 2;
                case 2:
                    return Math.Sqrt(Math.Pow(triangle.Base, 2) + Math.Pow(triangle.Height, 2));
                default:
                    return 0;
            }
        }
        public static double CalcCircle(CIrcle cIrcle, int areaOrPerimeter)
        {
            switch (areaOrPerimeter)
            {
                case 1:
                    return Math.PI * Math.Pow(cIrcle.Radius, 2);
                case 2:
                    return 2 * Math.PI * cIrcle.Radius;
                default:
                    return 0;
            }
        }
        //public static bool IsEngineOn(Car car)
        //{
        //    if (car.Engine.OnOff)
        //        return true;
        //}
    }
}
