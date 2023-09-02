using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebMVC3.Models;
using WebMVC3.Test;

namespace WebMVC3.Tests
{
    //test driven development (tdd)
    //red green refactor
    [TestClass]
    public class UnitTestDiscount
    {
        private IDiscountHelper GetDiscountHelper()
        {
            return new DiscountHelper();
        }

        [TestMethod]
        public void Above1000()
        {
            //arrange
            IDiscountHelper discountHelper = GetDiscountHelper();
            decimal price = 2000;

            //act
            decimal total = discountHelper.Discount(price);

            //assert
            Assert.AreEqual(price * 0.9m, total);
        }

        [TestMethod]
        public void Between100And1000()
        {
            //arrange
            IDiscountHelper discountHelper = GetDiscountHelper();

            //act
            decimal hundred = discountHelper.Discount(100);
            decimal fiveHundred = discountHelper.Discount(500);
            decimal thousand = discountHelper.Discount(1000);

            //assert
            Assert.AreEqual(100 * 0.95m, hundred, "100 discount not equal");
            Assert.AreEqual(500 * 0.95m, fiveHundred, "500 discount not equal");
            Assert.AreEqual(1000 * 0.95m, thousand, "1000 discount not equal");
        }

        [TestMethod]
        public void Less100()
        {
            IDiscountHelper discountHelper = GetDiscountHelper();

            decimal fifty = discountHelper.Discount(50);
            decimal zero = discountHelper.Discount(0);

            Assert.AreEqual(50, fifty);
            Assert.AreEqual(0, zero);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Negative()
        {
            GetDiscountHelper().Discount(-1);
        }

        private IEnumerable<Product> _products = new List<Product>
        {
            new Product{Name = "Kayak", Category = "Watersport", Price = 275.99m},
            new Product{Name = "Lifejacket", Category = "Watersport", Price = 48.99m},
            new Product{Name = "Soccer ball", Category = "Soccer", Price = 19.99m},
            new Product{Name = "Corner flag", Category = "Soccer", Price = 34.99m}
        };

        [TestMethod]
        public void AllDiscountTest_NoProducts()
        {
            IDiscountHelper discountHelper = GetDiscountHelper();
            TestCalculator calculator = new TestCalculator(discountHelper);
            IEnumerable<Product> products = new List<Product>();

            // Act
            decimal result = calculator.AllDiscount(products);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AllDiscountTest_PriceLessThan100()
        {
            IDiscountHelper discountHelper = GetDiscountHelper();
            TestCalculator calculator = new TestCalculator(discountHelper);
            IEnumerable<Product> products = new List<Product>
            {
                new Product { Price = 50 },
                new Product { Price = 75 }
            };
            
            decimal result = calculator.AllDiscount(products);

            foreach (Product product in products)
            {
                product.Price = discountHelper.Discount(product.Price);
            }


            Assert.AreEqual(products.Sum(p=>p.Price), result);
        }

        [TestMethod]
        public void AllDiscountTest_PriceBetween100And1000()
        {
            IDiscountHelper discountHelper = GetDiscountHelper();
            TestCalculator calculator = new TestCalculator(discountHelper);
            IEnumerable<Product> products = new List<Product>
            {
                new Product { Price = 150 },
                new Product { Price = 500 }
            };
            
            decimal result = calculator.AllDiscount(products);

            foreach (Product product in products)
            {
                product.Price = discountHelper.Discount(product.Price);
            }


            Assert.AreEqual(products.Sum(p=>p.Price), result);
        }

        [TestMethod]
        public void AllDiscountTest_PriceOver1000()
        {
            IDiscountHelper discountHelper = GetDiscountHelper();
            TestCalculator calculator = new TestCalculator(discountHelper);
            IEnumerable<Product> products = new List<Product>
            {
                new Product { Price = 1500 },
                new Product { Price = 2000 }
            };

            decimal result = calculator.AllDiscount(products);

            foreach (Product product in products)
            {
                product.Price = discountHelper.Discount(product.Price);
            }

            

            Assert.AreEqual(products.Sum(p => p.Price), result);
        }
    }
}
