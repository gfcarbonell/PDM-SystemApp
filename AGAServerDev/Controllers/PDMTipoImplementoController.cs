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
    public class PDMTipoImplementoController : Controller
    {
        private DBContextPDM db = new DBContextPDM();

        // GET: Turno
        [HttpGet]
        public JsonResult IndexJSON()
        {
            PDM_TIPO_IMPLEMENTO_SERV tipoImplementoServ = new PDM_TIPO_IMPLEMENTO_SERV();
            return Json(tipoImplementoServ.Get(), JsonRequestBehavior.AllowGet);
        }

        // GET: PDM_TIPO_IMPLEMENTO
        public ActionResult Index()
        {
            return View(db.PDM_TIPO_IMPLEMENTO.ToList());
        }

        // GET: PDM_TIPO_IMPLEMENTO/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDM_TIPO_IMPLEMENTO pDM_TIPO_IMPLEMENTO = db.PDM_TIPO_IMPLEMENTO.Find(id);
            if (pDM_TIPO_IMPLEMENTO == null)
            {
                return HttpNotFound();
            }
            return View(pDM_TIPO_IMPLEMENTO);
        }

        // GET: PDM_TIPO_IMPLEMENTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PDM_TIPO_IMPLEMENTO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoImplemento,Descripcion")] PDM_TIPO_IMPLEMENTO pDM_TIPO_IMPLEMENTO)
        {
            if (ModelState.IsValid)
            {
                db.PDM_TIPO_IMPLEMENTO.Add(pDM_TIPO_IMPLEMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pDM_TIPO_IMPLEMENTO);
        }

        // GET: PDM_TIPO_IMPLEMENTO/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDM_TIPO_IMPLEMENTO pDM_TIPO_IMPLEMENTO = db.PDM_TIPO_IMPLEMENTO.Find(id);
            if (pDM_TIPO_IMPLEMENTO == null)
            {
                return HttpNotFound();
            }
            return View(pDM_TIPO_IMPLEMENTO);
        }

        // POST: PDM_TIPO_IMPLEMENTO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoImplemento,Descripcion")] PDM_TIPO_IMPLEMENTO pDM_TIPO_IMPLEMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pDM_TIPO_IMPLEMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pDM_TIPO_IMPLEMENTO);
        }

        // GET: PDM_TIPO_IMPLEMENTO/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDM_TIPO_IMPLEMENTO pDM_TIPO_IMPLEMENTO = db.PDM_TIPO_IMPLEMENTO.Find(id);
            if (pDM_TIPO_IMPLEMENTO == null)
            {
                return HttpNotFound();
            }
            return View(pDM_TIPO_IMPLEMENTO);
        }

        // POST: PDM_TIPO_IMPLEMENTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PDM_TIPO_IMPLEMENTO pDM_TIPO_IMPLEMENTO = db.PDM_TIPO_IMPLEMENTO.Find(id);
            db.PDM_TIPO_IMPLEMENTO.Remove(pDM_TIPO_IMPLEMENTO);
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
