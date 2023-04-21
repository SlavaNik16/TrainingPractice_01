
using NVA_Task_04.Models;
class Game {

    private static int step =0;
    private static int mpRecoveryPlayer = 3;
    private static float mpRecoveryBoss = 1.5f;
    static void Main(string[] arg)
    {
        Console.WriteLine("Игра - Победи БОССА");
        Console.WriteLine("Правила:\nУ вас есть 4 подземелья.\nВ трех из них находитятся стражи, а в одном Босс");
        Console.WriteLine("Цель игры победить Босса используя заклинания, который тратяться за ману");
        Console.WriteLine("Мана - ваша духовная энергия, по умолчанию она восстанавливается 3 м/c");
        Console.WriteLine("Заклинания могут быть:\n" +
            "  1)Атакующими - наносят урон врагу\n" +
            "  2)Востанавливающими - востанавливают хп или ману\n" +
            "  3)Стратегические - заклинания различных типов");
        Console.WriteLine("Условия игры:\n" +
            "  Уровень жизни у БОССА - (900-1500)\n" +
            "  Уровень жизни у стражей - (500-700)\n" +
            "  Уровень жизни у игрока - (800-1300)\n" +
            "Приятной вам игры! Пусть удача благовалит вам путник!\n\n\n");

        var boss = new Boss("Димон");
        var player = new Player("Джек");
        var guard1 = new Guardians("Вася");
        var guard2 = new Guardians("Петя");
        var guard3 = new Guardians("Кирилл");

        var textDungeon = new List<String>();
        textDungeon.Add("1) Подземелье Гордости;");
        textDungeon.Add("2) Подземелье Предательства");
        textDungeon.Add("3) Подземелье Жадности");
        textDungeon.Add("4) Подземелье Похоти");

        var enemy = new List<object>() { guard1, guard2, boss, guard3 };

        while (true)
        {
            foreach (var text in textDungeon)
                Console.WriteLine($"  {text}");
            Console.Write($"Введите подземелье, в которое вы хотите войти: ");
            if (int.TryParse(Console.ReadLine(), out int number) && (number > 0 && number < 5))
            {
                if (textDungeon[number - 1] != $"{number}) Убежать...")
                {
                    textDungeon[number - 1] = $"{number}) Убежать...";
                    var opponent = enemy[new Random().Next(0, 4)];
                    if (opponent is Boss)
                    {
                        Player_VS_Boss(player, (Boss)opponent);
                    }
                    else
                    {
                        Player_VS_Guard(player, (Guardians)opponent);
                    }
                }
                else
                {
                    Run();
                }

            }
            else
            {
                Console.WriteLine("Видимо ты не хочешь играть! Приходи когда будет желание!!!");
                Environment.Exit(0);
            }
        }
    }
    static void Player_VS_Boss(Player player, Boss opponent)
    {
        while (opponent.HP > 0)
        {
            step += 1;
            Console.WriteLine($"\nНачался {step} день битвы: ");
            player.MP += mpRecoveryPlayer;
            opponent.MP += mpRecoveryBoss + opponent.MPRecovery;
            if (player.Pass <= 0)
            {
                AttackStep(player);
                ShowCharacterWithBoss(player, opponent); 
                Console.WriteLine($"Прочитайте заклинание: {player.getSpells()}");
                Console.Write("Заклинание: ");
                Console.ForegroundColor = ConsoleColor.Green;
                var spell = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                player.Spells(spell, opponent);
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nИгрок пропускает день.");

                player.Pass -= 1;
            }
            HPStep(player);

            if (player.Pass >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                opponent.Spell(player);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nБОСС пропускает день. ");
                Console.ForegroundColor = ConsoleColor.White;
                player.Pass += 1;
            }
            if (player.HP <= 0)
            {
                if (opponent.HP <= 0)
                {
                    Console.WriteLine("На последнем взохе он делает свой последний удар");
                    Console.WriteLine("И к вашему сожалению удар пришелся по сердцу!");
                }
                End();
            }
        }
        Win();
    }
    static void Player_VS_Guard(Player player, Guardians opponent)
    {
        while (opponent.HP > 0)
        {   
            step += 1;
            Console.WriteLine($"\nНачался {step} день битвы: ");
            player.MP += mpRecoveryPlayer;
            if (player.Pass <= 0)
            {
                AttackStep(player);
                ShowCharacterWithGuart(player, opponent);
                Console.WriteLine($"Прочитайте заклинание: {player.getSpells()}");
                Console.Write("Заклинание: ");
                Console.ForegroundColor = ConsoleColor.Green;
                var spell = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                player.Spells(spell, opponent);
                Console.ForegroundColor = ConsoleColor.White;           
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nИгрок пропускает день.");
               
                player.Pass -= 1;
            }
            HPStep(player);

            if (player.Pass >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                opponent.Spell(player);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nСтражник пропускает день. "); 
                Console.ForegroundColor = ConsoleColor.White;
                player.Pass += 1;
            }
            if (player.HP <= 0)
            {
                if (opponent.HP <= 0)
                {
                    Console.WriteLine("На последнем взохе он делает свой последний удар");
                    Console.WriteLine("И к вашему сожалению удар пришелся по сердцу!");
                }
                End();
            }

        }
    }
    static void Run()
    {
        Console.WriteLine("Вы убежали!!! Вы не проиграли, но и не выиграли!\n" +
            "Попытайтесь воспользоваться своим опытом для следующего вашего сражения\n" +
            "в опаснейшем подземелье!");
        Environment.Exit(0);
    }
    static void End(){
        Console.WriteLine($"\t\tВы проиграли!\n\t\tВас убили!!! Всего вы прожили {step} дн(-я,-ей) битвы");
        Environment.Exit(0);
    }

    static void Win()
    {
        Console.WriteLine($"Поздравляю вы победили сильнейшего БОССА за {step} дней!\n" +
            $"Но можно сделать результат выше и пройти за меньшее кол-во дней!\n" +
            $"Ваши достижения буду записаны в истории!\nДо скорой встречи!");
        Environment.Exit(0);
    }



    static void ShowCharacterWithBoss(Player player,  Boss opponent)
    {
        Console.WriteLine($"\n\tИгрок - {player.Name}" + $"\t\t\tБОСС - {opponent.Name}\n" +
          $"\tЗдоровье - {player.HP}" + $"\t\t\tЗдоровье - {opponent.HP}\n" +
          $"\tАтака - {player.Attack}" + $"\t\t\tАтака - {opponent.Attack}\n" +
          $"\tМана - {player.MP}" + $"\t\t\tМана - {String.Format("{0:0.0}",opponent.MP)}\n");
    }
    static void ShowCharacterWithGuart(Player player, Guardians opponent)
    {
        Console.WriteLine($"\n\tИгрок - {player.Name}" + $"\t\t\tСтражник - {opponent.Name}\n" +
          $"\tЗдоровье - {player.HP}" + $"\t\t\tЗдоровье - {opponent.HP}\n" +
          $"\tАтака - {player.Attack}" + $"\t\t\tАтака - {opponent.Attack}\n" +
          $"\tМана - {player.MP}\n");
    }

    static void AttackStep(Player player)
    {
        if (player.AttackStep > 0)
        {
            player.AttackStep -= 1;
            if (player.AttackStep == 0)
            {
                Console.WriteLine("Атака игрока понижена на 100. Действие магии прекратилось");
                player.Attack -= 100;
            }
        }
    }
    static void HPStep(Player player)
    {
        if (player.HPStep != 0)
        {
            Console.WriteLine($"Игрок восстановил себе 60 xp осталось {player.HPStep - 1} ходов");
            player.HPStep -= 1;
            player.HP += 60;
        }
    }
}
