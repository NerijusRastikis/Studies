using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas3
{
    public interface IUser
    {
        //public string GetAndCheck_CardNumber();
        //public int GetAndCheck_PIN();
        public string GetName();
        public decimal GetMoney();
    }
}
