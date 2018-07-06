using AGAServerDev.Contexts;
using AGAServerDev.Models;
using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMParteDiarioController : Controller
    {
        // Post: PDMParteDiario
        [HttpPost]
        public JsonResult Agregar(PDM_PARTE_DIARIO PDM_PARTE_DIARIO
        )
        {
            PDM_PARTE_DIARIO_SERV serv = new PDM_PARTE_DIARIO_SERV();
            var x = serv.SaveOK(PDM_PARTE_DIARIO);
           
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        
    }
}