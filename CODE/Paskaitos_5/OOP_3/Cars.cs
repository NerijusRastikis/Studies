using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    public class Cars
    {
        public Cars(string make, string model, DateTime year, double price, bool isAvailable, int maxSpeed, int capacity, string fuelEfficiency)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            IsAvailable = isAvailable;
            MaxSpeed = maxSpeed;
            Capacity = capacity;
            FuelEfficiency = fuelEfficiency;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public int MaxSpeed { get; set; }
        public int Capacity { get; set; }
        public string FuelEfficiency { get; set; }
    }
}
