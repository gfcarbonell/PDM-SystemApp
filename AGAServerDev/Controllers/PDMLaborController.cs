using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMLaborController : Controller
    {
        // GET: Labor
        [HttpGet]
        public JsonResult Index(string IdActividad)
        {
            PDM_LABOR_SERV laborServ = new PDM_LABOR_SERV();
            return Json(laborServ.Get(IdActividad), JsonRequestBehavior.AllowGet);
        }
    }
}