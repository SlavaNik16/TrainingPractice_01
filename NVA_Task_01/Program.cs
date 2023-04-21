var rnd = new Random();
Console.Write("Введите кол-во золота:");
int gold;

while(!int.TryParse(Console.ReadLine(), out gold) || gold <= 0)
{
    Console.WriteLine("Неправильно введенные данные");
}

int priceCrystal = rnd.Next(50, 80);
int maxCount = gold / priceCrystal;
Console.Write($"Алмаз стоит {priceCrystal} золота.\n" +
    $"Сколько кристаллов вы хотите приобрести(максимум можно - {maxCount}): ");

int countCrystal;
while(!int.TryParse(Console.ReadLine(), out countCrystal) || countCrystal < 0)
{
    Console.WriteLine("Неправильно введенные данные");
}

while(countCrystal <= maxCount && countCrystal!=0)
{
    gold -= priceCrystal * countCrystal;
    Console.WriteLine($"Сделка успешно завершена!\nУ вас осталось:\nЗолота: {gold}\nКристаллов: {countCrystal}");
    Environment.Exit(0);  
}
Console.WriteLine($"Сделка закончилась неудачно!\nУ вас было:\nЗолота: {gold}\nКристаллов: {0}");

Console.ReadKey(true);