using System;
using System.Linq.Expressions;

class pTypes
{
    static void Main()
    {
        //Task 2.5 with Integer Numbers
        sbyte firstVal = -100;

        byte secondVal = 128;
        
        short thirdVal = -3540;
        
        ushort fourthVal = 64876;
        
        uint fifthVal = 2147483648;
        
        int  sixthVal = -1141583228;
        
        //Task 2.6 with Floating-point Numbers
        
        decimal seventhVal = 3.141592653589793238m;
        float eighthVal = 1.60217657f;
        decimal ninthVal = 7.8184261974584555216535342341m;
        
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Integer numbers");
        Console.WriteLine("2. Floating-point numbers");
        Console.WriteLine("Choose Task: ");
        Console.WriteLine("");
        
        int choice = int.Parse(Console.ReadLine());
        
        switch (choice)
        {
                case 1:
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}",firstVal,secondVal,thirdVal,fourthVal,fifthVal,sixthVal);
                    break;
                case 2:
                    Console.WriteLine("{0}, {1}, {2}", seventhVal, eighthVal, ninthVal);
                    break;
        }
    }
}
