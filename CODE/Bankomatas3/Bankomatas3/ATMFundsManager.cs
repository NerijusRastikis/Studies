using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas3
{
    public class ATMFundsManager : IATMFundsManager
    {
        private readonly string _pathATM;
        private readonly IFileManager FM;
        private readonly decimal _withdrawAmount;
        public decimal TotalFundsInATM { get; set; }
        public ATMFundsManager(string pathATM, IFileManager fM)
        {
            _pathATM = pathATM;
            FM = fM;
        }
        public decimal TotalFundsOfATM()
        {
            var fundsATM = FM.ReadFromATMFile();
            foreach (var fund in fundsATM)
            {
                var detailedLine = fund.Split(',');
                TotalFundsInATM += int.Parse(detailedLine[0]) * decimal.Parse(detailedLine[1]);
            }
            return TotalFundsInATM;
        }
        public void DeductDenominations()
        {
            TotalFundsInATM -= _withdrawAmount;
            if (_withdrawAmount % 100 == 0)
            {
                decimal deductFromATM = _withdrawAmount / 100;
                var fundsATM = FM.ReadFromATMFile();
                foreach(var fund in fundsATM)
                {
                    var detailedLine = fund.Split(",");
                    if (detailedLine[0] == "100")
                    {
                        detailedLine[1] = (decimal.Parse(detailedLine[1]) - deductFromATM).ToString();
                    }
                }
            }
        }
        public void DistributeDenominations_ToUser()
        {
            throw new NotImplementedException();
        }
    }
}
