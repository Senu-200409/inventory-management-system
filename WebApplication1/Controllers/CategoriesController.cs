using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        //private ICategories _categories;

        private readonly ICategories _categories;

        //DACategories DACategories = new DACategories();

        public CategoriesController(ICategories categories)
        {
            _categories = categories;
        }

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllCategories()
        {
            var result = _categories.GetAllCategories();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetCategoriesByCategoryId(string categoryId)
        {
            var result = _categories.GetCategoriesByCategoryId(categoryId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddCategoriesDetails(Categories addCategories)
        {
            var result = _categories.AddCategoriesDetails(addCategories);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}