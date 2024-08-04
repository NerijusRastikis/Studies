using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas3
{
    public class User : IUser
    {
        public User(string cardNumber, int pin, string name, decimal funds, IFileManager fileManager)
        {
            CardNumber = cardNumber;
            PIN = pin;
            Name = name;
            Funds = funds;
            FM = fileManager;
        }
        public string CardNumber { get; set; }
        public int PIN { get; set; }
        public string Name { get; set; }
        public decimal Funds { get; set; }
        public IFileManager FM { get; set; }
        public int GetAndCheck_PIN()
        {
            var users = FM.ReadFromUsersFile();
            foreach (var user in users)
            {
                var dicedUserLine = user.Split(',');
                if (int.Parse(dicedUserLine[1]) == PIN)
                {
                    PIN = int.Parse(dicedUserLine[1]);
                    return PIN;
                }
                else return 0;
            }
            return PIN;
        }
        public string GetName()
        {
            var users = FM.ReadFromUsersFile();
            foreach (var user in users)
            {
                var dicedUserLine = user.Split(',');
                if (dicedUserLine[3] == Name)
                {
                    Name = dicedUserLine[3];
                    return Name;
                }
                else return null;
            }
            return Name;
        }
        public decimal GetMoney()
        {
            var users = FM.ReadFromUsersFile();
            foreach (var user in users)
            {
                var dicedUserLine = user.Split(',');
                if (dicedUserLine[0] == CardNumber)
                {
                    Funds = decimal.Parse(dicedUserLine[2]);
                    return Funds;
                }
                else return Funds = 0;
            }
            return Funds;
        }
    }
}
