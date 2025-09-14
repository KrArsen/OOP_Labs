using System;

class Task03
{
    static void Main()
    {
        string[] line = Console.ReadLine().Split(' ');
        int n = line.Length;
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = int.Parse(line[i]);
        }

        if (n % 4 != 0)
        {
            Console.WriteLine("Must be a multiple of 4");
            return;
        }
        int k = n / 4;
        int[] result = new int[2 * k];
        for (int i = 0; i < k; i++)
        {
            result[i] = a[k - 1 - i] + a[k + i];
            result[k + i] = a[n - 1- i] + a[k + k + i];

        }
        Console.WriteLine(string.Join(" ", result));
    }
}