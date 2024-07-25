using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook1
{
    public class FileManagement
    {
        FileManagement(string _path)
        {
            _Path = _path;
        }
        public string _Path { get; set; }
        public string[] Content { get; set; }
        public void WriteToFile(string content)
        {
            File.AppendAllText(_Path, content);
        }
        public string[] ReadFromFile()
        {
            Content = File.ReadAllLines(_Path);
            return Content;
        }
    }
}
