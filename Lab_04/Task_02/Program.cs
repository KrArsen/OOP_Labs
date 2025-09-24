using System;

enum Season
{
    Autumn = 1,
    Spring = 2,
    Winter = 3,
    Summer = 4
}

enum Discount
{
    None,
    VIP,
    SecondVisit
}

class CalculatorPrice
{
    private double pricePerDay;
    private int numberOfDays;
    private Season season;
    private Discount discount;

    public CalculatorPrice(double ppd, int nod, Season s, Discount d)
    {
        pricePerDay = ppd;
        numberOfDays = nod;
        season = s;
        discount = d;
    }

    public double Calculator()
    {
        double total = pricePerDay * numberOfDays *  (int)season;

        switch (discount)
        {
            case Discount.VIP:
                total *=  0.80;
                break;
            case Discount.SecondVisit:
                total *=  0.90;
                break;
            case Discount.None:
                break;
        }
        return total;
    }
}

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        
        double pricePerDay = double.Parse(input[0]);
        int numberOfDays = int.Parse(input[1]);
        Season season = (Season)Enum.Parse(typeof(Season), input[2],true);
        
        Discount discount = Discount.None;

        if (input.Length == 4)
        {
            discount = (Discount)Enum.Parse(typeof(Discount), input[3]);
        }
        
        CalculatorPrice calculator = new CalculatorPrice(pricePerDay, numberOfDays, season, discount);
        
        Console.WriteLine($"{calculator.Calculator():F2}");
    }
}