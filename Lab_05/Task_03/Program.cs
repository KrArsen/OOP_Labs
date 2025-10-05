using System;

public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public string FlourType
    {
        get { return flourType; }
        set
        {
            string t = value.ToLower();
            if (t != "white" && t != "wholegrain")
            {
                Console.WriteLine("Invalid type of dough.");
                Environment.Exit(0);
            }
            flourType = value;
        }
    }

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            string t = value.ToLower();
            if (t != "crispy" && t != "chewy" && t != "homemade")
            {
                Console.WriteLine("Invalid type of dough.");
                Environment.Exit(0);
            }
            bakingTechnique = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                Console.WriteLine("Dough weight should be in the range [1..200].");
                Environment.Exit(0);
            }
            weight = value;
        }
    }

    public double GetCalories()
    {
        double flourMod = flourType.ToLower() == "white" ? 1.5 : 1.0;
        double bakeMod = 1.0;
        string b = bakingTechnique.ToLower();
        if (b == "crispy") bakeMod = 0.9;
        else if (b == "chewy") bakeMod = 1.1;
        else if (b == "homemade") bakeMod = 1.0;

        return (2 * weight) * flourMod * bakeMod;
    }
}

public class Topping
{
    private string type;
    private double weight;

    public Topping(string type, double weight)
    {
        Type = type;
        Weight = weight;
    }

    public string Type
    {
        get { return type; }
        set
        {
            string t = value.ToLower();
            if (t != "meat" && t != "veggies" && t != "cheese" && t != "sauce")
            {
                Console.WriteLine($"Cannot place {value} on top of your pizza.");
                Environment.Exit(0);
            }
            type = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                Console.WriteLine($"{type} weight should be in the range [1..50].");
                Environment.Exit(0);
            }
            weight = value;
        }
    }

    public double GetCalories()
    {
        double modifier = 1.0;
        string t = type.ToLower();
        if (t == "meat") modifier = 1.2;
        else if (t == "veggies") modifier = 0.8;
        else if (t == "cheese") modifier = 1.1;
        else if (t == "sauce") modifier = 0.9;

        return (2 * weight) * modifier;
    }
}

public class Pizza
{
    private string name;
    private Dough dough;
    private Topping[] toppings;
    private int toppingCount;

    public Pizza(string name)
    {
        Name = name;
        toppings = new Topping[20];
        toppingCount = 0;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                Environment.Exit(0);
            }
            name = value;
        }
    }

    public void SetDough(Dough dough)
    {
        this.dough = dough;
    }

    public void AddTopping(Topping topping)
    {
        if (toppingCount >= 10)
        {
            Console.WriteLine("Number of toppings should be in range [0..10].");
            Environment.Exit(0);
        }
        toppings[toppingCount++] = topping;
    }

    public double GetTotalCalories()
    {
        double total = dough.GetCalories();
        for (int i = 0; i < toppingCount; i++)
        {
            total += toppings[i].GetCalories();
        }
        return total;
    }
}

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        if (input.StartsWith("Dough"))
        {
            
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string flour = parts[1];
            string bake = parts[2];
            double weight = double.Parse(parts[3]);
            Dough dough = new Dough(flour, bake, weight);
            Console.WriteLine($"{dough.GetCalories():F2}");
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "END") break;
            }
        }
        else if (input.StartsWith("Topping"))
        {
            
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = parts[1];
            double weight = double.Parse(parts[2]);
            Topping t = new Topping(type, weight);
            Console.WriteLine($"{t.GetCalories():F2}");
        }
        else if (input.StartsWith("Pizza"))
        {
            
            string[] pizzaData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string pizzaName = pizzaData[1];
            Pizza pizza = new Pizza(pizzaName);

            string doughData = Console.ReadLine();
            string[] dParts = doughData.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Dough dough = new Dough(dParts[1], dParts[2], double.Parse(dParts[3]));
            pizza.SetDough(dough);

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END") break;

                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string toppingType = parts[1];
                double toppingWeight = double.Parse(parts[2]);
                Topping topping = new Topping(toppingType, toppingWeight);
                pizza.AddTopping(topping);
            }

            Console.WriteLine($"{pizzaName} - {pizza.GetTotalCalories():F2} Calories.");
        }
    }
}
