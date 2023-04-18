using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVA_Task_04.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }

        public Player(string name)
        {
            Name = name;
            Attack = new Random().Next(10,14);
            HP = new Random().Next(800, 1300);
            MP = 0;
        }
    }
}
