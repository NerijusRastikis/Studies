using RestoranasPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Models
{
    public class Client : IClient
    {
        public string Name { get; set; }
        public int TableNumber { get; set; }
        public string Time { get; set; }
        public int PhoneNumber { get; set; }
    }
}
