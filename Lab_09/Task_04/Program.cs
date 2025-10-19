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
        Box<string>[] boxes = new Box<string>[n];

       
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            boxes[i] = new Box<string>(input);
        }

       
        string[] parts = Console.ReadLine().Split();
        int index1 = int.Parse(parts[0]);
        int index2 = int.Parse(parts[1]);

       
        Swap(boxes, index1, index2);

       
        for (int i = 0; i < boxes.Length; i++)
        {
            Console.WriteLine(boxes[i]);
        }
    }

    
    static void Swap<T>(T[] array, int index1, int index2)
    {
        T temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}