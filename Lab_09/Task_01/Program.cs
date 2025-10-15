using System;

class Box<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return $"{value.GetType().FullName}: {value}";
    }
}

class Program
{
    static void Main()
    {
        
        var intBox = new Box<int>(123123);
        Console.WriteLine(intBox);

        var stringBox = new Box<string>("life in a box");
        Console.WriteLine(stringBox);
    }
}