namespace OOP_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Square and Triangle
            //var triangle = new Triangle(10, 5, "Triangle");
            //var square = new Square(4, 2, "Square");
            //List<GeometricShape> geometricShapes = new List<GeometricShape>();
            //geometricShapes.Add(triangle);
            //geometricShapes.Add(square);
            //foreach (var shape in geometricShapes)
            //{
            //    double area = shape.GetArea();
            //    string name = shape.Name;
            //    double perimeter = shape.GetPerimeter();
            //    Console.WriteLine($"Area of {name.ToLower()} = {area}");
            //    Console.WriteLine($"Perimeter of {name.ToLower()} = {perimeter}");
            //    Console.WriteLine();
            //}
            #endregion
            #region Vehicle
            var truck = new Truck(6, 3.6, true, "Truck");
            var bus = new Bus(4, 2.8, false, "Bus");
            var motorbike = new Motorbike(2, 0.4, false, "Motorbike");
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(truck);
            vehicles.Add(bus);
            vehicles.Add(motorbike);

            string isOn;
            int totalWheels = 0;
            double totalPower = 0;
            foreach (var vehicle in vehicles)
            {
                if (vehicle.IsEngineOn)
                {
                    isOn = "ON";
                }
                else
                {
                    isOn = "OFF";
                }
                totalPower += vehicle.TotalPower();
                totalWheels += vehicle.CountTotalWheels();
                Console.WriteLine($"{vehicle.Name}'s engine is: \t\t{isOn}");
                Console.WriteLine($"Current total wheels: \t\t{totalWheels}");
                Console.WriteLine($"Current total engine power: \t{totalPower.ToString("F2")}");
                Console.WriteLine();
            }
            Console.WriteLine("<><><><>");
            Hooman hooman1 = new Hooman(vehicles);
            #endregion
            Console.ReadLine();
        }
    }
}
