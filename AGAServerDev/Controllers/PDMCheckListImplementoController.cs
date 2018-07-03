using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMCheckListImplementoController : Controller
    {
        // GET: Turno
        [HttpGet]
        public JsonResult Index(Byte IdParte, string IdTipoImplemento)
        {
            PDM_CHECKLIST_IMPLEMENTO_SERV checkListServ = new PDM_CHECKLIST_IMPLEMENTO_SERV();
            return Json(checkListServ.Get(IdParte, IdTipoImplemento), JsonRequestBehavior.AllowGet);
        }
    }
}