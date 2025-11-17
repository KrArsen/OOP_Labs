using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] divisors = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Func<int, int[], bool> isDivisible = (num, divs) => divs.All(d => num % d == 0);
        
        var numbers = Enumerable.Range(1, n).Where(num => isDivisible(num, divisors)).ToArray();
        Console.WriteLine(string.Join(" ", numbers));
    }
}