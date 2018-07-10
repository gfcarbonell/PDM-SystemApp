using AGAServerDev.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AGAServerDev.Controllers
{
    public class PDMHomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CheckList()
        {

            return View();
        }

        [HttpGet]
        public ActionResult CheckListEditar(int id)
        {
            if (id==0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PDM_PARTE_DIARIO_SERV serv = new PDM_PARTE_DIARIO_SERV();

            var obj = serv.GetParteById(id);
            ViewBag.IdSucursal = obj.IdSucursal;
            ViewBag.IdTipoImplemento = obj.IdTipoImplemento;
            ViewBag.IdMaquinaria = obj.IdMaquinaria;
            ViewBag.Fecha = obj.Fecha;
            ViewBag.IdTurno = obj.IdTurno;
            ViewBag.PDM_CHECKLIST = obj.PDM_CHECKLIST;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}