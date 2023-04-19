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
        public int Pass { get; set; }

        public Player(string name)
        {
            Name = name;
            Attack = new Random().Next(10,14);
            HP = new Random().Next(800, 1300);
            MP = 0;
            Pass = 0;
        }

        public void Spells(string spell, Boss enemy)
        {
            switch (spell.ToUpper())
            {
                case "ATTACHI":
                    Console.WriteLine($"Игрок наносит монстру урон в размере {Attack}");
                    enemy.HP -= Attack;
                    break;
                default:
                    Console.WriteLine("Неправильно произнесено заклинание!");
                    break;
            }
        }

        public void Spells(string spell, Guardians enemy)
        {
            switch (spell.ToUpper())
            {
                case "ATTACHI":
                    Console.WriteLine($"\nИгрок наносит Стражнику - {enemy.Name} урон в размере {Attack}");
                    enemy.HP -= Attack;
                    break;
                case "HELTHA" :
                    if (MP >= 8) {
                        var hp = new Random().Next(30, 50);
                        Console.WriteLine($"\nИгрок восстанавливает себе HP в размере {hp}");
                        HP += hp;
                        MP -= 8;
                        break;
                    }
                    DisadvantageMP();
                    break; 
                default:
                    Console.WriteLine("Неправильно произнесено заклинание!");
                    break;
            }
        }

        public string getSpells()
        {
            var text = "\nAttachi - Простая атака, содержит базовый урон. Не требует маны;";
            text += "\nHELTHA - Магия простого уровня лечит игрока от 30 до 50 hp и тратит ману в размере 8 mp;";
            return text;
        }

        public void DisadvantageMP()
        {
            Console.WriteLine("Недостаток маны!");
        }
    }
}
