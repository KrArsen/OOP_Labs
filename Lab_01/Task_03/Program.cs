using System;

class Task03
{
    static void Main()
    {
        Console.WriteLine("1. Calculate average ");
        
        int choice = int.Parse(Console.ReadLine());
        switch (choice) {
            case 1:
            float average;
            Console.WriteLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            average = (a + b + c) / 3;
            Console.WriteLine(average);
            break;
        }
        
    }
}