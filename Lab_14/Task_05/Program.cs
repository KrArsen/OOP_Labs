using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "end") break;

            switch (command)
            {
                case "add":
                    numbers = numbers.Select(n => n + 1).ToArray();
                    break;
                case "multiply":
                    numbers = numbers.Select(n => n * 2).ToArray();
                    break;
                case "subtract":
                    numbers = numbers.Select(n => n - 1).ToArray();
                    break;
                case "print":
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
            }
        }
    }
}