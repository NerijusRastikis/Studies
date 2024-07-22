using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    public class Truck : Vehicle
    {
        public Truck(int numberOfWheels, double engineLitres, bool isEngineOn, string name) : base(numberOfWheels, engineLitres, isEngineOn, name)
        {
            Name = name;
            NumberOfWheels = numberOfWheels;
            IsEngineOn = isEngineOn;
            EngineLitres = engineLitres;
        }

        public override int CountTotalWheels()
        {
            return 6;
        }

        public override bool EngineStarted()
        {
            return true;
        }

        public override double TotalPower()
        {
            return 3.6;
        }
    }
}
