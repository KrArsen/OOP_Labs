using System;

class Car
{
    public string Model {get;set;}
    public double Fuel{get;set;}
    public double Consumption{get;set;}
    public double Distance {get;set;}

    public Car(string model, double fuel, double consumption)
    {
        Model = model;
        Fuel = fuel;
        Consumption = consumption;
        Distance = 0;
    }

    public void Drive(double km)
    {
        double needed = km * Consumption;
        if (needed <= Fuel)
        {
            Fuel -= needed;
            Distance += km;
        }
        else
        {
            Console.WriteLine("Not enough fuel!");
        }
    }

    public void Print()
    {
        Console.WriteLine($"{Model} {Fuel:F2} {Distance}");
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Car[] cars = new Car[n];

        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split();
            string model = data[0];
            double fuel = double.Parse(data[1]);
            double consumption = double.Parse(data[2]);

            cars[i] = new Car(model, fuel, consumption);
        }

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
                break;

            string[] parts = input.Split();
            string carModel = parts[1];
            double km = double.Parse(parts[2]);

            for (int i = 0; i < n; i++)
            {
                if (cars[i].Model == carModel)
                {
                    cars[i].Drive(km);
                    break;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            cars[i].Print();
        }
    }
}