using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string FacultyNumber { get; set; }
    public List<int> Grades { get; set; }

    public Student(string facultyNumber, List<int> grades)
    {
        FacultyNumber = facultyNumber;
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
            string facultyNumber = parts[0];
            List<int> grades = parts.Skip(1).Select(int.Parse).ToList();

            students.Add(new Student(facultyNumber, grades));
        }
        
        var enrolled2014or2015 = from s in students
            where s.FacultyNumber.Length >= 6 &&
                  (s.FacultyNumber.Substring(4, 2) == "14" ||
                   s.FacultyNumber.Substring(4, 2) == "15")
            select s;
        
        foreach (var s in enrolled2014or2015)
        {
            Console.WriteLine(string.Join(" ", s.Grades));
        }
    }
}