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
            var controller = new MenuController(_display);
            controller.Controller();
        }
    }
}
