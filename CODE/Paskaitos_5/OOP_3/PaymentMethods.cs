using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    public class PaymentMethods
    {
        public PaymentMethods(bool payingCash, bool payingPaypal, bool payingCreditCard, bool payingOther)
        {
            PayingCash = payingCash;
            PayingPaypal = payingPaypal;
            PayingCreditCard = payingCreditCard;
            PayingOther = payingCash;
        }
        public bool PayingCash { get; set; }
        public bool PayingPaypal { get; set; }
        public bool PayingCreditCard { get; set; }
        public bool PayingOther { get; set; }
    }
}
