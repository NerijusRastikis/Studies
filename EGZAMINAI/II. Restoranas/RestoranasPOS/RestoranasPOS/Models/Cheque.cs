using RestoranasPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Models
{
    public abstract class Cheque
    {
        private readonly IFileManager _fileManager;
        private readonly IDisplay _display;

        public Cheque(IFileManager fileManager, IDisplay display)
        {
            _fileManager = fileManager;
            _display = display;
        }
        public abstract int PrintChequeType();
        public abstract List<string> PrintTheCheque();
    }
}
