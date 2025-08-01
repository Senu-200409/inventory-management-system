using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataAccess;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        //private ICustomers _customers;

        private readonly ICustomers _customers;

        //DASuppliers DACustomers = new DACustomers();

        public CustomersController(ICustomers customers)
        {
            _customers = customers;
        }

        // GET: customers
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllCustomers()
        {
            var result = _customers.GetAllCustomers();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetCustomersByCustomerId(string customerId)
        {
            var result = _customers.GetCustomersByCustomerId(customerId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddCustomersDetails(CustomersModel addCustomers)
        {
            var result = _customers.AddCustomersDetails(addCustomers);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}