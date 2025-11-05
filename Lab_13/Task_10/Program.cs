using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string Name { get; set; }
    public int Group { get; set; }

    public Person(string name, int group)
    {
        Name = name;
        Group = group;
    }
}

class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();
        
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
                break;

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = parts[0] + " " + parts[1];
            int group = int.Parse(parts[2]);

            people.Add(new Person(name, group));
        }
        
        var grouped = from p in people
            group p by p.Group into g
            orderby g.Key
            select g;
        
        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Key} - {string.Join(", ", group.Select(p => p.Name))}");
        }
    }
}