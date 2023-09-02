using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC3.Models;

namespace WebMVC3.Test
{
    public class TestCalculator
    {
        private IDiscountHelper _discountHelper;

        public TestCalculator(IDiscountHelper discountHelper)
        {
            _discountHelper = discountHelper;
        }

        public decimal AllDiscount(IEnumerable<Product> products)
        {
            decimal totalDiscountedPrice = 0;

            foreach (Product product in products)
            {
                totalDiscountedPrice += _discountHelper.Discount(product.Price);
            }

            return totalDiscountedPrice;
        }
    }
}