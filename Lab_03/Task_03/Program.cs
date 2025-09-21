using System;

class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0)
            {
                age = value;
            }
            else
            {
                Console.WriteLine("Age can't be negative");
            }
        }
    }

    public Person() 
    {
        this.Name = "No name";
        this.Age = 1;
    }

    public Person(int age)
    {
        this.Name = "No name";
        this.Age = age;
    }
    
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public void print()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

class Family
{
    private Person[] members;
    private int memberCount;

    public Family(int size)
    {
        members = new Person[size];
        memberCount = 0;
    }

    public void addMember(Person member)
    {
        if (memberCount < members.Length)
        {
            members[memberCount] = member;
            memberCount++;
        }
    }

    public Person GetOldestMember()
    {
        Person oldestMember = members[0];
        for (int i = 1; i < memberCount; i++)
        {
            if (members[i].Age > oldestMember.Age)
                {
                oldestMember = members[i];
                }
        }
        return oldestMember;
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Write amount of people you want to add: ");
        int n = int.Parse(Console.ReadLine());
        Family family = new Family(n);
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            
            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            
            Person person = new Person(name, age);
            family.addMember(person);
        }
        
        Person oldestMember = family.GetOldestMember();
        Console.WriteLine($"Найстарший член родини: {oldestMember.Name} {oldestMember.Age}");
    }
}