using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_BazarLibreria.Models;

namespace Proyecto_BazarLibreria.Controllers
{
    public class HistorialController : Controller
    {
        private LibreriaBazarDbContext db = new LibreriaBazarDbContext();

        // GET: Historial
        public ActionResult Index()
        {
            var historiales = db.Historiales.Include(h => h.Usuario);
            return View(historiales.ToList());
        }

        // GET: Historial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.Historiales.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
        }

        // GET: Historial/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioCodigo = new SelectList(db.Usuarios, "Codigo", "Nombre");
            return View();
        }

        // POST: Historial/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioCodigo")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                db.Historiales.Add(historial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioCodigo = new SelectList(db.Usuarios, "Codigo", "Nombre", historial.UsuarioCodigo);
            return View(historial);
        }

        // GET: Historial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.Historiales.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioCodigo = new SelectList(db.Usuarios, "Codigo", "Nombre", historial.UsuarioCodigo);
            return View(historial);
        }

        // POST: Historial/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioCodigo")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioCodigo = new SelectList(db.Usuarios, "Codigo", "Nombre", historial.UsuarioCodigo);
            return View(historial);
        }

        // GET: Historial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.Historiales.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
        }

        // POST: Historial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historial historial = db.Historiales.Find(id);
            db.Historiales.Remove(historial);
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
