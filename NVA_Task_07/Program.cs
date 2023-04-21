int num;
restart:
while (true)
{
    Console.Write("Укажите кол-во элементов в массиве: ");
    if (int.TryParse(Console.ReadLine(), out num) && num > 2)
    {
        break;
    }
    Console.WriteLine("Кол-во элементов массива должно быть целое число и больше 2!");
}

int[] number = new int[num];
var rnd = new Random();
Console.WriteLine("Изначальный массив: ");
for (int i = 0; i < number.Length; i++)
{
    number[i] = rnd.Next(-20, 20);
    Console.Write($"{number[i]} ");
}
Console.WriteLine();
Console.WriteLine("Перемешанный массив: ");
Shuffle(number);
goto restart;

void Shuffle(int[] mas)
{
    int index = 0;
    int x;
    var rnd = new Random();
    while(index != num)
    {
        int position = rnd.Next(num);
        x = mas[index];
        mas[index] = mas[position];
        mas[position] = x; 
        index++;
    }
    for (int i = 0; i < number.Length; i++)
        Console.Write($"{number[i]} ");

    Console.WriteLine();
}
