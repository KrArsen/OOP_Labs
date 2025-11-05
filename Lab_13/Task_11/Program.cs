using System;
using System.Collections.Generic;
using System.Linq;

public class StudentSpecialty
{
    public string SpecialtyName { get; set; }
    public string FacultyNumber { get; set; }

    public StudentSpecialty(string specialtyName, string facultyNumber)
    {
        SpecialtyName = specialtyName;
        FacultyNumber = facultyNumber;
    }
}

public class Student
{
    public string FacultyNumber { get; set; }
    public string FullName { get; set; }

    public Student(string facultyNumber, string fullName)
    {
        FacultyNumber = facultyNumber;
        FullName = fullName;
    }
}

class Program
{
    static void Main()
    {
        List<StudentSpecialty> specialties = new List<StudentSpecialty>();
        List<Student> students = new List<Student>();
        
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Students:")
                break;

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string specialtyName = parts[0] + " " + parts[1];
            string facultyNumber = parts[2];

            specialties.Add(new StudentSpecialty(specialtyName, facultyNumber));
        }
        
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
                break;

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string facultyNumber = parts[0];
            string fullName = parts[1] + " " + parts[2];

            students.Add(new Student(facultyNumber, fullName));
        }
        
        var joined = from s in students
                     join sp in specialties
                     on s.FacultyNumber equals sp.FacultyNumber
                     orderby s.FullName
                     select new
                     {
                         Name = s.FullName,
                         FacNum = s.FacultyNumber,
                         Specialty = sp.SpecialtyName
                     };
        
        foreach (var item in joined)
        {
            Console.WriteLine($"{item.Name} {item.FacNum} {item.Specialty}");
        }
    }
}
