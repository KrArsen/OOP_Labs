using System;

class Task04
{
    static void Main()
    {
        Console.WriteLine("The biggest from three values: ");
        Console.WriteLine("Find positive or negative from three values: ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter a: ");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter b: ");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter c: ");
                int c = int.Parse(Console.ReadLine());
                int max;
                if (a > b && a > c)
                {
                    max = a;
                } else if (b > a && b > c)
                {
                    max = b;
                }
                else
                {
                    max = c;
                }
                Console.WriteLine("Max number is " + max);
                break;
            case 2:
                Console.WriteLine("Enter a: ");
                double a1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter b: ");
                double b1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter c: ");
                double c1 = double.Parse(Console.ReadLine());
                int negative = 0;
                if (a1 < 0)
                {
                    negative++;
                }

                if (b1 < 0)
                {
                    negative++;
                }

                if (c1 < 0)
                {
                    negative++;
                }

                if (negative % 2 == 0)
                {
                    Console.WriteLine("Positive");
                }
                else
                {
                    Console.WriteLine("Negative");
                }
                break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;
        }
    }
}