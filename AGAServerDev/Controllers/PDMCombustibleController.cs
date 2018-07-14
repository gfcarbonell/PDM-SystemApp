using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMCombustibleController : Controller
    {
        // GET: Turno
        [HttpGet]
        public JsonResult Index(int IdParte)
        {
            PDM_COMBUSTIBLE_SERV serv = new PDM_COMBUSTIBLE_SERV();
            return Json(serv.Get(IdParte), JsonRequestBehavior.AllowGet);
        }
    }
}