using System;

class Task07
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] parts = input.Split(' ');
        int [] arr = new int [parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            arr[i] = int.Parse(parts[i]);
        }

        int start = 0, len = 1;
        int bestStart = 0, bestLen = 1;

        for (int i = 1; i < parts.Length; i++)
        {
            if (arr[i] > arr[i - 1])
            {
                len++;
            } else
            {
                len = 1;
                start = i;
            }

            if (len > bestLen)
            {
                bestLen = len;
                bestStart = i - len + 1;
            }
        }
        for (int i = bestStart; i < bestStart + bestLen; i++)
            {
            Console.Write(arr[i] + " ");
            }
    }
}