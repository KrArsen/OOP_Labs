using System;
using System.Linq;

public class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public Employee(string name, double salary, string position, string department)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Department = department;
        Email = "n/a";
        Age = -1;
    }
    
    public Employee(string name, double salary, string position, string department, string email)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Department = department;
        Email = email;
        Age = -1;
    }
    public Employee(string name, double salary, string position, string department, int age)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Department = department;
        Email = "n/a";
        Age = age;
    }
    public Employee(string name, double salary, string position, string department, string email, int age)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Department = department;
        Email = email;
        Age = age;
    }
    
}

class Program
{
    static void Main()
    {
        
        int n = int.Parse(Console.ReadLine());
        Employee[] employees = new Employee[n];

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ');
            string name = parts[0];
            double salary = double.Parse(parts[1]);
            string position = parts[2];
            string department = parts[3];

            if (parts.Length == 4)
            {
                employees[i] = new Employee(name, salary, position, department);
            }
            else if (parts.Length == 5)
            {
                if (int.TryParse(parts[4], out int age))
                    employees[i] = new Employee(name, salary, position, department, age);
                else
                    employees[i] = new Employee(name, salary, position, department, parts[4]);
            }
            else if (parts.Length == 6)
            {
                employees[i] = new Employee(name, salary, position, department, parts[4], int.Parse(parts[5]));
            }
        }

        
        string[] departments = new string[n];
        int depCount = 0;

        for (int i = 0; i < n; i++)
        {
            string dep = employees[i].Department;
            bool exists = false;
            for (int j = 0; j < depCount; j++)
            {
                if (departments[j] == dep)
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                departments[depCount] = dep;
                depCount++;
            }
        }

        
        string bestDep = "";
        double bestAvg = 0;

        for (int i = 0; i < depCount; i++)
        {
            string dep = departments[i];
            double sum = 0;
            int count = 0;

            for (int j = 0; j < n; j++)
            {
                if (employees[j].Department == dep)
                {
                    sum += employees[j].Salary;
                    count++;
                }
            }

            double avg = sum / count;
            if (avg > bestAvg)
            {
                bestAvg = avg;
                bestDep = dep;
            }
        }

        Console.WriteLine($"Highest Average Salary: {bestDep}");

        
        Employee[] selected = new Employee[n];
        int selectedCount = 0;

        for (int i = 0; i < n; i++)
        {
            if (employees[i].Department == bestDep)
            {
                selected[selectedCount] = employees[i];
                selectedCount++;
            }
        }

        
        for (int i = 0; i < selectedCount - 1; i++)
        {
            for (int j = i + 1; j < selectedCount; j++)
            {
                if (selected[i].Salary < selected[j].Salary)
                {
                    Employee temp = selected[i];
                    selected[i] = selected[j];
                    selected[j] = temp;
                }
            }
        }

        
        for (int i = 0; i < selectedCount; i++)
        {
            Console.WriteLine($"{selected[i].Name} {selected[i].Salary:F2} {selected[i].Email} {selected[i].Age}");
        }
    }
}