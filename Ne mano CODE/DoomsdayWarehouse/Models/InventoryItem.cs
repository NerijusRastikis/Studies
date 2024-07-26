using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomsdayWarehouse.Models
{
    public abstract class InventoryItem
    {
        public string Name { get; set; }
        public double Weight { get; set; }

        public abstract InventoryItem FromCSV(string csvLine);
        public abstract string ToCSV();

    }
}
