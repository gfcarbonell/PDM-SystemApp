using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AGAServerDev.Contexts;
using AGAServerDev.Services;

namespace AGAServerDev.Controllers
{
    public class PDMSistemaController : Controller
    {
        private DBContextPDM db = new DBContextPDM();

        // GET: Turno
        [HttpGet]
        public JsonResult IndexJSON()
        {
            PDM_SISTEMA_SERV sistemaServ = new PDM_SISTEMA_SERV();
            return Json(sistemaServ.Get(), JsonRequestBehavior.AllowGet);
        }

        // GET: PDM_SISTEMA
        public ActionResult Index()
        {
            var pDM_SISTEMA = db.PDM_SISTEMA.Include(p => p.PDM_TIPO_IMPLEMENTO);
            return View(pDM_SISTEMA.ToList());
        }

        // GET: PDM_SISTEMA/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDM_SISTEMA pDM_SISTEMA = db.PDM_SISTEMA.Find(id);
            if (pDM_SISTEMA == null)
            {
                return HttpNotFound();
            }
            return View(pDM_SISTEMA);
        }

        // GET: PDM_SISTEMA/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoImplemento = new SelectList(db.PDM_TIPO_IMPLEMENTO, "IdTipoImplemento", "Descripcion");
            return View();
        }

        // POST: PDM_SISTEMA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSistema,Descripcion,IdTipoImplemento")] PDM_SISTEMA pDM_SISTEMA)
        {
            if (ModelState.IsValid)
            {
                db.PDM_SISTEMA.Add(pDM_SISTEMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoImplemento = new SelectList(db.PDM_TIPO_IMPLEMENTO, "IdTipoImplemento", "Descripcion", pDM_SISTEMA.IdTipoImplemento);
            return View(pDM_SISTEMA);
        }

        // GET: PDM_SISTEMA/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDM_SISTEMA pDM_SISTEMA = db.PDM_SISTEMA.Find(id);
            if (pDM_SISTEMA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoImplemento = new SelectList(db.PDM_TIPO_IMPLEMENTO, "IdTipoImplemento", "Descripcion", pDM_SISTEMA.IdTipoImplemento);
            return View(pDM_SISTEMA);
        }

        // POST: PDM_SISTEMA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSistema,Descripcion,IdTipoImplemento")] PDM_SISTEMA pDM_SISTEMA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pDM_SISTEMA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoImplemento = new SelectList(db.PDM_TIPO_IMPLEMENTO, "IdTipoImplemento", "Descripcion", pDM_SISTEMA.IdTipoImplemento);
            return View(pDM_SISTEMA);
        }

        // GET: PDM_SISTEMA/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDM_SISTEMA pDM_SISTEMA = db.PDM_SISTEMA.Find(id);
            if (pDM_SISTEMA == null)
            {
                return HttpNotFound();
            }
            return View(pDM_SISTEMA);
        }

        // POST: PDM_SISTEMA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PDM_SISTEMA pDM_SISTEMA = db.PDM_SISTEMA.Find(id);
            db.PDM_SISTEMA.Remove(pDM_SISTEMA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
