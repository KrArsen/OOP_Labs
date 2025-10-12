using System;

abstract class Vehicle
{
    public double FuelQuantity { get; protected set; }
    public double FuelConsumption { get; protected set; }

    public Vehicle(double fuelQuantity, double fuelConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public abstract void Drive(double distance);
    public abstract void Refuel(double liters);
}

class Car : Vehicle
{
    private const double SummerConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption + SummerConsumption) { }

    public override void Drive(double distance)
    {
        double neededFuel = distance * FuelConsumption;

        if (neededFuel <= FuelQuantity)
        {
            FuelQuantity -= neededFuel;
            Console.WriteLine($"Car travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Car needs refueling");
        }
    }

    public override void Refuel(double liters)
    {
        FuelQuantity += liters;
    }
}

class Truck : Vehicle
{
    private const double SummerConsumption = 1.6;
    private const double RefuelEfficiency = 0.95;

    public Truck(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption + SummerConsumption) { }

    public override void Drive(double distance)
    {
        double neededFuel = distance * FuelConsumption;

        if (neededFuel <= FuelQuantity)
        {
            FuelQuantity -= neededFuel;
            Console.WriteLine($"Truck travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Truck needs refueling");
        }
    }

    public override void Refuel(double liters)
    {
        FuelQuantity += liters * RefuelEfficiency;
    }
}

class Program
{
    static void Main()
    {
        string[] carInfo = Console.ReadLine().Split(' ');
        string[] truckInfo = Console.ReadLine().Split(' ');

        Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
        Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] command = Console.ReadLine().Split();
            string action = command[0];
            string vehicleType = command[1];

            if (action == "Drive")
            {
                double distance = double.Parse(command[2]);
                if (vehicleType == "Car")
                    car.Drive(distance);
                else if (vehicleType == "Truck")
                    truck.Drive(distance);
            }
            else if (action == "Refuel")
            {
                double liters = double.Parse(command[2]);
                if (vehicleType == "Car")
                    car.Refuel(liters);
                else if (vehicleType == "Truck")
                    truck.Refuel(liters);
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
    }
}
