using System;

class Task04
{
    static void Main()
    {
        Console.WriteLine("1. The biggest from three values ");
        Console.WriteLine("2. Find positive or negative from three values ");
        Console.WriteLine("3. Show day from 1-7 ");
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
            case 3:
                Console.WriteLine("Enter day from 1-7: ");
                int day = int.Parse(Console.ReadLine());
                switch (day)
                {
                    case 1:
                        Console.WriteLine("Monday");
                        break;
                    case 2:
                        Console.WriteLine("Tuesday");
                        break;
                    case 3:
                        Console.WriteLine("Wednesday");
                        break;
                    case 4:
                        Console.WriteLine("Thursday");
                        break;
                    case 5:
                        Console.WriteLine("Friday");
                        break;
                    case 6:
                        Console.WriteLine("Saturday");
                        break;
                    case 7:
                        Console.WriteLine("Sunday");
                        break;
                    default:
                        Console.WriteLine("Invalid day");
                        break;
                }

                break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;
        }
    }
}