using System;

class Point
{
    public int  X { get; set; }
    public int Y { get; set; }
    
    public Point(int x, int y)
        {
        X = x;
        Y = y;
        }
}

class Rectangle
{
    private Point topLeft;
    private Point bottomRight;

    public Rectangle(Point t, Point b)
    {
        topLeft = t;
        bottomRight = b;
    }

    public bool Contains(Point p)
    {
        return (p.X >= topLeft.X && p.X <= bottomRight.X && p.Y >= topLeft.Y && p.Y <= bottomRight.Y );
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter x1, y1, x2, y2: ");
        string[] rectData = Console.ReadLine().Split(' ');
        int x1 = int.Parse(rectData[0]);
        int y1 = int.Parse(rectData[1]);
        int x2 = int.Parse(rectData[2]);
        int y2 = int.Parse(rectData[3]);
        
        Rectangle rect = new Rectangle(new Point(x1, y1), new Point(x2, y2));
        
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] point = Console.ReadLine().Split(' ');
            int px = int.Parse(point[0]);
            int py = int.Parse(point[1]);
            
            Point p = new Point(px, py);
            Console.WriteLine(rect.Contains(p) ? "Yes" : "No");
        }
    }
}