using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebMVC3.Helpers;
using WebMVC3.Models;

namespace WebMVC3.Test
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext _context;

        public ProductRepository()
        {
            _context = new ProductContext();
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product FindById(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }

        public IList<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}