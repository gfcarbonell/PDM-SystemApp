using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMImplementoController : Controller
    {
        // GET: Turno
        [HttpGet]
        public JsonResult Index(string IdSucursal, Decimal Estado)
        {
            PDM_IMPLEMENTO_SERV turnServ = new PDM_IMPLEMENTO_SERV();
            return Json(turnServ.Get(IdSucursal, Estado), JsonRequestBehavior.AllowGet);
        }
    }
}