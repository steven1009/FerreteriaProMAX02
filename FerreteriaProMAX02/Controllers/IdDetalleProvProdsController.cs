using FerreteriaProMAX02.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using static FerreteriaProMAX02.FilterConfig;

namespace FerreteriaProMAX02.Controllers
{
    [AuthorizationFilter]
    public class IdDetalleProvProdsController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: IdDetalleProvProds
        public ActionResult Index()
        {
            var idDetalleProvProds = db.IdDetalleProvProds.Include(i => i.CompraProdProv).Include(i => i.Producto);
            return View(idDetalleProvProds.ToList());
        }

        // GET: IdDetalleProvProds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdDetalleProvProd idDetalleProvProd = db.IdDetalleProvProds.Find(id);
            if (idDetalleProvProd == null)
            {
                return HttpNotFound();
            }
            return View(idDetalleProvProd);
        }

        // GET: IdDetalleProvProds/Create
        public ActionResult Create()
        {
            ViewBag.IdCompraProdProv = new SelectList(db.CompraProdProvs, "IdCompraProdProv", "IdCompraProdProv");
            ViewBag.idProducto = new SelectList(db.Productoes, "IdProducto", "Nombre");
            return View();
        }

        // POST: IdDetalleProvProds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalleProvProd1,Cantidad,Precio,IdCompraProdProv,total,idProducto")] IdDetalleProvProd idDetalleProvProd)
        {
            if (ModelState.IsValid)
            {
                db.IdDetalleProvProds.Add(idDetalleProvProd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCompraProdProv = new SelectList(db.CompraProdProvs, "IdCompraProdProv", "IdCompraProdProv", idDetalleProvProd.IdCompraProdProv);
            ViewBag.idProducto = new SelectList(db.Productoes, "IdProducto", "Nombre", idDetalleProvProd.idProducto);
            return View(idDetalleProvProd);
        }

        // GET: IdDetalleProvProds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdDetalleProvProd idDetalleProvProd = db.IdDetalleProvProds.Find(id);
            if (idDetalleProvProd == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCompraProdProv = new SelectList(db.CompraProdProvs, "IdCompraProdProv", "IdCompraProdProv", idDetalleProvProd.IdCompraProdProv);
            ViewBag.idProducto = new SelectList(db.Productoes, "IdProducto", "Nombre", idDetalleProvProd.idProducto);
            return View(idDetalleProvProd);
        }

        // POST: IdDetalleProvProds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalleProvProd1,Cantidad,Precio,IdCompraProdProv,total,idProducto")] IdDetalleProvProd idDetalleProvProd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idDetalleProvProd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCompraProdProv = new SelectList(db.CompraProdProvs, "IdCompraProdProv", "IdCompraProdProv", idDetalleProvProd.IdCompraProdProv);
            ViewBag.idProducto = new SelectList(db.Productoes, "IdProducto", "Nombre", idDetalleProvProd.idProducto);
            return View(idDetalleProvProd);
        }

        // GET: IdDetalleProvProds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdDetalleProvProd idDetalleProvProd = db.IdDetalleProvProds.Find(id);
            if (idDetalleProvProd == null)
            {
                return HttpNotFound();
            }
            return View(idDetalleProvProd);
        }

        // POST: IdDetalleProvProds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdDetalleProvProd idDetalleProvProd = db.IdDetalleProvProds.Find(id);
            db.IdDetalleProvProds.Remove(idDetalleProvProd);
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
