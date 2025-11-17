using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var range = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string condition = Console.ReadLine();
        
        Predicate<int> isOdd = n => n % 2 != 0;
        Predicate<int> isEven = n => n % 2 == 0;
        
        Func<int[], Predicate<int>, int[]> filterNumbers = (numbers, predicate) => numbers.Where(n => predicate(n)).ToArray();
        
        int[] filteredNumbers = range[0] <= range[1]
            ? filterNumbers(Enumerable.Range(range[0], range[1] - range[0] + 1).ToArray(), condition == "odd" ? isOdd : isEven)
            : new int[0];
        
        Console.WriteLine(string.Join(" ", filteredNumbers));
    }
}