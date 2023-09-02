using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC3.Models;

namespace WebMVC3.Test
{
    public interface IProductRepository
    {
        IList<Product> GetProducts();
        Product FindById(int id);
        void AddProduct(Product product);
    }
}
