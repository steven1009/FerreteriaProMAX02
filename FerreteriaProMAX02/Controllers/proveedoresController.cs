﻿using FerreteriaProMAX02.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using static FerreteriaProMAX02.FilterConfig;

namespace FerreteriaProMAX02.Controllers
{
    [AuthorizationFilter]
    public class proveedoresController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: proveedores
        public ActionResult Index()
        {
            return View(db.proveedores.ToList());
        }

        // GET: proveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedore proveedore = db.proveedores.Find(id);
            if (proveedore == null)
            {
                return HttpNotFound();
            }
            return View(proveedore);
        }

        // GET: proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: proveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProveedores,Nombre,TipoProveedor")] proveedore proveedore)
        {
            if (ModelState.IsValid)
            {
                db.proveedores.Add(proveedore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proveedore);
        }

        // GET: proveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedore proveedore = db.proveedores.Find(id);
            if (proveedore == null)
            {
                return HttpNotFound();
            }
            return View(proveedore);
        }

        // POST: proveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProveedores,Nombre,TipoProveedor")] proveedore proveedore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedore);
        }

        // GET: proveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedore proveedore = db.proveedores.Find(id);
            if (proveedore == null)
            {
                return HttpNotFound();
            }
            return View(proveedore);
        }

        // POST: proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proveedore proveedore = db.proveedores.Find(id);
            db.proveedores.Remove(proveedore);
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
