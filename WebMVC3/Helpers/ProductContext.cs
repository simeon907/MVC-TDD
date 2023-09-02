using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebMVC3.Models;

namespace WebMVC3.Helpers
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("ProductTestMVC")
        {
            
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}