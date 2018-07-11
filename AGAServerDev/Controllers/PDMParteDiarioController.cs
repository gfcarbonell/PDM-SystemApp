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
            var obj = serv.SaveOK(PDM_PARTE_DIARIO);
           
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Editar(PDM_PARTE_DIARIO PDM_PARTE_DIARIO
        )
        {
            PDM_PARTE_DIARIO_SERV serv = new PDM_PARTE_DIARIO_SERV();
            var obj = serv.UpdateOk(PDM_PARTE_DIARIO);

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Todos (DateTime Fecha, int IdUsuario)
        {
            PDM_PARTE_DIARIO_SERV serv = new PDM_PARTE_DIARIO_SERV();
            var objs = serv.Get(Fecha, IdUsuario);
            return Json(objs, JsonRequestBehavior.AllowGet);
        }

    }
}