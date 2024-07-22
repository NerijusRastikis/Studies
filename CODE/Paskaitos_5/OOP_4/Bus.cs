using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_4
{
    internal class Bus : Vehicle
    {
        public Bus(int numberOfWheels, double engineLitres, bool isEngineOn, string name) : base(numberOfWheels, engineLitres, isEngineOn, name)
        {
            Name = name;
            NumberOfWheels = numberOfWheels;
            IsEngineOn = isEngineOn;
            EngineLitres = engineLitres;
        }

        public override int CountTotalWheels()
        {
            return 4;
        }

        public override bool EngineStarted()
        {
            return false;
        }

        public override double TotalPower()
        {
            return 2.8;
        }
    }
}
