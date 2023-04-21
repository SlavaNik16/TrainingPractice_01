using System;
using System.Xml.Xsl;

string[] fio = new string[30];
string[] post = new string[30];
int number;
int i = 0;
restart:
Console.WriteLine("Отдел кадров");
Console.WriteLine("1 - Добавить досье");
Console.WriteLine("2 - Вывести все досье");
Console.WriteLine("3 - Удалить досье");
Console.WriteLine("4 - Поиск по фамилии");
Console.WriteLine("5 - Выход\n");
Console.Write("Выберите пункт меню:");
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
        break;
    case 2:
        ShowDossier();
        break;
    case 3:
        DeleteDossier();
        break;
    case 4:
        SearchSurname();
        break;
    case 5:
        Environment.Exit(0);
        break;
}

Restart();
goto restart;


void AddDossier()
{
    Console.Write("Введите свое ФИО через пробел: ");
    fio[i] = Console.ReadLine(); 
    if (fio[i].Length == 0)
    {
        Console.Write("Досье заполнено неверно!");
        return;
    }
    Console.Write("Введите свою должность: ");
    post[i] = Console.ReadLine();
    i++;
}

bool ShowDossier()
{
    if (fio[0] != null) {
        for (var j = 0; j < fio.Length; j++)
        {
            Console.WriteLine($"{j+1}) {fio[j].Trim()} - {post[j].Trim()}");
            if (fio[j + 1] == null)return true;
            
        }
        return true;
    }
    Console.WriteLine("Отсутствуют какие-либо досье!");
    return false;
}

void DeleteDossier()
{
    if (ShowDossier())
    {
        int num;
        Console.WriteLine("Введите номер досье которого вы хотите удалить: ");
        try
        {
            if (!int.TryParse(Console.ReadLine(), out num) || fio[num - 1] == null)
            {
                Console.WriteLine("Такого номера досье не существует!");
                return;
            }
        }catch(IndexOutOfRangeException ex)
        {
            Console.WriteLine("Такого номера досье не существует!");
            return;
        }

        fio = fio.Where((source, index) => index != num - 1).ToArray();
        post = post.Where((source, index) => index != num - 1).ToArray();
        i--;

        Console.WriteLine("Досье успешно удалено!");
        


    }

}
void SearchSurname()
{
    Console.Write("Введите фамилию, которую вы хотите найти: ");
    var textSurname = Console.ReadLine();
    string[] surname = new string[30];
    for (var j = 0; j < fio.Length; j++)
    {
        if (fio[j] == null)break;
        surname = fio[j].Split(" ");
        if (surname[0].Trim() == textSurname.Trim())
        {
            Console.WriteLine($"{j + 1}) {fio[j].Trim()} - {post[j].Trim()}");
        }
    }

}

void Restart()
{
    Console.WriteLine("Нажмите любую клавишу...");
    Console.ReadKey(true);
    Console.Clear();
}