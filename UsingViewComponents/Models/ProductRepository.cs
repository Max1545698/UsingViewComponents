using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingViewComponents.Models
{

    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void AddProduct(Product product);
    }
    public class MemoryProductRepository : IProductRepository
    {
        private UsingViewComponentsDbContext context;

        public MemoryProductRepository(UsingViewComponentsDbContext context)
        {
            this.context = context;
        }
        //private List<Product> products = new List<Product>()
        //{
        //    new Product{Name = "Kayak", Price = 275M},
        //    new Product{Name = "Lifejacket", Price = 48.95M},
        //    new Product{Name = "Seccer ball", Price = 19.50M}
        //};

        public IEnumerable<Product> Products => context.Products;

        public void AddProduct(Product product)
        {
            if (product.Id == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products
                    .FirstOrDefault(p => p.Id == product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Price = product.Price;
                }
            }
            context.SaveChanges();
        }
    }
}
