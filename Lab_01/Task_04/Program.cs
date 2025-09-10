using System;

class Task04
{
    static void Main()
    {
        Console.WriteLine("The biggest from three values: ");
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
                default:
                    Console.WriteLine("Wrong choice");
                    break;
        }
    }
}