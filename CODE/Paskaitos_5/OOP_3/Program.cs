namespace OOP_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Employee-to-Manager - Greeting
            //var employee1 = new Employee();
            //employee1.Greeting();
            //employee1 = new Manager();
            //employee1.Greeting();
            #endregion
            #region Circle and Rectangle - Draw
            //var circle1 = new Circle();
            //Console.WriteLine(circle1.Draw());
            //var rectangle1 = new Rectangle();
            //Console.WriteLine(rectangle1.Draw());
            #endregion
            #region Car leasing bussiness model
            var car1 = new Cars("Mazda", "CX-3", new DateTime (2019, 01, 15), 172, false, 180, 5, "B");
            var car2 = new Cars("Mazda", "CX-5", new DateTime(2020, 10, 15), 150, true, 165, 5, "B");
            var car3 = new Cars("Opel", "Insignia", new DateTime(2015, 07, 15), 180, true, 144, 5, "C");
            var car4 = new Cars("Peugeot", "508", new DateTime(2018, 03, 15), 145, false, 165, 5, "A");
            var car5 = new Cars("Renault", "Espace", new DateTime(2012, 12, 15), 99, true, 145, 7, "B");
            //var customer1 = new Customer();
            


            #endregion

            Console.ReadLine();
        }
//        public int Welcome()
//        {
//            string welcome = @"WELCOME TO CAR LEASING!

//Please select your choice:

//1. Rent a car
//2. View cars list

//Thank you!";
//            Console.WriteLine(welcome);
//            int choice;
//            while (int.TryParse(Console.ReadLine(), out choice))
//                {
//                    if (choice == 1)
//                    {

//                    }
//                    else if (choice == 2)
//                    {

//                    }
//                    else
//                    {
//                    Console.WriteLine(welcome);
//                }
//                }
//            }
//        }
    }
}
