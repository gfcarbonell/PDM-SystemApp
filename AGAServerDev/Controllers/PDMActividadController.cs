using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMActividadController : Controller
    {
        // GET: PDMActividad
        public ActionResult Index()
        {
            PDM_ACTIVIDAD_SERV activityServ = new PDM_ACTIVIDAD_SERV();
            return Json(activityServ.Get(), JsonRequestBehavior.AllowGet);
        }
    }
}