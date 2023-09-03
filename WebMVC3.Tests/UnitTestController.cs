using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using WebMVC3.Controllers;
using WebMVC3.Models;
using WebMVC3.Test;

namespace WebMVC3.Tests
{
    [TestClass]
    public class UnitTestController
    {
        [TestMethod]
        public void TestIndexRender()
        {
            ProductTestController fakeController = new ProductTestController(new FakeRepository());

            ActionResult result = fakeController.Index();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestIndexModel()
        {
            ProductTestController fakeController = new ProductTestController(new FakeRepository());

            ViewResult result = fakeController.Index() as ViewResult;
            IList<Product> products = result.Model as IList<Product>;

            Assert.IsNotNull(products);
            Assert.AreEqual(1, products.Count);
        }

        [TestMethod]
        public void TestCreateModel()
        {
            ProductTestController fakeController = new ProductTestController(new FakeRepository());
            fakeController.ModelState.AddModelError("Price", "Not required");

            ViewResult result = fakeController.Create(new Product()) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void TestCreateRedirectToIndex()
        {
            ProductTestController fakeController = new ProductTestController(new FakeRepository());

            RedirectToRouteResult result = fakeController.Create(new Product()) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            object products = (fakeController.Index() as ViewResult).Model;
            Assert.AreEqual(2, (products as IList<Product>).Count);
        }

        [TestMethod]
        public void TestDetailsView()
        {
            ProductTestController fakeController = new ProductTestController(new FakeRepository());

            int id = 2;
            ViewResult result = fakeController.Details(id) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void TestDetailsViewData()
        {
            ProductTestController fakeController = new ProductTestController(new FakeRepository());

            int id = 2;
            ViewResult result = fakeController.Details(id) as ViewResult;
            Product product = result.ViewData.Model as Product;

            Assert.AreEqual(id, product.Id);
        }

        [TestMethod]
        public void TestDetailsRedirect()
        {
            ProductTestController fakeController = new ProductTestController(new FakeRepository());

            int id = -1;
            RedirectToRouteResult result = fakeController.Details(id) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
