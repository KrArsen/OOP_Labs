using System;

class Person : IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Town { get; set; }

    public Person(string name, int age, string town)
    {
        Name = name;
        Age = age;
        Town = town;
    }

    public int CompareTo(Person other)
    {
        if (other == null) return 1;

        int nameComparison = this.Name.CompareTo(other.Name);
        if (nameComparison != 0) return nameComparison;

        int ageComparison = this.Age.CompareTo(other.Age);
        if (ageComparison != 0) return ageComparison;

        return this.Town.CompareTo(other.Town);
    }
}

class Program
{
    static void Main()
    {
        Person[] people = new Person[100];
        int count = 0;
        
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END") break;

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = parts[0];
            int age = int.Parse(parts[1]);
            string town = parts[2];

            people[count++] = new Person(name, age, town);
        }

        int index = int.Parse(Console.ReadLine()) - 1;
        Person personToCompare = people[index];

        int equalCount = 0;
        int notEqualCount = 0;

        for (int i = 0; i < count; i++)
        {
            if (people[i].CompareTo(personToCompare) == 0)
                equalCount++;
            else
                notEqualCount++;
        }

        if (equalCount == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalCount} {notEqualCount} {count}");
        }
    }
}