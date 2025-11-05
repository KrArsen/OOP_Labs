using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }

    public Student(string firstName, string lastName, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
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
            string phone = parts[2];

            students.Add(new Student(firstName, lastName, phone));
        }
        
        var sofiaPhones = from s in students
            where s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592")
            select s;
        
        foreach (var s in sofiaPhones)
        {
            Console.WriteLine($"{s.FirstName} {s.LastName}");
        }
    }
}