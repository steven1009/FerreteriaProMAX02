using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FerreteriaProMAX02.Models;

namespace FerreteriaProMAX02.Controllers
{
    public class DetalleRolesController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: DetalleRoles
        public ActionResult Index()
        {
            var detalleRoles = db.DetalleRoles.Include(d => d.USUARIO_LOGIN).Include(d => d.Role);
            return View(detalleRoles.ToList());
        }

        // GET: DetalleRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleRole detalleRole = db.DetalleRoles.Find(id);
            if (detalleRole == null)
            {
                return HttpNotFound();
            }
            return View(detalleRole);
        }

        // GET: DetalleRoles/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.USUARIO_LOGIN, "IdUsuario", "Usuario");
            ViewBag.IdRoles = new SelectList(db.Roles, "IdRoles", "Nombre");
            return View();
        }

        // POST: DetalleRoles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_DetalleRoles,IdUsuario,FechaMOD,IdRoles")] DetalleRole detalleRole)
        {
            if (ModelState.IsValid)
            {
                db.DetalleRoles.Add(detalleRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.USUARIO_LOGIN, "IdUsuario", "Usuario", detalleRole.IdUsuario);
            ViewBag.IdRoles = new SelectList(db.Roles, "IdRoles", "Nombre", detalleRole.IdRoles);
            return View(detalleRole);
        }

        // GET: DetalleRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleRole detalleRole = db.DetalleRoles.Find(id);
            if (detalleRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.USUARIO_LOGIN, "IdUsuario", "Usuario", detalleRole.IdUsuario);
            ViewBag.IdRoles = new SelectList(db.Roles, "IdRoles", "Nombre", detalleRole.IdRoles);
            return View(detalleRole);
        }

        // POST: DetalleRoles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_DetalleRoles,IdUsuario,FechaMOD,IdRoles")] DetalleRole detalleRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.USUARIO_LOGIN, "IdUsuario", "Usuario", detalleRole.IdUsuario);
            ViewBag.IdRoles = new SelectList(db.Roles, "IdRoles", "Nombre", detalleRole.IdRoles);
            return View(detalleRole);
        }

        // GET: DetalleRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleRole detalleRole = db.DetalleRoles.Find(id);
            if (detalleRole == null)
            {
                return HttpNotFound();
            }
            return View(detalleRole);
        }

        // POST: DetalleRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleRole detalleRole = db.DetalleRoles.Find(id);
            db.DetalleRoles.Remove(detalleRole);
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
