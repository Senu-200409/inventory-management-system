using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        //private IProducts _products;

        private readonly IProducts _products;

        //DAProducts DAProducts = new DAProducts();

        public ProductsController(IProducts products)
        {
            _products = products;
        }

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var result = _products.GetAllProducts();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetProductsByProductId(string productId)
        {
            var result = _products.GetProductsByProductId(productId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddProductsDetails(ProductsModel addProducts)
        {
            var result = _products.AddProductsDetails(addProducts);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}