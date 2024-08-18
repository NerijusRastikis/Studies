using RestoranasPOS.Interfaces;
using RestoranasPOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Models
{
    public class POS_Logic
    {
        private readonly IFileManager _fileManager;
        private readonly IDisplay _display;

        public POS_Logic(IFileManager fileManager, IDisplay display)
        {
            _fileManager = fileManager;
            _display = display;
        }
        public void Start()
        {
            var controller = new MenuController(_display, _fileManager, this);
            PopulateTableStatuses();
            controller.FirstRun();
        }
        public void PopulateTableStatuses()
        {
            _display.TableStatus.TryAdd("#1 Staliukas", 2);
            _display.TableStatus.TryAdd("#2 Staliukas", 2);
            _display.TableStatus.TryAdd("#3 Staliukas", 2);
            _display.TableStatus.TryAdd("#4 Staliukas", 2);
            _display.TableStatus.TryAdd("#5 Staliukas", 2);
            _display.TableStatus.TryAdd("#6 Staliukas", 2);
        }
        public string ConvertToString_Reservations()
        {
            string? whatToReturn;
            var capturedList = _display.ReserveTable().ToArray();
            return string.Join(", ", capturedList);
        }
        public void PrintReservations()
        {
            _display.ViewReservations();
            var laikinas0 = _fileManager.ReadFrom_Reservations();
            var laikinas1 = laikinas0[0];
            var laikinas2 = laikinas1.Split(',');
            Console.WriteLine($"Vardas: {laikinas2[0]}, Staliukas: #{laikinas2[1]}, Laikas: {laikinas2[2]}, Tel. Numeris: {laikinas2[3]}");
            _display.PressAnyKeyToContinue();
        }
    }
}
