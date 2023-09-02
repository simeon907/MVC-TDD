using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebMVC3.Models;

namespace WebMVC3.Helpers
{
    public class ProductDbInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            context.Products.Add(new Product { Name = "Kayak", Category = "Watersport", Price = 275.99m });
            context.Products.Add(new Product { Name = "Lifejacket", Category = "Watersport", Price = 48.99m });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}