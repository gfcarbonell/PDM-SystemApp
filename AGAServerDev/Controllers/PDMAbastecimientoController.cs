using AGAServerDev.Models;
using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMAbastecimientoController : Controller
    {
        // Post: PDM_ABASTECIMIENTO
        [HttpPost]
        public JsonResult Agregar(PDM_ABASTECIMIENTO PDM_ABASTECIMIENTO)
        {
            PDM_ABASTECIMIENTO_SERV serv = new PDM_ABASTECIMIENTO_SERV();
            var obj = serv.SaveOK(PDM_ABASTECIMIENTO);

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}