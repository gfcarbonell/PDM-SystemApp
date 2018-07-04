using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Models
{
    public class PDMOperarioController : Controller
    {
        // GET: Turno
        [HttpGet]
        public JsonResult Index(Decimal Estado)
        {
            PDM_OPERARIO_SERV operarioServ = new PDM_OPERARIO_SERV();
            return Json(operarioServ.Get(Estado), JsonRequestBehavior.AllowGet);
        }
    }
}