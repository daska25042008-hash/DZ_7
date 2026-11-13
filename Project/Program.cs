using System;
class Program
{
    static void Check(object value)
    {
        if (value is IFormattable)
        {
            Console.WriteLine("Объект реализует интерфейс IFormattable.");
        }
        else
        {
            Console.WriteLine("Объект не реализует интерфейс IFormattable.");
        }
        IFormattable? formatted = value as IFormattable;
        if (formatted != null)
        {
            Console.WriteLine("Преобразование через as успешно.");
        }
        else
        {
            Console.WriteLine("Преобразование через as не удалось.");
        }
    }
    static void Main()
    {
        Console.WriteLine("Введите значение:");
        string text = Console.ReadLine() ?? "";
        if (int.TryParse(text, out int number))
        {
            Check(number);
        }
        else if (double.TryParse(text, out double decimalNumber))
        {
            Check(decimalNumber);
        }
        else if (bool.TryParse(text, out bool boolValue))
        {
            Check(boolValue);
        }
        else
        {
            Check(text);
        }
    }
}