using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOP_Kartojimas1.Program;

namespace OOP_Kartojimas1
{
    public class FileMyLogger : IMyLogger
    {
        private readonly string _filePath;
        public FileMyLogger(string filePath)
        {
            _filePath = filePath;
        }
        public void Log(string message)
        {
            try
            {
                Console.WriteLine(message);
            }
            catch
            {
                throw new Exception(message);
            }
        }
    }
}
