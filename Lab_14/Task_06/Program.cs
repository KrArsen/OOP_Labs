using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();
        int n = int.Parse(Console.ReadLine());
        
        Func<int[], int, int[]> excludeDivisible = (nums, divisor) => nums.Where(x => x % divisor != 0).ToArray();
        
        numbers = excludeDivisible(numbers, n);
        Console.WriteLine(string.Join(" ", numbers));
    }
}