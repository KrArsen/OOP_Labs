using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<int> Grades { get; set; }

    public Student(string firstName, string lastName, List<int> grades)
    {
        FirstName = firstName;
        LastName = lastName;
        Grades = grades;
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

            List<int> grades = parts.Skip(2).Select(int.Parse).ToList();

            students.Add(new Student(firstName, lastName, grades));
        }
        
        var weakStudents = from s in students
            where s.Grades.Count(g => g <= 3) >= 2
            select s;
        
        foreach (var s in weakStudents)
        {
            Console.WriteLine($"{s.FirstName} {s.LastName}");
        }
    }
}