using System;

interface ICallable
{
    void Call(string number);
}

interface IBrowsable
{
    void Browse(string site); 
}

class Smartphone : ICallable, IBrowsable
{
    public void Call(string number)
    {
        
        foreach (char c in number)
        {
            if (!char.IsDigit(c))
            {
                Console.WriteLine("Invalid number!");
                return;
            }
        }

        Console.WriteLine($"Calling... {number}");
    }

    public void Browse(string site)
    {
        
        foreach (char c in site)
        {
            if (char.IsDigit(c))
            {
                Console.WriteLine("Invalid URL!");
                return;
            }
        }

        Console.WriteLine($"Browsing: {site}!");
    }
}

class Program
{
    static void Main()
    {
        
        string[] numbers = Console.ReadLine().Split(' ');
        string[] sites = Console.ReadLine().Split(' ');;

        Smartphone phone = new Smartphone();
        
        foreach (string number in numbers)
        {
            phone.Call(number);
        }
        
        foreach (string site in sites)
        {
            phone.Browse(site);
        }
    }
}