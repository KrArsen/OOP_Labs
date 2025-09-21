using System;

public class Engine
{
    public string Model { get; set; }
    public int Power{get;set;}
    public string Displacement{get;set;}
    public string Efficiency{get;set;}

    public Engine(string model, int power)
    {
        Model = model;
        Power = power;
        Displacement = "n/a";
        Efficiency = "n/a";
    }
    public Engine(string model, int power,string displacement)
    {
        Model = model;
        Power = power;
        Displacement = displacement;
        Efficiency = "n/a";
    }

    public Engine(string model, int power, string displacement, string efficiency)
    {
        Model = model;
        Power = power;
        Displacement = displacement;
        Efficiency = efficiency;
    }
}

public class Car
{
    public string Model {get;set;}
    public Engine Engine{get;set;}
    public string Weight{get;set;}
    public string Color{get;set;}

    public Car(string model, Engine engine)
    {
        Model = model;
        Engine = engine;
        Weight = "n/a";
        Color = "n/a";
    }

    public Car(string model, Engine engine, string weight)
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Color = "n/a";
    }
    
    public Car(string model, Engine engine, string weight, string color)
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Color = color;
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Engine[] engines = new Engine[n];

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ');
            string model = parts[0];
            int power = int.Parse(parts[1]);

            if (parts.Length == 2)
            {
                engines[i] = new Engine(model, power);
            } 
            else if (parts.Length == 3)
            { 
                engines[i] = new Engine(model, power, parts[2]);
            }
            else if  (parts.Length == 4)
            {
                engines[i] = new Engine(model, power, parts[2],parts[3]);
            }
            
        }
        int m = int.Parse(Console.ReadLine());
        Car[] cars = new Car[m];
        for (int i = 0; i < m; i++)
        {
            string[] parts = Console.ReadLine().Split(' ');
            string carModel = parts[0];
            string engineModel = parts[1];
            
            Engine selectedEngine = null;
            for (int j = 0; j < n; j++)
            {
                if (engines[j].Model == engineModel)
                {
                    selectedEngine = engines[j];
                    break;
                }
            }
            if (parts.Length == 2)
            {
                cars[i] = new Car(carModel, selectedEngine);
            } 
            else if (parts.Length == 3)
            { 
                cars[i] = new Car(carModel, selectedEngine, parts[2]);
            }
            else if  (parts.Length == 4)
            {
                cars[i] = new Car(carModel, selectedEngine, parts[2],parts[3]);
            }
        }

        for (int i = 0; i < m; i++)
        {
            Console.WriteLine($"{cars[i].Model}:");
            Console.WriteLine($"  {cars[i].Engine.Model}:");
            Console.WriteLine($"    Power: {cars[i].Engine.Power}");
            Console.WriteLine($"    Displacement: {cars[i].Engine.Displacement}");
            Console.WriteLine($"    Efficiency: {cars[i].Engine.Efficiency}");
            Console.WriteLine($"  Weight: {cars[i].Weight}");
            Console.WriteLine($"  Color: {cars[i].Color}");
        }
    }
}