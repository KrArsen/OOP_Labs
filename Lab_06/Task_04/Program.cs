using System;

abstract class Food
{
    public int Happiness { get; protected set; }
}

class Cram : Food
{
    public Cram() { this.Happiness = 2; }
}

class Lembas : Food
{
    public Lembas() { this.Happiness = 3; }
}

class Apple : Food
{
    public Apple() { this.Happiness = 1; }
}

class Melon : Food
{
    public Melon() { this.Happiness = 1; }
}

class HoneyCake : Food
{
    public HoneyCake() { this.Happiness = 5; }
}

class Mushrooms : Food
{
    public Mushrooms() { this.Happiness = -10; }
}

class OtherFood : Food
{
    public OtherFood() { this.Happiness = -1; }
}


class FoodFactory
{
    public static Food GetFood(string foodName)
    {
        string name = foodName.ToLower();

        if (name == "cram")
            return new Cram();
        else if (name == "lembas")
            return new Lembas();
        else if (name == "apple")
            return new Apple();
        else if (name == "melon")
            return new Melon();
        else if (name == "honeycake")
            return new HoneyCake();
        else if (name == "mushrooms")
            return new Mushrooms();
        else
            return new OtherFood();
    }
}

abstract class Mood
{
    public string Name { get; protected set; }
}

class Angry : Mood
{
    public Angry() { this.Name = "Angry"; }
}

class Sad : Mood
{
    public Sad() { this.Name = "Sad"; }
}

class Happy : Mood
{
    public Happy() { this.Name = "Happy"; }
}

class Bliss : Mood
{
    public Bliss() { this.Name = "Bliss"; } 
}

class MoodFactory
{
    public static Mood GetMood(int happiness)
    {
        if (happiness < -5)
            return new Angry();
        else if (happiness >= -5 && happiness <= 0)
            return new Sad();
        else if (happiness >= 1 && happiness <= 15)
            return new Happy();
        else
            return new Bliss();
    }
}


class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] foods = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int totalHappiness = 0;

        foreach (string foodName in foods)
        {
            Food food = FoodFactory.GetFood(foodName);
            totalHappiness += food.Happiness;
        }

        Mood mood = MoodFactory.GetMood(totalHappiness);

        Console.WriteLine(totalHappiness);
        Console.WriteLine(mood.Name);
    }
}
