using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Student(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
                break;

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstName = parts[0];
            string lastName = parts[1];

            students.Add(new Student(firstName, lastName));
        }
        
        var sortedStudents = from s in students
            orderby s.LastName ascending, s.FirstName descending
            select s;

        
        foreach (var s in sortedStudents)
        {
            Console.WriteLine($"{s.FirstName} {s.LastName}");
        }
    }
}