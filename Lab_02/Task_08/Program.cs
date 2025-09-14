using System;

class Program
{
    static void Main()
    {
        string[] parts = Console.ReadLine().Split(' ');
        int n = parts.Length;
        int[] nums = new int[n];

        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(parts[i]);
            if (nums[i] < 0 || nums[i] > 65535)
            {
                Console.WriteLine("Must be [0 to 65535]");
                return;
            }
        }

        int[] freq = new int[65536];
        int maxCount = 0;
        int most = nums[0];

        for (int i = 0; i < n; i++)
        {
            int val = nums[i];
            freq[val]++;

            if (freq[val] > maxCount)
            {
                maxCount = freq[val];
                most = val;
            }
        }

        Console.WriteLine("Number " + most + " most frequence (" + maxCount + " times)");
    }
}