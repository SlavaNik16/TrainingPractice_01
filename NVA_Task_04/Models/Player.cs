﻿namespace NVA_Task_04.Models
{
    public class Player
    {
        /// <summary>
        /// Имя игрока
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Базовая атака игрока
        /// </summary>
        public int Attack { get; set; }
        /// <summary>
        /// Сколько ходов будет повышена атака
        /// </summary>
        public int AttackStep { get; set; }
        /// <summary>
        /// Жизни игрока
        /// </summary>
        public int HP { get; set; }
        /// <summary>
        /// Максимальное кол-во жизней
        /// </summary>
        public int MaxXP { get; set; }
        /// <summary>
        ///  Сколько ходов будет лечится игрок
        /// </summary>
        public int HPStep { get; set; }
        /// <summary>
        ///  Мана игрока
        /// </summary>
        public int MP { get; set; }
        /// <summary>
        ///  Сколько ходов бедет оглушен
        ///  Если число положительное то оглугшен будет игрок
        ///  Если трицательное - противник
        /// </summary>
        public int Pass { get; set; }

        public Player(string name)
        {
            Name = name;
            Attack = new Random().Next(10,14);
            HP = new Random().Next(800, 1300);
            MaxXP = HP;
            HPStep = 0;
            MP = 0;
            Pass = 0;
        }

        public void Spells(string spell, Boss enemy)
        {
            switch (spell.ToUpper())
            {
                case "ATTACHI":
                    Console.WriteLine($"\nИгрок наносит БОССУ - {enemy.Name} урон в размере {Attack}");
                    enemy.HP -= Attack;
                    break;
                case "ATTACHI2":
                    if (MP >= 10)
                    {
                        Console.WriteLine($"\nИгрок наносит БОССУ - {enemy.Name} 2 удара в размере {Attack * 2}");
                        enemy.HP -= Attack * 2;
                        MP -= 10;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "ATTACHI3":
                    if (MP >= 40)
                    {
                        Console.WriteLine($"\nИгрок наносит БОССУ - {enemy.Name} три удара в размере {Attack * 3} и повышает свою Атаку на 2");
                        enemy.HP -= Attack * 3;
                        Attack += 2;
                        MP -= 40;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "ATTACHI4":
                    if (MP >= 150)
                    {
                        Console.WriteLine($"\nИгроки повышает свою атаку на 10 и наносит БОССУ - {enemy.Name} серьезный урон в размере {Attack * 10}");
                        Attack += 10;
                        enemy.HP -= Attack * 10;
                        MP -= 150;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "HELTHA":
                    if (MP >= 8)
                    {
                        var hp = new Random().Next(30, 50);
                        Console.WriteLine($"\nИгрок восстанавливает себе HP в размере {hp}");
                        HP += hp;
                        MP -= 8;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "HELTHA2":
                    if (MP >= 40)
                    {
                        var hp = new Random().Next(60, 100);
                        Console.WriteLine($"\nИгрок восстанавливает себе HP в размере {hp}. Атака повышена на 2");
                        Attack += 2;
                        HP += hp;
                        MP -= 40;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "HELTHA3":
                    if (MP >= 150)
                    {
                        Console.WriteLine($"\nИгрок полностью восстанавливает свое здоровье. Но атака понижается на 5");
                        Attack -= 5;
                        HP = MaxXP;
                        MP -= 150;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "STRATEGY":
                    if (MP >= 30)
                    {
                        Console.WriteLine($"\nИгрок наносит оглушающий удар в размере {Attack} и оглушает БОССА на 2 хода");
                        enemy.HP -= Attack;
                        Pass -= 2;
                        MP -= 30;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "STRATEGY2":
                    if (MP >= 80)
                    {
                        Console.WriteLine($"\nИгрок восстанавливает в течении 5 ходов себе 60 xp");
                        HPStep += 5;
                        MP -= 80;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "STRATEGY3":
                    if (MP >= 150)
                    {
                        if (AttackStep != 0)
                        {
                            Console.WriteLine("Магия не может складываться! Было потрачено половина маны от заклинания");
                            MP -= 75;
                            break;
                        }
                        Console.WriteLine($"\nИгрок повышает атаку на 100 в течении 5 ходов игрока");
                        AttackStep += 5;
                        Attack += 100;
                        MP -= 150;
                        break;
                    }
                    DisadvantageMP();
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
                case "ATTACHI2":
                    if (MP >= 10)
                    {
                        Console.WriteLine($"\nИгрок наносит Стражнику - {enemy.Name} 2 удара в размере {Attack*2}");
                        enemy.HP -= Attack*2;
                        MP -= 10;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "ATTACHI3":
                    if (MP >= 40)
                    {
                        Console.WriteLine($"\nИгрок наносит Стражнику - {enemy.Name} три удара в размере {Attack*3} и повышает свою Атаку на 2");
                        enemy.HP -= Attack*3;
                        Attack += 2;
                        MP -= 40;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "ATTACHI4":
                    if (MP >= 150)
                    {
                        Console.WriteLine($"\nИгроки повышает свою атаку на 10 и наносит Стражнику - {enemy.Name} серьезный урон в размере {Attack * 10}");
                        Attack += 10;
                        enemy.HP -= Attack * 10;
                        MP -= 150;
                        break;
                    }
                    DisadvantageMP();
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
                case "HELTHA2":
                    if (MP >= 40)
                    {
                        var hp = new Random().Next(60, 100);
                        Console.WriteLine($"\nИгрок восстанавливает себе HP в размере {hp}. Атака повышена на 2");
                        Attack += 2;
                        HP += hp;
                        MP -= 40;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "HELTHA3":
                    if (MP >= 150)
                    {
                        Console.WriteLine($"\nИгрок полностью восстанавливает свое здоровье. Но атака понижается на 5");
                        Attack -= 5;
                        HP = MaxXP;
                        MP -= 150;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "STRATEGY":
                    if (MP >= 30)
                    {
                        Console.WriteLine($"\nИгрок наносит оглушающий удар в размере {Attack} и оглушает Стражника на 2 хода");
                        enemy.HP -= Attack;
                        Pass -= 2;
                        MP -= 30;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "STRATEGY2":
                    if (MP >= 80)
                    {
                        Console.WriteLine($"\nИгрок восстанавливает в течении 5 ходов себе 60 xp");
                        HPStep += 5;
                        MP -= 80;
                        break;
                    }
                    DisadvantageMP();
                    break;
                case "STRATEGY3":
                    if (MP >= 150)
                    {
                        if(AttackStep != 0)
                        {
                            Console.WriteLine("Магия не может складываться! Было потрачено половина маны от заклинания");
                            MP -= 75;
                            break;
                        }
                        Console.WriteLine($"\nИгрок повышает атаку на 100 в течении 5 ходов игрока");
                        AttackStep += 5;
                        Attack += 100;
                        MP -= 150;
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
            text += "\nAttachi2(10 маны) - Атакующая магия среднего уровня: Игрок наносит два удара подряд от базового урона;";
            text += "\nAttachi3(40 маны) - Атакующая магия высокого уровня: Игрок наносит три удара подряд от базового урона и повышает атаку на 2;";
            text += "\nAttachi3(150 маны) - Атакующая магия высшего уровня: Игрок повышает свою атаку на 10 и наносит 10x урон по протикнику";
            text += "\nHeltha(8 маны) - Восстанавливающая магия простого уровня: Лечит игрока от 30 до 50 hp;";
            text += "\nHeltha2(40 маны) - Восстанавливающая магия среднего уровня: Лечит игрока от 60 до 100 hp, а также повышает базовую атаку на 2;";
            text += "\nHeltha3(150 маны) - Восстанавливающая магия высокого уровня: Игрок полностью восстанавливает свое здоровье, но базовая атака понижается на 5";
            text += "\nStrategy(30 маны) - Стратегическая магия простого уровня: Игрок наносит урон протикнику и оглушает его на 2 хода";
            text += "\nStrategy2(80 маны) - Стратегическая магия среднего уровня: Игрок восстанавливает в течении 5 ходов себе 60 xp";
            text += "\nStrategy3(150 маны) - Стратегическая магия высокого уровня: Игрок повышает атаку на 100 в течении 5 ходов. Не может складываться!!!";
         
            return text;
        }

        public void DisadvantageMP()
        {
            Console.WriteLine("Недостаток маны!");
        }
    }
}
