using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Product
    {
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>
            {
                new Product{Name = "A"}
            };

            Product p = new Product() { Name = "A" };

            list.Add(p);
            list.Add(p);

            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
