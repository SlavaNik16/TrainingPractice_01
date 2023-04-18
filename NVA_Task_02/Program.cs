var text = "";
while(text != "exit")
{
    Console.WriteLine("Чтобы выйти из цикла введите слово exit");
    text = Console.ReadLine().ToLower();
}

Console.ReadKey(true);