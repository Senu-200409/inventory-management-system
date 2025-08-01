using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SalesOrdersController : Controller
    {
        //private ISalesOrders _salesorders;

        private readonly ISalesOrders _salesorders;

        //DASuppliers DAPurchaseOrders = new DAPurchaseOrders();

        public SalesOrdersController(ISalesOrders salesorders)
        {
            _salesorders = salesorders;
        }

        // GET: salesorders
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllSalesOrders()
        {
            var result = _salesorders.GetAllSalesOrders();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetSalesOrdersBySalesOrderId(string salesorderId)
        {
            var result = _salesorders.GetSalesOrdersBySalesOrderId(salesorderId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddSalesOrdersDetails(SalesOrdersModel addSalesOrders)
        {
            var result = _salesorders.AddSalesOrdersDetails(addSalesOrders);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}