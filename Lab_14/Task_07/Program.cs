using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split();
        
        Predicate<string> isValid = name => name.Length <= n;
        string[] filteredNames = names.Where(name => isValid(name)).ToArray();
        
        Console.WriteLine(string.Join(" ", filteredNames));
    }
}