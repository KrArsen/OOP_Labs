using System;

class Task05
{
    static void Main()
    {
        Console.WriteLine("Enter number: ");
        int n =  int.Parse(Console.ReadLine());
        
        if (n < 0)
        {
            Console.WriteLine("Cannot be negative");
        }
        else
        {

            int factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }

        
            Console.WriteLine("Factorial: " + factorial);
        }
    }
}