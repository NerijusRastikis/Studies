using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Interfaces
{
    public interface IFileManager
    {
        public Dictionary<string, decimal> ReadFrom_Alkodrinks();
        public Dictionary<string, decimal> ReadFrom_Nonalkodrinks();
        public Dictionary<string, decimal> ReadFrom_Snacks();
        public Dictionary<string, decimal> ReadFrom_Coldfood();
        public Dictionary<string, decimal> ReadFrom_Hotfood();
        public Dictionary<string, decimal> ReadFrom_Cheques();
        public string[] ReadFrom_Clients();


        public void WriteTo_Clients(string clientInfo);

    }
}
