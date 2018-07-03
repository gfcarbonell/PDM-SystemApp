using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMSucursalController : Controller
    {
        // GET: Turno
        [HttpGet]
        public JsonResult Index()
        {
            PDM_SUCURSAL_SERV sucursalServ = new PDM_SUCURSAL_SERV();
            return Json(sucursalServ.Get(), JsonRequestBehavior.AllowGet);
        }
    }
}