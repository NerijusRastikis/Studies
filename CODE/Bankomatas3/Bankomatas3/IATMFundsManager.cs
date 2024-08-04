using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas3
{
    public interface IATMFundsManager
    {
        public decimal TotalFundsOfATM();
        public void DeductDenominations();
        public void DistributeDenominations_ToUser();
    }
}
