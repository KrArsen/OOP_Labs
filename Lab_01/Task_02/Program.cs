using System;
using System.Linq.Expressions;

class pTypes
{
    static void Main()
    {
        sbyte firstVal = -100;

        byte secondVal = 128;
        
        short thirdVal = -3540;
        
        ushort fourthVal = 64876;
        
        uint fifthVal = 2147483648;
        
        int  sixthVal = -1141583228;
        
        
        Console.WriteLine("Menu:");
        Console.WriteLine("1.Integer numbers");
        Console.WriteLine("2. Floating-point numbers");
        Console.WriteLine("Choose Task:");
        Console.WriteLine("");
        
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
                case 1:
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}",firstVal,secondVal,thirdVal,fourthVal,fifthVal,sixthVal);
                    break;
                
                    
        }
    }
}
