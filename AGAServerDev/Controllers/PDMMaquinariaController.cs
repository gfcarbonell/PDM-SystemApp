using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMMaquinariaController : Controller
    {
        // GET: Turno
        [HttpGet]
        public JsonResult Index(string IdSucursal, Decimal Estado)
        {
            PDM_MAQUINARIA_SERV maquinariaServ = new PDM_MAQUINARIA_SERV();
            return Json(maquinariaServ.Get(IdSucursal, Estado), JsonRequestBehavior.AllowGet);
        }
    }
}