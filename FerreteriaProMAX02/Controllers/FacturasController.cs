using FerreteriaProMAX02.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using static FerreteriaProMAX02.FilterConfig;

namespace FerreteriaProMAX02.Controllers
{
    [AuthorizationFilter]
    public class FacturasController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: Facturas
        public ActionResult Index()
        {
            var facturas = db.Facturas.Include(f => f.Venta).Include(f => f.Venta1).Include(f => f.TipoPago);
            return View(facturas.ToList());
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            ViewBag.idVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta");
            ViewBag.idVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta");
            ViewBag.IdPago = new SelectList(db.TipoPagoes, "IdPago", "Nombre");
            return View();
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFactura,Total,Iva,Fecha,Descuento,IdPago,idVenta,subtotal")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta", factura.idVenta);
            ViewBag.idVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta", factura.idVenta);
            ViewBag.IdPago = new SelectList(db.TipoPagoes, "IdPago", "Nombre", factura.IdPago);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta", factura.idVenta);
            ViewBag.idVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta", factura.idVenta);
            ViewBag.IdPago = new SelectList(db.TipoPagoes, "IdPago", "Nombre", factura.IdPago);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFactura,Total,Iva,Fecha,Descuento,IdPago,idVenta,subtotal")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta", factura.idVenta);
            ViewBag.idVenta = new SelectList(db.Ventas, "IdVenta", "IdVenta", factura.idVenta);
            ViewBag.IdPago = new SelectList(db.TipoPagoes, "IdPago", "Nombre", factura.IdPago);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Facturas.Find(id);
            db.Facturas.Remove(factura);
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
