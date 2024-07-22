using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirma
{
    public class Engine
    {
        public Engine(bool onOff)
        {
            OnOff = onOff;
        }
        public bool OnOff { get; set; }
    }
}
