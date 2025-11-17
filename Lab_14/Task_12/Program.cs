using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> gems = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<string> exclusions = new List<string>();
        string command;
        
        while ((command = Console.ReadLine()) != "Forge")
        {
            var commandParts = command.Split(';');
            var action = commandParts[0];
            var filterType = commandParts[1];
            var filterParam = int.Parse(commandParts[2]);

            if (action == "Exclude")
                exclusions.Add($"{filterType}-{filterParam}");
            else if (action == "Reverse")
                exclusions.Remove($"{filterType}-{filterParam}");
        }

        foreach (var exclusion in exclusions)
        {
            var exclusionParts = exclusion.Split('-');
            var exclusionType = exclusionParts[0];
            var exclusionValue = int.Parse(exclusionParts[1]);

            if (exclusionType == "Sum Left")
                gems.RemoveAll(g => g + gems[gems.IndexOf(g) - 1] == exclusionValue);
            else if (exclusionType == "Sum Right")
                gems.RemoveAll(g => g + gems[gems.IndexOf(g) + 1] == exclusionValue);
            else if (exclusionType == "Sum Left Right")
                gems.RemoveAll(g => g + gems[gems.IndexOf(g) - 1] + gems[gems.IndexOf(g) + 1] == exclusionValue);
        }
        
        Console.WriteLine(string.Join(" ", gems));
    }
}