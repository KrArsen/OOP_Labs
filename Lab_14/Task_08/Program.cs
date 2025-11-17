using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        
        Array.Sort(numbers, (x, y) =>
        {
            if (x % 2 == 0 && y % 2 != 0) return -1;
            if (x % 2 != 0 && y % 2 == 0) return 1;
            return x.CompareTo(y);
        });
        
        Console.WriteLine(string.Join(" ", numbers));
    }
}