using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskStartNewMethod
{
    public class Program
    {
        public static string? CacheData { get; set; }

        private async static Task Main(string[] args)
        {
            CacheData = await GetDataAsync();
            Console.WriteLine(CacheData);
        }


        public static Task<string> GetDataAsync()
        {
            if (String.IsNullOrEmpty(CacheData))
            {
                return File.ReadAllTextAsync("file.txt");
            }
            else
            {
                return Task.FromResult<string>(CacheData);
            }

        
        }
    }
}
