using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMConsumidorController : Controller
    {
        // GET: Accion
        [HttpGet]
        public JsonResult Index(string IdSucursal)
        {
            PDM_CONSUMIDOR_SERV consumidorServ = new PDM_CONSUMIDOR_SERV();
            var objs = consumidorServ.Get(IdSucursal);
            return Json(objs, JsonRequestBehavior.AllowGet);
        }
    }
}