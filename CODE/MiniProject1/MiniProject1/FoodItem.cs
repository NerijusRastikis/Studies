using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject1
{
    public class FoodItem : InventoryItem
    {
        public DateTime Expire { get; set; }
        public int Calories { get; set; }
    }
}
