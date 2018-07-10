using AGAServerDev.Models;
using AGAServerDev.Services;
using Newtonsoft.Json;
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
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PDM_PARTE_DIARIO_SERV parteServ = new PDM_PARTE_DIARIO_SERV();
            PDM_CHECKLIST_SISTEMA_SERV checkListSistemaServ = new PDM_CHECKLIST_SISTEMA_SERV();
            PDM_CHECKLIST_IMPLEMENTO_SERV checkListImplementoServ = new PDM_CHECKLIST_IMPLEMENTO_SERV();
            PDM_OBSERVACION_SERV obserServ = new PDM_OBSERVACION_SERV();

            var parte = parteServ.GetParteById(id);
            var IdCheck = Byte.Parse(id.ToString());
            var checkSistema = checkListSistemaServ.Get(IdCheck);
            var checkImplemento = checkListImplementoServ.Get(IdCheck, parte.IdTipoImplemento);
            var observaciones = obserServ.Get(id);

            ViewBag.IdParte = id;
            ViewBag.IdSucursal = parte.IdSucursal;
            ViewBag.IdTipoImplemento = parte.IdTipoImplemento;
            ViewBag.IdImplemento = parte.IdImplemento;
            ViewBag.IdMaquinaria = parte.IdMaquinaria;
            ViewBag.IdEstado = parte.IdEstado;
            ViewBag.Fecha = parte.Fecha;
            ViewBag.IdTurno = parte.IdTurno;
            ViewBag.checkSistema = JsonConvert.SerializeObject(checkSistema);
            ViewBag.checkImplemento = JsonConvert.SerializeObject(checkImplemento);
            ViewBag.observaciones = JsonConvert.SerializeObject(observaciones);
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