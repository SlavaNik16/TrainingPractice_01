
using System.Runtime.CompilerServices;

var rnd = new Random();
Console.Write("Введите кол-во золота:");
int gold = 0;

while(!int.TryParse(Console.ReadLine(), out gold) || gold <= 0)
{
    Console.WriteLine("Неправильно введенные данные");
}

var countCrystal = rnd.Next(1, 10);
Console.Write($"Вы готовы купить {countCrystal} шт. алмазов за: ");
int priceCrystal = 0;

while(!int.TryParse(Console.ReadLine(), out priceCrystal) || priceCrystal <= 0)
{
    Console.WriteLine("Неправильно введенные данные");
}

while(gold - priceCrystal > 0)
{
    gold-= priceCrystal;
    Console.WriteLine($"Сделка успешно завершена!\nУ вас осталось:\nЗолота: {gold}\nКристаллов: ${countCrystal}");
    Environment.Exit(0);
}

Console.WriteLine($"Сделка завершена неудачно!\nУ было \nЗолота: {gold}\nКристаллов: ${countCrystal}");





Console.ReadKey(true);