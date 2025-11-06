using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public class Order
    {
        public string Company { get; set; }
        public int Amount { get; set; }
        public string Product { get; set; }

        public Order(string company, int amount, string product)
        {
            Company = company;
            Amount = amount;
            Product = product;
        }
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Order> orders = new List<Order>();
        
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine()
                .Trim('|', ' ')
                .Replace("|", "");

            string[] parts = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            string company = parts[0];
            int amount = int.Parse(parts[1]);
            string product = parts[2];

            orders.Add(new Order(company, amount, product));
        }
        
        var grouped = orders
            .GroupBy(o => o.Company)
            .OrderByDescending(g => g.Key)
            .Select(g => new
            {
                Company = g.Key,
                Products = g
                    .GroupBy(p => p.Product)
                    .Select(p => new
                    {
                        Product = p.Key,
                        Total = p.Sum(x => x.Amount),
                        FirstIndex = orders.FindIndex(x => x.Company == g.Key && x.Product == p.Key)
                    })
                    .OrderBy(p => p.FirstIndex) 
            });

        
        foreach (var group in grouped)
        {
            var products = group.Products
                .Select(p => $"{p.Product}-{p.Total}");

            Console.WriteLine($"{group.Company}: {string.Join(", ", products)}");
        }
    }
}
