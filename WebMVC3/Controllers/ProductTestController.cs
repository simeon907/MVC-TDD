using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC3.Models;
using WebMVC3.Test;

namespace WebMVC3.Controllers
{
    public class ProductTestController : Controller
    {
        /*Dependency Injection (DI)
        private IEnumerable<Product> _products;

        public ProductTestController(IEnumerable<Product> products)
        {
            _products = products;
        }

        // GET: ProductTest
        public ActionResult Details(IEnumerable<Product> products)
        {
            _products = products;
            return View(_products);
        }*/

        private IProductRepository _repository;

        public ProductTestController()
        {
            _repository = new ProductRepository();
        }

        public ProductTestController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.GetProducts());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.AddProduct(product);
                return RedirectToAction("Index", _repository.GetProducts());
            }
            return View("Create");
        }

        public ActionResult Details(int id)
        {
            if (id < 1)
                return RedirectToAction("Index");

            Product product = _repository.FindById(id);

            return View("Details", product);
        }
    }
}