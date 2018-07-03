using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMTurnoController : Controller
    {
        // GET: Turno
        [HttpGet]
        public JsonResult Index()
        {
            PDM_TURNO_SERV turnServ = new PDM_TURNO_SERV();
            return Json(turnServ.Get(), JsonRequestBehavior.AllowGet); 
        }
    }
}