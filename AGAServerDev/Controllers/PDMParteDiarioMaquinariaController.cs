using AGAServerDev.Models;
using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMParteDiarioMaquinariaController : Controller
    {
        // Post: PDMParteDiarioMaquinaria
        [HttpPost]
        public JsonResult Agregar(PDM_PARTE_DIARIO_MAQUINARIA PDM_PARTE_DIARIO_MAQUINARIA)
        {
            PDM_PARTE_DIARIO_MAQUINARIA_SERV objServ = new PDM_PARTE_DIARIO_MAQUINARIA_SERV();
            objServ.SaveOK(PDM_PARTE_DIARIO_MAQUINARIA);
            return Json(PDM_PARTE_DIARIO_MAQUINARIA, JsonRequestBehavior.AllowGet);
        }

        // GET: PDMParteDiarioMaquinaria
        [HttpGet]
        public JsonResult Index(int IdParte)
        {
            PDM_PARTE_DIARIO_MAQUINARIA_SERV objServ = new PDM_PARTE_DIARIO_MAQUINARIA_SERV();
            return Json(objServ.Get(IdParte), JsonRequestBehavior.AllowGet);
        }
    }
}