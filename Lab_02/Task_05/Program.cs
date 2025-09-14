using System;

class Task05
{
    static void Main()
    {
        string[] arr1 = Console.ReadLine().Split(' ');
        string[] arr2 = Console.ReadLine().Split(' ');
        
        string st1 = string.Join("", arr1);
        string st2 = string.Join("", arr2);
        
        int minLength = Math.Min(st1.Length, st2.Length);
        int result = 0;
        
        for (int i = 0; i < minLength; i++)
            {
                if (st1[i] < st2[i])
                {
                    result = -1;
                    break;
                }
                else if (st1[i] > st2[i])
                {
                    result = 1;
                    break;
                }
            }

        if (result == 0 && st1.Length != st2.Length)
        {
            result = st1.Length <  st2.Length ? -1 : 1;
        }

        if (result <= 0)
        {
            Console.WriteLine(st1);
            Console.WriteLine(st2);
        } else {
            Console.WriteLine(st2);
            Console.WriteLine(st1);
        }
    }
}