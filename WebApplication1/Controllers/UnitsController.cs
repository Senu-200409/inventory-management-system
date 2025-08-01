using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UnitsController : Controller
    {
       
        private readonly IUnits _units;

        //DAUnits DAUnits = new DAUnits();

        public UnitsController(IUnits units)
        {
            _units = units;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllUnits()
        {
            var result = _units.GetAllUnits();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUnitsByUnitId(string unitId)
        {
            var result = _units.GetUnitsByUnitId(unitId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddUnitsDetails(Units addUnits)
        {
            var result = _units.AddUnitsDetails(addUnits);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}