string[] fio = new string[30];
string[] post = new string[30];
var number = 0;
restart:
Console.WriteLine("Отдел кадров");
Console.WriteLine("1 - Добавить досье");
Console.WriteLine("2 - Вывести все досье");
Console.WriteLine("3 - Удалить досье");
Console.WriteLine("4 - Поиск по фамилии");
Console.WriteLine("5 - Выход\n");
Console.WriteLine("Выберите пункт меню:");
if (!int.TryParse(Console.ReadLine(),out number) && number <1 && number >5)
{
    Console.WriteLine("Вы ввели неправильное значение!");
    Restart();
    goto restart; 
}
switch (number)
{
    case 1:
        AddDossier();
        goto restart;
        break;
}

fio[0] = "Николаев Вячеслав Алексеевич";
post[0] = "Ген. директор";

string[] str = fio[0].Split(" ");
Console.WriteLine(str[0]);

if (number == 5) Environment.Exit(0);
Restart();


void AddDossier()
{

}
void Restart()
{
    Console.WriteLine("Нажмите любую клавишу...");
    Console.ReadKey(true);
    Console.Clear();
}