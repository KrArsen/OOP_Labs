using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name} {Age}";
    }
}

class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int nameLengthCompare = x.Name.Length.CompareTo(y.Name.Length);
        if (nameLengthCompare != 0)
            return nameLengthCompare;

        return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
    }
}

class AgeComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.Age.CompareTo(y.Age);
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        SortedSet<Person> sortedByName = new SortedSet<Person>(new NameComparator());
        SortedSet<Person> sortedByAge = new SortedSet<Person>(new AgeComparator());

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = parts[0];
            int age = int.Parse(parts[1]);

            Person p = new Person(name, age);
            sortedByName.Add(p);
            sortedByAge.Add(p);
        }

        foreach (var p in sortedByName)
            Console.WriteLine(p);
        foreach (var p in sortedByAge)
            Console.WriteLine(p);
    }
}