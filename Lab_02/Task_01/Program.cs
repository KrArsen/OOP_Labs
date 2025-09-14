using System;

class Task01
{
    static void Main()
    {
        string[] a1 = Console.ReadLine().Split(' ');
        string[] a2 = Console.ReadLine().Split(' ');
        
        int minLen = a1.Length <  a2.Length ? a1.Length : a2.Length;

        int leftCount = 0;
        for (int i = 0; i < minLen; i++)
        {
            if (a1[i] == a2[i])
            {
                leftCount++;
            }
            else
            {
                break;
            }
        }
        int rightCount = 0;
        for (int i = 0; i < minLen; i++)
        {
            if (a1[a1.Length - i - 1] == a2[a2.Length - i - 1])
            {
                rightCount++;
            }
            else
            {
                break;
            }
        }

        if (leftCount == 0 && rightCount == 0)
        {
            Console.WriteLine("No common words from left and right ");
        } else if (leftCount >= rightCount)
        {
            Console.WriteLine("The most common end is left");
            for (int i = 0; i < leftCount; i++)
            {
                Console.WriteLine(a1[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("The most common end is right");
            for (int i = a1.Length - rightCount; i < a1.Length; i++)
            {
                Console.WriteLine(a1[i] + " ");
            }
            Console.WriteLine();
        }
    }
}