using System;

interface IIdentifiable
{
    string Id { get; }
}

interface IBirthable
{
    string Birthday { get; }
}

interface IBuyer
{
    int Food { get; set; }
    int BuyFood();
}


public class Citizen : IIdentifiable, IBirthable, IBuyer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Birthday { get; set; }
    public string Id { get; set; }
    public int Food { get; set; }

    public Citizen(string name, int age, string id, string birthday)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthday = birthday;
        Food = 0;
    }

    public int BuyFood()
    {
        Food += 10;
        return 10;
    }
}

public class Pet : IBirthable
{
    public string Name { get; set; }
    public string Birthday { get; set; }

    public Pet(string name, string birthday)
    {
        Name = name;
        Birthday = birthday;
    }
}


public class Rebel : IBuyer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Group { get; set; }
    public int Food { get; set; }

    public Rebel(string name, int age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
        Food = 0;
    }

    public int BuyFood()
    {
        Food += 5;
        return 5;
    }
}


public class Robot : IIdentifiable
{
    public string Model { get; set; }
    public string Id { get; set; }

    public Robot(string id, string model)
    {
        Id = id;
        Model = model;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Find fake IDs (Part 1)");
        Console.WriteLine("2. Find birthdates by year (Part 2)");
        Console.WriteLine("3. Food buying system (Part 3)");
        if (int.TryParse(Console.ReadLine(), out int part))
        {
            switch (part)
            {
                case 1:
                    RunPart1();
                    break;
                case 2:
                    RunPart2();
                    break;
                case 3:
                    RunPart3();
                    break;
                default:
                    Console.WriteLine("Incorrect number (option)!.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Error!.");
        }
    }

    
    static void RunPart1()
    {
        string[] ids = new string[100];
        int count = 0;
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] parts = input.Split(' ');
            ids[count++] = parts[^1];
        }

        string suffix = Console.ReadLine();
        for (int i = 0; i < count; i++)
        {
            if (ids[i].EndsWith(suffix))
            {
                Console.WriteLine(ids[i]);
            }
        }
    }

    
    static void RunPart2()
    {
        IBirthable[] birthables = new IBirthable[100];
        int count = 0;
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] parts = input.Split(' ');
            if (parts[0] == "Citizen")
            {
                string name = parts[1];
                int age = int.Parse(parts[2]);
                string id = parts[3];
                string birthday = parts[4];
                birthables[count++] = new Citizen(name, age, id, birthday);
            }
            else if (parts[0] == "Pet")
            {
                string name = parts[1];
                string birthday = parts[2];
                birthables[count++] = new Pet(name, birthday);
            }
        }

        string year = Console.ReadLine();
        for (int i = 0; i < count; i++)
        {
            if (birthables[i].Birthday.EndsWith(year))
            {
                Console.WriteLine(birthables[i].Birthday);
            }
        }
    }

    
    static void RunPart3()
    {
        int n = int.Parse(Console.ReadLine());
        string[] names = new string[n];
        IBuyer[] buyers = new IBuyer[n];
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ');

            if (parts.Length == 4)
            {
                string name = parts[0];
                int age = int.Parse(parts[1]);
                string id = parts[2];
                string birthday = parts[3];
                buyers[count] = new Citizen(name, age, id, birthday);
                names[count++] = name;
            }
            else if (parts.Length == 3)
            {
                string name = parts[0];
                int age = int.Parse(parts[1]);
                string group = parts[2];
                buyers[count] = new Rebel(name, age, group);
                names[count++] = name;
            }
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            for (int i = 0; i < count; i++)
            {
                if (names[i] == input)
                {
                    buyers[i].BuyFood();
                }
            }
        }

        int totalFood = 0;
        for (int i = 0; i < count; i++)
        {
            totalFood += buyers[i].Food;
        }

        Console.WriteLine(totalFood);
    }
}
