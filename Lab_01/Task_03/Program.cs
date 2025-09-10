using System;

class Task03
{
    static void Main()
    {
        Console.WriteLine("1. Calculate average ");
        Console.WriteLine("2. Trapecium area ");
        Console.WriteLine("3. Last digit ");
        Console.WriteLine("4. Reversed value ");
        Console.WriteLine("5. Check if value > than 20 and odd ");
        Console.WriteLine("6. The entered number is divisible by the given constants 9, 11 ,13 without a remainder ");
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
            case 3:
                int lastDigit;
                Console.WriteLine("Enter number: ");
                int n = int.Parse(Console.ReadLine());
                lastDigit = n % 10;
                Console.WriteLine("Last Digit is " + lastDigit);
                break;
            case 4:
                int ndigit;
                Console.WriteLine("Enter number: ");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number of digit from right: ");
                int n1 = int.Parse(Console.ReadLine());

                ndigit = ((number / (int)Math.Pow(10, n1 - 1)) % 10);
                Console.WriteLine("Digit: " + ndigit);
                break;
            case 5:
                bool result;
                Console.WriteLine("Enter number: ");
                int n2 = int.Parse(Console.ReadLine());
                if (n2 > 20 && n2 % 2 == 1)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                Console.WriteLine("Result: " + result);
                break;
            case 6:
                bool result1;
                Console.WriteLine("Enter number: ");
                int n3 = int.Parse(Console.ReadLine());
                if (n3 % 9 == 0 || n3 % 11 == 0 ||  n3 % 13 == 0)
                {
                    result1 = true;
                }
                else
                {
                    result1 = false;
                }
                Console.WriteLine("Result: " + result1);
                break;
            case 7:
                
                break;
            default:
                Console.WriteLine("Wrong choice");
                break;
        }
    }
}