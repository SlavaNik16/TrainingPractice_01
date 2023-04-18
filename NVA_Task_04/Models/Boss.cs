using System;
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

        public Boss(string name, int attack, int hP, int mP)
        {
            Name = name;
            Attack = attack;
            HP = hP;
            MP = mP;
        }
    }
}
