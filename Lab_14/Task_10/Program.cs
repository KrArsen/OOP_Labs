using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> guests = Console.ReadLine().Split().ToList();
        string command;
        
        while ((command = Console.ReadLine()) != "Party!")
        {
            var commandParts = command.Split();
            var action = commandParts[0];
            var conditionType = commandParts[1];
            var conditionValue = commandParts[2];

            if (action == "Remove")
            {
                Predicate<string> condition = GetCondition(conditionType, conditionValue);
                guests.RemoveAll(condition);
            }
            else if (action == "Double")
            {
                Predicate<string> condition = GetCondition(conditionType, conditionValue);
                var guestsToDouble = guests.Where(g => condition(g)).ToList();
                guests.AddRange(guestsToDouble);
            }
        }

        Console.WriteLine(guests.Any() ? string.Join(", ", guests) + " are going to the party!" : "Nobody is going to the party!");
    }

    static Predicate<string> GetCondition(string type, string value)
    {
        return type switch
        {
            "StartsWith" => name => name.StartsWith(value),
            "EndsWith" => name => name.EndsWith(value),
            "Length" => name => name.Length == int.Parse(value),
            _ => null
        };
    }
}