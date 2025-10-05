using System;

public class Product
{
    public string Name;
    public double Cost;

    public Product(string name, double cost)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty");
            Environment.Exit(0);
        }

        if (cost < 0)
        {
            Console.WriteLine("Money cannot be negative");
            Environment.Exit(0);
        }

        Name = name;
        Cost = cost;
    }
}

public class Person
{
    public string Name;
    public double Money;
    public string[] Bag;
    public int Count;

    public Person(string name, double money)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty");
            Environment.Exit(0);
        }

        if (money < 0)
        {
            Console.WriteLine("Money cannot be negative");
            Environment.Exit(0);
        }

        Name = name;
        Money = money;
        Bag = new string[100];
        Count = 0;
    }

    public void Buy(Product product)
    {
        if (Money >= product.Cost)
        {
            Money -= product.Cost;
            Bag[Count++] = product.Name;
            Console.WriteLine(Name + " bought " + product.Name);
        }
        else
        {
            Console.WriteLine(Name + " can't afford " + product.Name);
        }
    }

    public void Print()
    {
        Console.Write(Name + " - ");
        if (Count == 0)
        {
            Console.WriteLine("Nothing bought");
        }
        else
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write(Bag[i]);
                if (i < Count - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }
    }
}

public class Program
{
    public static void Main()
    {
        string peopleLine = Console.ReadLine();
        string productsLine = Console.ReadLine();

        Person[] people = new Person[100];
        Product[] products = new Product[100];
        int peopleCount = 0, productCount = 0;


        string[] peopleData = peopleLine.Split(';', StringSplitOptions.RemoveEmptyEntries);
        foreach (string data in peopleData)
        {
            int index = data.IndexOf('=');
            string name = data.Substring(0, index);
            double money = double.Parse(data.Substring(index + 1));
            people[peopleCount++] = new Person(name, money);
        }


        string[] productData = productsLine.Split(';', StringSplitOptions.RemoveEmptyEntries);
        foreach (string data in productData)
        {
            int index = data.IndexOf('=');
            string name = data.Substring(0, index);
            double cost = double.Parse(data.Substring(index + 1));
            products[productCount++] = new Product(name, cost);
        }


        while (true)
        {
            string command = Console.ReadLine();
            if (command == "END") break;
            if (string.IsNullOrWhiteSpace(command)) continue;

            string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string personName = parts[0];
            string productName = parts[1];

            Person buyer = null;
            Product item = null;

            for (int i = 0; i < peopleCount; i++)
                if (people[i].Name == personName)
                    buyer = people[i];

            for (int j = 0; j < productCount; j++)
                if (products[j].Name == productName)
                    item = products[j];

            if (buyer != null && item != null)
                buyer.Buy(item);
        }


        for (int i = 0; i < peopleCount; i++)
            people[i].Print();
    }
}
