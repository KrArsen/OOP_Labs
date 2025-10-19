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
        Box<double>[] boxes = new Box<double>[n];

        
        for (int i = 0; i < n; i++)
        {
            double number = double.Parse(Console.ReadLine());
            boxes[i] = new Box<double>(number);
        }

        
        double compareValue = double.Parse(Console.ReadLine());
        Box<double> compareBox = new Box<double>(compareValue);

        
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