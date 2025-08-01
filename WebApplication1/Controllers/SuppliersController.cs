using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SuppliersController : Controller
    {
        //private ISuppliers _suppliers;

        private readonly ISuppliers _suppliers;

        //DASuppliers DASuppliers = new DASuppliers();

        public SuppliersController(ISuppliers suppliers)
        {
            _suppliers = suppliers;
        }

        // GET: Suppliers
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllSuppliers()
        {
            var result = _suppliers.GetAllSuppliers();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetSuppliersBySupplierId(string supplierId)
        {
            var result = _suppliers.GetSuppliersBySupplierId(supplierId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddSuppliersDetails(SuppliersModel addSuppliers)
        {
            var result = _suppliers.AddSuppliersDetails(addSuppliers);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}