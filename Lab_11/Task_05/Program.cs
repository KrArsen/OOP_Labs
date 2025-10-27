using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ClassInfoAttribute : Attribute
{
    public string Author { get; private set; }
    public int Revision { get; private set; }
    public string Description { get; private set; }
    public string[] Reviewers { get; private set; }

    public ClassInfoAttribute(string author, int revision, string description, params string[] reviewers)
    {
        Author = author;
        Revision = revision;
        Description = description;
        Reviewers = reviewers;
    }
}

[ClassInfo("Pesho", 3, 
    "Used for C#.", 
    "Petro", "Stepan")]
public class Weapon
{
    public string Name { get; private set; }

    public Weapon(string name)
    {
        Name = name;
    }
}

public class Program
{
    public static void Main()
    {
        Type type = typeof(Weapon);
        object[] attributes = type.GetCustomAttributes(false);

        ClassInfoAttribute info = null;
        for (int i = 0; i < attributes.Length; i++)
        {
            if (attributes[i] is ClassInfoAttribute)
            {
                info = (ClassInfoAttribute)attributes[i];
                break;
            }
        }

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            switch (input)
            {
                case "Author":
                    Console.WriteLine($"Author: {info.Author}");
                    break;
                case "Revision":
                    Console.WriteLine($"Revision: {info.Revision}");
                    break;
                case "Description":
                    Console.WriteLine($"Class description: {info.Description}");
                    break;
                case "Reviewers":
                    Console.Write("Reviewers: ");
                    for (int i = 0; i < info.Reviewers.Length; i++)
                    {
                        Console.Write(info.Reviewers[i]);
                        if (i < info.Reviewers.Length - 1) Console.Write(", ");
                    }
                    Console.WriteLine();
                    break;
            }
        }
    }
}
