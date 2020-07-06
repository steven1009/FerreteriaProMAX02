using FerreteriaProMAX02.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FerreteriaProMAX02.Controllers
{
    public class VentasController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();
        private Metodos.Metodos m = new Metodos.Metodos();
        // GET: Ventas
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
            {
                var ventas = db.Ventas.Include(v => v.Empleado).Include(v => v.Persona);
                return View(ventas.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
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
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }

        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
            {
                ViewBag.idEmpleado = new SelectList(db.Empleadoes, "IdEmpleado", "IdEmpleado");
                ViewBag.idPersona = new SelectList(db.Personas, "idPersona", "Cedula");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }

        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVenta,fecha,idPersona,idEmpleado")] Venta venta)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
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
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }

        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
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
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }

        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVenta,fecha,idPersona,idEmpleado")] Venta venta)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
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
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }

        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
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
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }

        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
            {
                Venta venta = db.Ventas.Find(id);
                db.Ventas.Remove(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }

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
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
            {
                ViewBag.IdEmpleado = Session["idempleado"];
                ViewBag.IdPago = new SelectList(db.TipoPagoes, "IdPago", "Nombre");
                ViewBag.IdProductoL = new SelectList(db.Productoes, "IdProducto", "Nombre");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }

        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VentaN([Bind(Include = "IdVenta,fecha,idPersona,idEmpleado")] Venta ventas)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
            {
                if (ModelState.IsValid)
                {
                    db.Ventas.Add(ventas);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IdEmpleado = Session["idempleado"];
                ViewBag.IdPago = new SelectList(db.TipoPagoes, "IdPago", "Nombre");
                ViewBag.IdProductoL = new SelectList(db.Productoes, "IdProducto", "Nombre");
                return View(ventas);
            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
        }
        [HttpGet]
        public ActionResult ObtenerClientes()
        {
            return View(db.Personas.ToList());
        }

        [HttpPost]//para buscar clientes
        public ActionResult ObtenerClientes(string txtnombre, string txtappaterno, string txtdni, string txtcliente)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
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
            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }

        }

        [HttpPost]
        public ActionResult Seleccionar(string idProducto)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
            {
                Producto p = db.Productoes.Find(Int32.Parse(idProducto));
                Producto producto = new Producto();
                producto.IdProducto = p.IdProducto;
                producto.Nombre = p.Nombre;
                producto.PrecioU = p.PrecioU;
                return Json(producto, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }

        }
        [HttpPost]
        public ActionResult GuardarVenta(DateTime fecha, string Cedula, string idEmpleado, string IdPago, string total1, List<DetalleVenta> ListadoDetalle)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
            else if (!Session["id"].ToString().Equals("0"))
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
                    Persona persona = db.Personas.Find(m.BuscarCedulaP(Cedula));
                    Venta venta1 = new Venta();
                    venta1.fecha = fecha;
                    venta1.idPersona = persona.idPersona;
                    venta1.idEmpleado = Int32.Parse(idEmpleado);
                    db.Ventas.Add(venta1);
                    db.SaveChanges();
                    decimal tdescuento = (decimal)0;
                    decimal tsubtotal = (decimal)0;
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
            else
            {
                return RedirectToAction("Login", "Usuario_Login");
            }
        }
    }
}
