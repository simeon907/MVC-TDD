using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC3.Test
{
    public interface IDiscountHelper
    {
        decimal Discount(decimal price);
    }
}
