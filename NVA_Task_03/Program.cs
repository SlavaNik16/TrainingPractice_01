string password = "123";
var count = 3;
while (count != 0)
{
    Console.Write("Ваш пароль: ");
    var textUser = Console.ReadLine();
    if(password == textUser)
    {
        Console.WriteLine("Вы угадали секретный пароь");
        break;;
    }
    count--;
    Console.WriteLine($"Неверно! (Доступно eще {count} раз(-a))");
}
Console.ReadKey(true);
