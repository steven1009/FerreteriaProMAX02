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
    public class CompraProdProvsController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();
        private Metodos.Metodos m = new Metodos.Metodos();
        // GET: CompraProdProvs
        public ActionResult Index()
        {
            var compraProdProvs = db.CompraProdProvs.Include(c => c.proveedore);
            return View(compraProdProvs.ToList());
        }

        // GET: CompraProdProvs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraProdProv compraProdProv = db.CompraProdProvs.Find(id);
            if (compraProdProv == null)
            {
                return HttpNotFound();
            }
            return View(compraProdProv);
        }

        // GET: CompraProdProvs/Create
        public ActionResult Create()
        {
            ViewBag.IdProveedores = new SelectList(db.proveedores, "IdProveedores", "Nombre");
            return View();
        }

        // POST: CompraProdProvs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCompraProdProv,Fecha,IdProveedores")] CompraProdProv compraProdProv)
        {
            if (ModelState.IsValid)
            {
                db.CompraProdProvs.Add(compraProdProv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProveedores = new SelectList(db.proveedores, "IdProveedores", "Nombre", compraProdProv.IdProveedores);
            return View(compraProdProv);
        }

        // GET: CompraProdProvs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraProdProv compraProdProv = db.CompraProdProvs.Find(id);
            if (compraProdProv == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProveedores = new SelectList(db.proveedores, "IdProveedores", "Nombre", compraProdProv.IdProveedores);
            return View(compraProdProv);
        }

        // POST: CompraProdProvs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCompraProdProv,Fecha,IdProveedores")] CompraProdProv compraProdProv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compraProdProv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProveedores = new SelectList(db.proveedores, "IdProveedores", "Nombre", compraProdProv.IdProveedores);
            return View(compraProdProv);
        }

        // GET: CompraProdProvs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraProdProv compraProdProv = db.CompraProdProvs.Find(id);
            if (compraProdProv == null)
            {
                return HttpNotFound();
            }
            return View(compraProdProv);
        }

        // POST: CompraProdProvs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompraProdProv compraProdProv = db.CompraProdProvs.Find(id);
            db.CompraProdProvs.Remove(compraProdProv);
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
        public ActionResult CompraN()
        {
            ViewBag.IdEmpleado = Session["idempleado"];
            ViewBag.IdProductoL = new SelectList(db.Productoes, "IdProducto", "Nombre");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompraN([Bind(Include = "IdCompraProdProv,fecha,IdProveedores")] CompraProdProv compra)
        {

            if (ModelState.IsValid)
            {
                db.CompraProdProvs.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = Session["idempleado"];
            ViewBag.IdProductoL = new SelectList(db.Productoes, "IdProducto", "Nombre");
            return View(compra);
        }

        [HttpGet]
        public ActionResult ObtenerProveedores()
        {
            return View(db.proveedores.ToList());
        }

        [HttpPost]//para buscar clientes
        public ActionResult ObtenerProveedores(string txtnombre)
        {
            if (txtnombre == "")
            {
                txtnombre = "-1";
            }

            proveedore prov = new proveedore();
            prov.Nombre = txtnombre;


            List<proveedore> proveedores = m.Get5(prov.Nombre);
            return View(proveedores);


        }

        [HttpPost]
        public ActionResult Seleccionar(string idProducto)
        {
            Producto p = db.Productoes.Find(Int32.Parse(idProducto));

            Producto producto = new Producto();
            producto.IdProducto = p.IdProducto;
            producto.Nombre = p.Nombre;
            producto.PrecioU = p.PrecioU * 100 / 140;
            //db.Producto.Find(1);
            return Json(producto, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult PruebaJson()
        //{  // escribir la url directa  para ver el formato
        //    List<Producto> lista = objProductoNeg.findAll();
        //    return Json(lista, JsonRequestBehavior.AllowGet);

        //}
        [HttpPost]
        public ActionResult GuardarCompra(DateTime Fecha, string Nombre, string idEmpleado, List<IdDetalleProvProd> ListadoCompra)
        {
            string mensaje = "";
            int idCompra = 0;
            decimal total = 0;

            if (idEmpleado == "")
            {
                if (idEmpleado == "") mensaje = "ERROR EN EL ID DEL CLIENTE";
            }
            else
            {
                CompraProdProv compra = db.CompraProdProvs.Find(m.ObtenerVentaT());
                if (compra == null)
                {
                    idCompra = 1;
                }
                else
                {
                    idCompra = (int)compra.IdCompraProdProv + 1;
                }
                //codigoPago = Convert.ToInt32(modoPago);
                proveedore proveedores = db.proveedores.Find(m.BuscarProv(Nombre));


                //REGISTRO DE VENTA
                CompraProdProv compra1 = new CompraProdProv();
                compra1.Fecha = Fecha;
                compra1.IdProveedores = proveedores.IdProveedores;
                db.CompraProdProvs.Add(compra1);
                db.SaveChanges();
                int indexv = m.ObtenerCompraT();
                foreach (var data in ListadoCompra)
                {
                    int idProducto = Convert.ToInt32(data.idProducto.ToString());
                    int Cantidad = Convert.ToInt32(data.Cantidad.ToString());
                    decimal Precio = Convert.ToDecimal(data.Precio.ToString());
                    total = Convert.ToDecimal(data.total.ToString());
                    IdDetalleProvProd compradetalle = new IdDetalleProvProd();
                    compradetalle.Cantidad = Cantidad;
                    compradetalle.total = total;
                    compradetalle.Precio = Precio;
                    compradetalle.idProducto = idProducto;
                    compradetalle.IdCompraProdProv = indexv;
                    db.IdDetalleProvProds.Add(compradetalle);
                    db.SaveChanges();


                }
                mensaje = "COMPRA GUARDADA CON EXITO...";
            }
            return Json(mensaje);

        }
    }
}
