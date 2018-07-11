using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMEstadoController : Controller
    {
        // GET: Estado
        [HttpGet]
        public JsonResult Index()
        {
            PDM_ESTADO_SERV status = new PDM_ESTADO_SERV();
            var obj = status.Get();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}