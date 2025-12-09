using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Task_02.Data;
using Task_02.Data.Models;

namespace Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new SalesContext();

            
            context.Database.Migrate();

            
            if (!context.Products.Any() &&
                !context.Customers.Any() &&
                !context.Stores.Any() &&
                !context.Sales.Any())
            {
                Seed(context);
                Console.WriteLine("База даних успішно заповнена тестовими даними!");
            }
            else
            {
                Console.WriteLine("Дані вже існують. Seed не потрібно.");
            }
        }

        private static void Seed(SalesContext context)
        {
            var random = new Random();

            
            var products = Enumerable.Range(1, 10)
                .Select(i => new Product
                {
                    Name = $"Product {i}",
                    Quantity = random.Next(1, 100),
                    Price = (decimal)(random.Next(10, 300) + random.NextDouble())
                })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            
            var customers = Enumerable.Range(1, 10)
                .Select(i => new Customer
                {
                    Name = $"Customer {i}",
                    Email = $"customer{i}@mail.com",
                    CreditCardNumber = $"1111-2222-3333-{i:0000}"
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            
            var stores = Enumerable.Range(1, 5)
                .Select(i => new Store
                {
                    Name = $"Store {i}"
                })
                .ToList();

            context.Stores.AddRange(stores);
            context.SaveChanges();

            
            var sales = Enumerable.Range(1, 30)
                .Select(i => new Sale
                {
                    Date = DateTime.Now.AddDays(-random.Next(0, 365)),
                    ProductId = products[random.Next(products.Count)].ProductId,
                    CustomerId = customers[random.Next(customers.Count)].CustomerId,
                    StoreId = stores[random.Next(stores.Count)].StoreId
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();
        }
    }
}
