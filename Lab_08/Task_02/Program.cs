using System;

abstract class Vehicle
{
    public double FuelQuantity { get; protected set; }
    public double FuelConsumption { get; protected set; }
    public double TankCapacity { get; protected set; }

    protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        TankCapacity = tankCapacity;
        FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public virtual void Drive(double distance)
    {
        double neededFuel = distance * FuelConsumption;

        if (neededFuel <= FuelQuantity)
        {
            FuelQuantity -= neededFuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
    }

    public virtual void Refuel(double liters)
    {
        if (liters <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            return;
        }

        if (FuelQuantity + liters > TankCapacity)
        {
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            return;
        }

        FuelQuantity += liters;
    }
}

class Car : Vehicle
{
    private const double SummerConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption + SummerConsumption, tankCapacity)
    {
    }
}

class Truck : Vehicle
{
    private const double SummerConsumption = 1.6;
    private const double RefuelEfficiency = 0.95;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption + SummerConsumption, tankCapacity)
    {
    }

    public override void Refuel(double liters)
    {
        if (liters <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            return;
        }

        double realFuel = liters * RefuelEfficiency;

        if (FuelQuantity + realFuel > TankCapacity)
        {
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            return;
        }

        FuelQuantity += realFuel;
    }
}

class Bus : Vehicle
{
    private const double AirConditionConsumption = 1.4;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public void DriveWithPeople(double distance)
    {
        double oldConsumption = FuelConsumption;
        FuelConsumption += AirConditionConsumption;

        base.Drive(distance);

        FuelConsumption = oldConsumption; 
    }
}

class Program
{
    static void Main()
    {
        Vehicle car = CreateVehicle(Console.ReadLine());
        Vehicle truck = CreateVehicle(Console.ReadLine());
        Vehicle bus = CreateVehicle(Console.ReadLine());

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
                {
                    car.Drive(distance);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Drive(distance);
                }
                else if (vehicleType == "Bus")
                {
                    ((Bus)bus).DriveWithPeople(distance);
                }
            }
            else if (action == "DriveEmpty")
            {
                double distance = double.Parse(command[2]);
                ((Bus)bus).Drive(distance);
            }
            else if (action == "Refuel")
            {
                double liters = double.Parse(command[2]);

                if (vehicleType == "Car")
                {
                    car.Refuel(liters);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Refuel(liters);
                }
                else if (vehicleType == "Bus")
                {
                    bus.Refuel(liters);
                }
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
    }

    static Vehicle CreateVehicle(string input)
    {
        string[] parts = input.Split();
        string type = parts[0];
        double fuelQuantity = double.Parse(parts[1]);
        double fuelConsumption = double.Parse(parts[2]);
        double tankCapacity = double.Parse(parts[3]);

        if (type == "Car")
        {
            return new Car(fuelQuantity, fuelConsumption, tankCapacity);
        }
        else if (type == "Truck")
        {
            return new Truck(fuelQuantity, fuelConsumption, tankCapacity);
        }
        else if (type == "Bus")
        {
            return new Bus(fuelQuantity, fuelConsumption, tankCapacity);
        }

        throw new ArgumentException("Unknown vehicle type");
    }
}
