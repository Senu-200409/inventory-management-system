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
    public class PurchaseOrdersController : Controller
    {
        //private IPurchaseOrders _purchaseorders;

        private readonly IPurchaseOrders _purchaseorders;

        //DASuppliers DAPurchaseOrders = new DAPurchaseOrders();

        public PurchaseOrdersController(IPurchaseOrders purchaseorders)
        {
            _purchaseorders = purchaseorders;
        }

        // GET: customers
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllPurchaseOrders()
        {
            var result = _purchaseorders.GetAllPurchaseOrders();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetPurchaseOrdersByPurchaseOrderId(string purchaseordersId)
        {
            var result = _purchaseorders.GetPurchaseOrdersByPurchaseOrderId(purchaseordersId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddPurchaseOrdersDetails(PurchaseOrdersModel addPurchaseOrders)
        {
            var result = _purchaseorders.AddPurchaseOrdersDetails(addPurchaseOrders);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}