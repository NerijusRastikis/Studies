using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject1
{
    public class MedicalItem : InventoryItem
    {
        public DateTime Expire { get; set; }
        public string CuresFrom { get; set; }
    }
}
