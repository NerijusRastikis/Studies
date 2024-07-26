using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Kartojimas1
{
    public class BufferedFileLogger : FileMyLogger
    {
        private readonly string _filePath;

        public int MessagesLimit { get; set; }
        public BufferedFileLogger(int messagesLimit, string filePath)
        {
            MessagesLimit = messagesLimit;
            _filePath = filePath;
        }

        public void Flush()
        {
            var tempLogCount = File.ReadAllLines(_filePath).Length;
            if (tempLogCount > MessagesLimit)
            {
                File.Delete(_filePath);
            }
        }
    }
}
