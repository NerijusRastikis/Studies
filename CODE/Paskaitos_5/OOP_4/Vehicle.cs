using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    public abstract class Vehicle
    {
        protected Vehicle(int numberOfWheels, double engineLitres, bool isEngineOn, string name)
        {
         
        }

        public int NumberOfWheels { get; set; }
        public double EngineLitres { get; set; }
        public bool IsEngineOn { get; set; }
        public string Name { get; set; }
        public abstract bool EngineStarted();
        public abstract int CountTotalWheels();
        public abstract double TotalPower();
    }
}
