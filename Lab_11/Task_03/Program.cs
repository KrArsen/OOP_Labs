using System;

public enum Light
{
    Red,
    Green,
    Yellow
}

public class TrafficLight
{
    public Light CurrentLight { get; private set; }

    public TrafficLight(string color)
    {
        this.CurrentLight = (Light)Enum.Parse(typeof(Light), color, true);
    }

    public void Change()
    {
        if (CurrentLight == Light.Red)
        {
            CurrentLight = Light.Green;
        }
        else if (CurrentLight == Light.Green)
        {
            CurrentLight = Light.Yellow;
        }
        else
        {
            CurrentLight = Light.Red;
        }
    }

    public override string ToString()
    {
        return CurrentLight.ToString();
    }
}

public class Program
{
    public static void Main()
    {
        
        string[] input = Console.ReadLine().Split(' ');

        
        TrafficLight[] lights = new TrafficLight[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            lights[i] = new TrafficLight(input[i]);
        }

        
        int n = int.Parse(Console.ReadLine());

        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < lights.Length; j++)
            {
                lights[j].Change();
            }

            for (int j = 0; j < lights.Length; j++)
            {
                Console.Write(lights[j]);
                if (j < lights.Length - 1)
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}