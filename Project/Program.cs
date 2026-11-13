using System;
enum AccountType
{
    Current = 1,
    Savings = 2
}
class Account
{
    private static int count = 0;
    private int num;
    private double money;
    private AccountType type;
    private static int NextNum()
    {
        count++;
        return count;
    }
    public Account()
    {
        num = NextNum();
    }
    public void Fill(double m, AccountType t)
    {
        money = m;
        type = t;
    }
    public void Put(double sum)
    {
        money = money + sum;
    }
    public bool Take(double sum)
    {
        if (sum > 0 && money >= sum)
        {
            money = money - sum;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Transfer(Account from, double sum)
    {
        if (from.Take(sum))
        {
            Put(sum);
            return true;
        }
        else
        {
            return false;
        }
    }
    public int GetNum()
    {
        return num;
    }
    public double GetMoney()
    {
        return money;
    }
    public AccountType GetTypeAccount()
    {
        return type;
    }
}
class Program
{
    static void Main()
    {
        Account a = new Account();
        Account b = new Account();
        a.Fill(5000, AccountType.Savings);
        b.Fill(3000, AccountType.Current);
        bool result = b.Transfer(a, 2000);
        Console.WriteLine("Счет a: " + a.GetMoney());
        Console.WriteLine("Счет b: " + b.GetMoney());
        Console.WriteLine("Перевод успешен: " + result);
    }
}

