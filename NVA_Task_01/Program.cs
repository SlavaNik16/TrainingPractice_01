
var rnd = new Random();
Console.Write("Введите кол-во золота:");
int.TryParse(Console.ReadLine(), out int gold);


var countCrystal = rnd.Next(1, 10);
Console.WriteLine($"Вы готовы купить {countCrystal} шт. алмазов за: ");
var priceCrystal = Console.ReadLine();

Console.WriteLine($"Сделка завершена!\nЗолота: {gold}\nКристаллов: ${10}");


