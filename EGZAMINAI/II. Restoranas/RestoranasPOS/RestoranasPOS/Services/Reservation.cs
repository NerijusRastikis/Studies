using RestoranasPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Services
{
    public class Reservation
    {
        private readonly IDisplay _display;
        private readonly IFileManager _fileManager;

        public Reservation(IDisplay display, IFileManager fileManager)
        {
            _display = display;
            _fileManager = fileManager;
        }

        public void AddClientToReservationsFile()
        {
            string[] captured_ClientInfo = _display.ReserveTable().ToArray();
            string readyToSave_ClientInfo;
            readyToSave_ClientInfo = String.Join(',', captured_ClientInfo);
            _fileManager.WriteTo_Reservations(readyToSave_ClientInfo);
        }
    }
}
