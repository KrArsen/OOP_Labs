using System;

class Task03
{
    static void Main()
    {
        Console.WriteLine("1. Calculate average ");
        Console.WriteLine("2. Trapecium area ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                float average;
                Console.WriteLine("Enter a, b, c  to calculate average: ");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int c = int.Parse(Console.ReadLine());

                average = (a + b + c) / 3;
                Console.WriteLine(average);
                break;

            case 2:
                float area;
                Console.WriteLine("Enter a, b, h for Trapecium to calculate area: ");
                int a1 = int.Parse(Console.ReadLine());
                int b1 = int.Parse(Console.ReadLine());
                int h = int.Parse(Console.ReadLine());
                
                area = (a1 + b1)  * h / 2;
                Console.WriteLine(area);
                break;

        }
    }
}