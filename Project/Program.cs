using System;
using System.IO;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите имя файла:");
        string fileName = Console.ReadLine() ?? "";
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Такого файла не существует.");
            return;
        }
        string text = File.ReadAllText(fileName);
        string upperText = text.ToUpper();
        File.WriteAllText("cat_love.txt", upperText);
        Console.WriteLine("Результат записан в файл cat_love.txt");
    }
}