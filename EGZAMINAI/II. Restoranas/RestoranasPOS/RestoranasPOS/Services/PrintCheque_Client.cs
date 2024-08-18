using RestoranasPOS.Interfaces;
using RestoranasPOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Services
{
    public class PrintCheque_Client : Cheque
    {
        private readonly IDisplay _display;
        private readonly IFileManager _fileManager;
        public PrintCheque_Client(IFileManager fileManager, IDisplay display) : base(fileManager, display)
        {
            _display = display;
            _fileManager = fileManager;
        }
        public override int PrintChequeType()
        {
            return 1;
        }
        public override List<string> PrintTheCheque()
        {
            return _display.FormedCheque;
        }
    }
}
