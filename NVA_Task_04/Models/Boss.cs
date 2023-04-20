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

        public Boss(string name)
        {
            Name = name;
            Attack = new Random().Next(20, 30);
            HP = new Random().Next(900, 1500);
            MP = 0;
        }

        public void Spell(Player player)
        {
            var rnd = new Random();
            switch (rnd.Next(0, 10))
            {
                case >= 0 and <= 3:
                    var attackMP = new Random().Next(0, 3);
                    if (attackMP == 1 && MP >= 20)
                    {

                        Console.WriteLine($"\nБОСС атакует мощным ударом усиливая его маной в два раза в размере {Attack * 2} и повышает свою атаку на 2");
                        player.HP -= Attack * 2;
                        Attack += 2;
                        MP -= 20;
                       
                    }
                    else if (attackMP == 2 && MP >= 50)
                    {
                       
                        Console.WriteLine($"\nБОСС атакует мощным ударом усиливая его маной в 5 раз в размере {Attack * 5}");
                        player.HP -= Attack * 5;
                        MP -= 50;
                        
                    }
                    else
                    {
                        Console.WriteLine($"\nБОСС атакует мощным ударом в размере {Attack}"); 
                        player.HP -= Attack;
                    }
                    break;
                case >= 4 and <= 6:
                    var hpMP = new Random().Next(0, 2);
                    if (hpMP == 1 && MP >= 30)
                    {
                        var hp = new Random().Next(100, 150);
                        Console.WriteLine($"\nБОСС лечит себя неизвестной магии лечения в размере {hp}");
                        HP += hp;
                        MP -= 20;

                    }      
                    else
                    {
                        var hp = new Random().Next(30, 50);
                        Console.WriteLine($"\nБОСС лечит себя в размере {hp}");
                        HP += hp;
                    }
                    
                    break;
                case >= 7 and <= 8:
                    var attack = new Random().Next(1, 3);
                    Console.WriteLine($"\nСтражник увеличивает базовый урон на {attack}");
                    Attack += attack;
                    break;
                case 9:
                    Console.WriteLine($"\nСтражник атакует базовой аттакой в размере {Attack}. Удар пришелся по голове!\n");
                    Console.WriteLine($"Стражник оглушает вас на {1} ход");
                    player.HP -= Attack;
                    player.Pass = 1;
                    break;

            }
        }
    }
}
