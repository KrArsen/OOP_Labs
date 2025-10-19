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
        int n = int.Parse(Console.ReadLine()); 

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine(); 
            var stringBox = new Box<string>(input); 
            Console.WriteLine(stringBox); 
        }
    }
}