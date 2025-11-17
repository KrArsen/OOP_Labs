using System;

class Program
{
    static void Main()
    {
        string[] names = Console.ReadLine().Split();
        Action<string> addSir = name => Console.WriteLine("Sir " + name);

        foreach (var name in names)
        {
            addSir(name);
        }
    }
}