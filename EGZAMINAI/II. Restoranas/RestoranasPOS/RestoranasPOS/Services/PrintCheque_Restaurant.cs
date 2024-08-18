using RestoranasPOS.Interfaces;
using RestoranasPOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Services
{
    public class PrintCheque_Restaurant : Cheque
    {
        private readonly IDisplay _display;
        private readonly IFileManager _fileManager;
        public PrintCheque_Restaurant(IFileManager fileManager, IDisplay display) : base(fileManager, display)
        {
            _display = display;
            _fileManager = fileManager;
        }

        public override int PrintChequeType()
        {
            return 2;
        }

        public override List<string> PrintTheCheque()
        {
            var chequeToPrint = _display.FormedCheque;
            string lastLine = chequeToPrint.Last();
            chequeToPrint.RemoveAt(chequeToPrint.Count - 1);
            chequeToPrint.Add($"|Padavėjo arbatpinigiai: {_display.WaiterTips} eur |");
            chequeToPrint.Add($"|Staliuko uždarbis: {_display.TableEarnings} eur |");
            chequeToPrint.Add(lastLine);
            return chequeToPrint;
        }
    }
}
