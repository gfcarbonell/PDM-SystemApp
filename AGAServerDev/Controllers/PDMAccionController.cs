using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMAccionController : Controller
    {
        // GET: Accion
        [HttpGet]
        public JsonResult Index()
        {
            PDM_ACCION_SERV actionServ = new PDM_ACCION_SERV();
            return Json(actionServ.Get(), JsonRequestBehavior.AllowGet);
        }
    }
}