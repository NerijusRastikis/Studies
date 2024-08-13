using RestoranasPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Services
{
    public class SimpleTest
    {
        private readonly IFileManager _fileManager;
        private readonly IDisplay _display;

        public SimpleTest(IFileManager fileManager, IDisplay display)
        {
            _fileManager = fileManager;
            _display = display;
        }
        public void Test()
        {
            List<string> testSubject = new List<string>(_display.ViewCheque());
            foreach (var subject in testSubject)
            {
                Console.WriteLine(subject);
            }
            Console.ReadKey();
        }
    }
}
