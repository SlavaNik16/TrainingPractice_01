﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVA_Task_04.Models
{
    public class Boss
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }

        public Boss(string name)
        {
            Name = name;
            Attack = new Random().Next(20, 30);
            HP = new Random().Next(900, 1500);
            MP = 0;
        }
    }
}
