using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC3.Models;

namespace WebMVC3.Test
{
    public class FakeRepository : IProductRepository
    {
        private List<Product> _products;

        public FakeRepository()
        {
            _products = new List<Product>
            {
                new Product{Id = 5, Name = "Soccer ball", Category = "Soccer", Price = 19.99m}
            };
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public Product FindById(int id)
        {
            return _products.SingleOrDefault(p => p.Id == id);
        }

        public IList<Product> GetProducts()
        {
            return _products;
        }
    }
}