using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVA_Task_04.Models
{
    public class Guardians
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int HP { get; set; }

        public Guardians(string name)
        {
            Name = name;
            Attack = new Random().Next(11, 12);
            HP = new Random().Next(500, 700);
        }
    }
}
