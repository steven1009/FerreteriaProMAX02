using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FerreteriaProMAX02.Models;

namespace FerreteriaProMAX02.Controllers
{
      public class VentasController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();
        private Metodos.Metodos m = new Metodos.Metodos();
        // GET: Ventas
        public ActionResult Index()
        {
            var ventas = db.Ventas.Include(v => v.Empleado).Include(v => v.Persona);
            return View(ventas.ToList());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "IdEmpleado", "IdEmpleado");
            ViewBag.idPersona = new SelectList(db.Personas, "idPersona", "Cedula");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVenta,fecha,idPersona,idEmpleado")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Ventas.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "IdEmpleado", "IdEmpleado", venta.idEmpleado);
            ViewBag.idPersona = new SelectList(db.Personas, "idPersona", "Cedula", venta.idPersona);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "IdEmpleado", "IdEmpleado", venta.idEmpleado);
            ViewBag.idPersona = new SelectList(db.Personas, "idPersona", "Cedula", venta.idPersona);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVenta,fecha,idPersona,idEmpleado")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleadoes, "IdEmpleado", "IdEmpleado", venta.idEmpleado);
            ViewBag.idPersona = new SelectList(db.Personas, "idPersona", "Cedula", venta.idPersona);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Ventas.Find(id);
            db.Ventas.Remove(venta);
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
        public ActionResult VentaN()
        {
            //Ventas ventas1 = db.Ventas.Find(m.ObtenerVentaT());
            //if (ventas1 == null)
            //{
            //    ViewBag.idVenta = 1;
            //}
            //else
            //{
            //    ViewBag.idVenta = (int)ventas1.IdVenta + 1;
            //}
            ViewBag.IdEmpleado = Session["idempleado"];
            ViewBag.IdPago = new SelectList(db.TipoPagoes, "IdPago", "Nombre");
            ViewBag.IdProductoL = new SelectList(db.Productoes, "IdProducto", "Nombre");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VentaN([Bind(Include = "IdVenta,fecha,idPersona,idEmpleado")] Venta ventas)
        {

            if (ModelState.IsValid)
            {
                db.Ventas.Add(ventas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //Ventas ventas1 = db.Ventas.Find(m.ObtenerVentaT());
            //if (ventas1 == null)
            //{
            //    ViewBag.idVenta = 1;
            //}
            //else
            //{
            //    ViewBag.idVenta = (int)ventas1.IdVenta + 1;
            //}
            ViewBag.IdEmpleado = Session["idempleado"];
            ViewBag.IdPago = new SelectList(db.TipoPagoes, "IdPago", "Nombre");
            ViewBag.IdProductoL = new SelectList(db.Productoes, "IdProducto", "Nombre");
            return View(ventas);
        }
        [HttpGet]
        public ActionResult ObtenerClientes()
        {
            return View(db.Personas.ToList());
        }

        [HttpPost]//para buscar clientes
        public ActionResult ObtenerClientes(string txtnombre, string txtappaterno, string txtdni, string txtcliente)
        {
            if (txtnombre == "")
            {
                txtnombre = "-1";
            }
            if (txtappaterno == "")
            {
                txtappaterno = "-1";
            }
            if (txtdni == "")
            {
                txtdni = "-1";
            }
            if (txtcliente == "")
            {
                txtcliente = "-1";
            }
            Persona objCliente = new Persona();
            objCliente.Codigo = Int32.Parse(txtcliente);
            objCliente.nombre = txtnombre;
            objCliente.Primer_Apellido = txtappaterno;
            objCliente.Cedula = txtdni;

            if (objCliente.Codigo != -1)
            {
                List<Persona> persona = m.Get0((int)(objCliente.Codigo));
                return View(persona);
            }
            else if (!objCliente.nombre.ToString().Equals("-1"))
            {
                List<Persona> persona = m.Get1(objCliente.nombre);
                return View(persona);
            }
            else if (!objCliente.Primer_Apellido.ToString().Equals("-1"))
            {
                List<Persona> persona = m.Get3(objCliente.Primer_Apellido);
                return View(persona);
            }
            else if (!objCliente.Cedula.ToString().Equals("-1"))
            {
                List<Persona> persona = m.Get2(objCliente.Cedula);
                return View(persona);
            }
            else
            {
                return View(db.Personas.ToList());
            }
            //List<Persona> persona = db.Persona.Find(objCliente);

        }

        [HttpPost]
        public ActionResult Seleccionar(string idProducto)
        {
            Producto p = db.Productoes.Find(Int32.Parse(idProducto));

            Producto producto = new Producto();
            producto.IdProducto = p.IdProducto;
            producto.Nombre = p.Nombre;
            producto.PrecioU = p.PrecioU;
            //db.Producto.Find(1);
            return Json(producto, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult PruebaJson()
        //{  // escribir la url directa  para ver el formato
        //    List<Producto> lista = objProductoNeg.findAll();
        //    return Json(lista, JsonRequestBehavior.AllowGet);

        //}
        [HttpPost]
        public ActionResult GuardarVenta(DateTime fecha, string Cedula, string idEmpleado, string IdPago, string total1, List<DetalleVenta> ListadoDetalle)
        {
            string mensaje = "";
            decimal iva = 0;
            int idVenta = 0;
            decimal total = 0;

            if (Cedula == "" || idEmpleado == "")
            {
                if (Cedula == "") mensaje = "ERROR CON CEDULA DEL CLIENTE";
                if (idEmpleado == "") mensaje = "ERROR EN EL ID DEL CLIENTE";
            }
            else
            {
                Venta venta = db.Ventas.Find(m.ObtenerVentaT());
                if (venta == null)
                {
                    idVenta = 1;
                }
                else
                {
                    idVenta = (int)venta.IdVenta + 1;
                }
                //codigoPago = Convert.ToInt32(modoPago);
                Persona persona = db.Personas.Find(m.BuscarCedulaP(Cedula));
                //int
                //if (persona == null) {

                //}
                //int

                //REGISTRO DE VENTA
                Venta venta1 = new Venta();
                venta1.fecha = fecha;
                venta1.idPersona = persona.idPersona;
                venta1.idEmpleado = Int32.Parse(idEmpleado);
                db.Ventas.Add(venta1);
                db.SaveChanges();
                decimal tdescuento = (decimal) 0;
                decimal tsubtotal = (decimal) 0;
                int indexv = m.ObtenerVentaT();
                foreach (var data in ListadoDetalle)
                {
                    int idProducto = Convert.ToInt32(data.IdProducto.ToString());
                    int cantidad = Convert.ToInt32(data.Cantidad.ToString());
                    decimal descuento = Convert.ToDecimal(data.Descuento.ToString());
                    tdescuento = tdescuento + descuento;
                    decimal subtotal = Convert.ToDecimal(data.SubTOTAL.ToString()) + descuento;
                    tsubtotal = subtotal + tsubtotal;
                    iva = (subtotal - descuento) * (decimal)0.15;
                    total = subtotal + iva;
                    DetalleVenta detalleVenta = new DetalleVenta();
                    detalleVenta.IdVenta = indexv;
                    detalleVenta.IdProducto = idProducto;
                    detalleVenta.Cantidad = cantidad;
                    detalleVenta.SubTOTAL = subtotal;
                    detalleVenta.Descuento = descuento;
                    detalleVenta.Iva = iva;
                    detalleVenta.Total = total;
                    db.DetalleVentas.Add(detalleVenta);
                    db.SaveChanges();


                }
                Factura factura = new Factura();
                factura.IdPago = Convert.ToInt32(IdPago);
                factura.idVenta = indexv;
                factura.Fecha = fecha;
                factura.subtotal = tsubtotal;
                factura.Descuento = tdescuento;
                factura.Iva = (Convert.ToDecimal(total1) - tdescuento) * (decimal)0.15;
                factura.Total = (float)(Convert.ToDecimal(total1) + (Convert.ToDecimal(total1) - tdescuento) * (decimal)0.15);

                db.Facturas.Add(factura);
                db.SaveChanges();
                mensaje = "VENTA GUARDADA CON EXITO...";
            }
            return Json(mensaje);

        }
    }
}
