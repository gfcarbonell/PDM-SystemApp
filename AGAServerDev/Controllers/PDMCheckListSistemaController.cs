using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMCheckListSistemaController : Controller
    {
        // GET: Turno
        [HttpGet]
        public JsonResult Index(Byte IdParte)
        {
            PDM_CHECKLIST_SISTEMA_SERV checkListServ = new PDM_CHECKLIST_SISTEMA_SERV();
            return Json(checkListServ.Get(IdParte), JsonRequestBehavior.AllowGet);
        }
    }
}