using System;
using System.IO;
class MailSearch
{
    public void SearchMail(ref string s)
    {
        int index = s.IndexOf('#');
        if (index != -1)
        {
            s = s.Substring(index + 1).Trim();
        }
    }
}
class Program
{
    static void Main()
    {
        string fileName = "people.txt";
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }
        string[] lines = File.ReadAllLines(fileName);
        MailSearch search = new MailSearch();
        for (int i = 0; i < lines.Length; i++)
        {
            search.SearchMail(ref lines[i]);
        }
        File.WriteAllLines("emails.txt", lines);
        Console.WriteLine("Адреса электронной почты записаны в emails.txt");
    }
}