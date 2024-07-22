using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    public class Hooman()
    {
        public Hooman(List<Vehicle> vehicles, string name, bool isAssigned, int ownedVehicles)
        {
            Name = name;
            IsAssigned = isAssigned;
            OwnedVehicles = ownedVehicles;
            Vehicles = vehicles;
        }
        public string Name { get; set; }
        public bool IsAssigned { get; set; }
        public int OwnedVehicles { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
