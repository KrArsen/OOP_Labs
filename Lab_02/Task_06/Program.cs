using System;

class Task06
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int n = input.Length;
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(input[i]);
        }

        int start = 0, len = 1;
        int bestStart = 0, bestLen = 1;

        for (int i = 1; i < n; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                len++;
            }
            else
            {
                start = i;
                len = 1;
            }

            if (len > bestLen)
            {
                bestLen = len;
                bestStart = start;
            }
        }

        for (int i = bestStart; i < bestStart + bestLen; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
}