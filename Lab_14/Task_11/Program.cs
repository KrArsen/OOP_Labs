using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> invitations = Console.ReadLine().Split().ToList();
        List<string> filters = new List<string>();
        
        string command;
        while ((command = Console.ReadLine()) != "Print")
        {
            var commandParts = command.Split(';');
            var action = commandParts[0];
            var filterType = commandParts[1];
            var filterParam = commandParts[2];

            if (action == "Add filter")
                filters.Add($"{filterType}-{filterParam}");
            else if (action == "Remove filter")
                filters.Remove($"{filterType}-{filterParam}");
        }
        
        foreach (var filter in filters)
        {
            var filterParts = filter.Split('-');
            var filterType = filterParts[0];
            var filterParam = filterParts[1];

            if (filterType == "Starts with")
                invitations = invitations.Where(i => !i.StartsWith(filterParam)).ToList();
            else if (filterType == "Ends with")
                invitations = invitations.Where(i => !i.EndsWith(filterParam)).ToList();
            else if (filterType == "Length")
                invitations = invitations.Where(i => i.Length != int.Parse(filterParam)).ToList();
            else if (filterType == "Contains")
                invitations = invitations.Where(i => !i.Contains(filterParam)).ToList();
        }

        Console.WriteLine(string.Join(" ", invitations));
    }
}