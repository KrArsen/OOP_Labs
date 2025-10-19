using System;

class Box<T> where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public T Value
    {
        get { return value; }
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
        Box<string>[] boxes = new Box<string>[n];

        
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            boxes[i] = new Box<string>(input);
        }

        
        string compareValue = Console.ReadLine();
        Box<string> compareBox = new Box<string>(compareValue);

        
        int count = CountGreater(boxes, compareBox);
        Console.WriteLine(count);
    }

    
    static int CountGreater<T>(Box<T>[] array, Box<T> element) where T : IComparable<T>
    {
        int count = 0;
        foreach (var box in array)
        {
            if (box.Value.CompareTo(element.Value) > 0)
            {
                count++;
            }
        }
        return count;
    }
}