using System;

abstract class Food
{
    public int Quantity { get; set; }

    public Food(int quantity)
    {
        Quantity = quantity;
    }
}

class Vegetable : Food
{
    public Vegetable(int quantity) : base(quantity) { }
}

class Fruit : Food
{
    public Fruit(int quantity) : base(quantity) { }
}

class Meat : Food
{
    public Meat(int quantity) : base(quantity) { }
}

class Seeds : Food
{
    public Seeds(int quantity) : base(quantity) { }
}

abstract class Animal
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public int FoodEaten { get; set; }

    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
        FoodEaten = 0;
    }

    public abstract void MakeSound();
    public abstract void Eat(Food food);
}

abstract class Bird : Animal
{
    public double WingSize { get; set; }

    protected Bird(string name, double weight, double wingSize)
        : base(name, weight)
    {
        WingSize = wingSize;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
}

class Owl : Bird
{
    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize) { }

    public override void MakeSound()
    {
        Console.WriteLine("Hoot Hoot");
    }

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            Weight += 0.25 * food.Quantity;
            FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}

class Hen : Bird
{
    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize) { }

    public override void MakeSound()
    {
        Console.WriteLine("Cluck");
    }

    public override void Eat(Food food)
    {
        Weight += 0.35 * food.Quantity;
        FoodEaten += food.Quantity;
    }
}

abstract class Mammal : Animal
{
    public string LivingRegion { get; set; }

    protected Mammal(string name, double weight, string livingRegion)
        : base(name, weight)
    {
        LivingRegion = livingRegion;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}

class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion) { }

    public override void MakeSound()
    {
        Console.WriteLine("Squeak");
    }

    public override void Eat(Food food)
    {
        if (food is Vegetable || food is Fruit)
        {
            Weight += 0.10 * food.Quantity;
            FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}

class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion) { }

    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
    }

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            Weight += 0.40 * food.Quantity;
            FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}

abstract class Feline : Mammal
{
    public string Breed { get; set; }

    protected Feline(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion)
    {
        Breed = breed;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}

class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed) { }

    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }

    public override void Eat(Food food)
    {
        if (food is Vegetable || food is Meat)
        {
            Weight += 0.30 * food.Quantity;
            FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}

class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed) { }

    public override void MakeSound()
    {
        Console.WriteLine("ROAR!!!");
    }

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            Weight += 1.00 * food.Quantity;
            FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}

class Program
{
    static void Main()
    {
        Animal[] animals = new Animal[100];
        int count = 0;

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] animalInfo = input.Split(' ');
            string foodLine = Console.ReadLine();
            string[] foodInfo = foodLine.Split(' ');

            Animal animal = CreateAnimal(animalInfo);
            Food food = CreateFood(foodInfo);

            animal.MakeSound();
            animal.Eat(food);

            animals[count] = animal;
            count++;
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(animals[i]);
        }
    }

    static Animal CreateAnimal(string[] info)
    {
        string type = info[0];
        string name = info[1];
        double weight = double.Parse(info[2]);

        if (type == "Cat")
            return new Cat(name, weight, info[3], info[4]);
        else if (type == "Tiger")
            return new Tiger(name, weight, info[3], info[4]);
        else if (type == "Dog")
            return new Dog(name, weight, info[3]);
        else if (type == "Mouse")
            return new Mouse(name, weight, info[3]);
        else if (type == "Owl")
            return new Owl(name, weight, double.Parse(info[3]));
        else if (type == "Hen")
            return new Hen(name, weight, double.Parse(info[3]));

        throw new InvalidOperationException("Unknown animal type");
    }

    static Food CreateFood(string[] info)
    {
        string type = info[0];
        int quantity = int.Parse(info[1]);

        if (type == "Vegetable")
            return new Vegetable(quantity);
        else if (type == "Fruit")
            return new Fruit(quantity);
        else if (type == "Meat")
            return new Meat(quantity);
        else if (type == "Seeds")
            return new Seeds(quantity);

        throw new InvalidOperationException("Unknown food type");
    }
}
