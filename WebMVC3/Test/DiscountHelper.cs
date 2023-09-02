using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC3.Test
{
    public class DiscountHelper : IDiscountHelper
    {
        public decimal Discount(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (price > 1000)
            {
                return price * 0.9m;
            }
            else if(price >= 100)
            {
                return price * 0.95m;
            }

            return price;
        }
    }
}