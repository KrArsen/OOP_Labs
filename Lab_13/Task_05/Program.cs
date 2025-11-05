using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public Student(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
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
            string email = parts[2];

            students.Add(new Student(firstName, lastName, email));
        }

        var gmailStudents = from s in students
            where s.Email.EndsWith("@gmail.com")
            select s;
        
        foreach (var s in gmailStudents)
        {
            Console.WriteLine($"{s.FirstName} {s.LastName}");
        }
    }
}