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

class Program
{
    static void Main()
    {
        Person person1 = new Person("Pesho", 20);
        Person person2 = new Person("Gosho", 18);
        Person person3 = new Person("Stamat", 43);
        
        person1.print();
        person2.print();
        person3.print();
    }
}