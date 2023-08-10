using PLINQApp.Models;
using System;

namespace PLINQApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AdventureWorks2017Context context = new AdventureWorks2017Context();

            var products = context.Products.Take(100).ToArray();
            products[3].Name = "###";
            var query = products.AsParallel().Where(p => p.Name[2] == 'a');

            try
            {
                query.ForAll(x =>
                {
                    Console.WriteLine($"{x.Name}");
                });
            }
            catch (AggregateException ex)
            {
                ex.InnerExceptions.ToList().ForEach(x => 
                {
                    Console.WriteLine($"Error:{x.GetType().Name}");
                });
            }
                
        }
    }
}
