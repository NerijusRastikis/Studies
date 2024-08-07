using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Services
{
    public class PrintCheque
    {
        public virtual Dictionary<string, decimal> OrderTableSubtotalInfo { get; }
        public virtual decimal TotalPrice { get; }
        public virtual DateTime Time {  get; }
        public virtual void Print_Cheque()
        {

        }
    }
}
