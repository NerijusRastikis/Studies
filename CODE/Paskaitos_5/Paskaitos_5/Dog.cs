﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirma
{
    public class Dog
    {
        public Dog()
        {

        }
        public Dog(string name, DateTime born, string type)
        {
            Name = name;
            Born = born;
            Type = type;
        }
        public string Name { get; set; }
        public DateTime Born { get; set; }
        public string Type { get; set; }
    }
}