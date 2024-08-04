using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas3
{
    public interface IFileManager
    {
        string[] ReadFromUsersFile();
        string[] ReadFromATMFile();
        void WriteToUsersFile(string[] content, string cardNumber);
        void WriteToATMFile(string content);
    }
}
