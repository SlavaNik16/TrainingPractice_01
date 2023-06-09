﻿namespace NVA_Task_04.Models
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

        public void Spell(Player player)
        {
            var rnd = new Random();
            switch (rnd.Next(0, 10))
            {
                case >= 0 and <= 5:
                    Console.WriteLine($"\nСтражник атакует базовой атакой в размере {Attack}");
                    player.HP -= Attack;
                    break;
                case >=6 and <=7:
                    var hp = new Random().Next(12, 18);
                    Console.WriteLine($"\nСтражник лечит себя в размере {hp}");
                    HP += hp;
                    break;
                case 8:
                    var attack = new Random().Next(1, 3);
                    Console.WriteLine($"\nСтражник увеличивает базовый урон на {attack}");
                    Attack += attack;
                    break;
                case 9:
                    Console.WriteLine($"\nСтражник атакует базовой атакой в размере {Attack}. Удар пришелся по голове!\n");
                    Console.WriteLine($"Стражник оглушает вас на {1} ход");
                    player.HP -= Attack;
                    player.Pass = 1;
                    break;

            }
        }
    }
}
