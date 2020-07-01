using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FerreteriaProMAX02.Models;
using Microsoft.Ajax.Utilities;

namespace FerreteriaProMAX02.Controllers
{
    public class USUARIO_LOGINController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();
        private Metodos.Metodos m = new Metodos.Metodos();
        // GET: USUARIO_LOGIN
        public ActionResult Index()
        {
            var uSUARIO_LOGIN = db.USUARIO_LOGIN.Include(u => u.Persona).Include(u => u.Persona1);
            return View(uSUARIO_LOGIN.ToList());
        }

        // GET: USUARIO_LOGIN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(id);
            if (uSUARIO_LOGIN == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO_LOGIN);
        }

        // GET: USUARIO_LOGIN/Create
        public ActionResult Create()
        {
            ViewBag.idPersona = new SelectList(db.Personas, "idPersona", "Cedula");
            ViewBag.idPersona = new SelectList(db.Personas, "idPersona", "Cedula");
            return View();
        }

        // POST: USUARIO_LOGIN/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Usuario,Contraseña,idPersona")] USUARIO_LOGIN uSUARIO_LOGIN)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO_LOGIN.Add(uSUARIO_LOGIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPersona = new SelectList(db.Personas, "idPersona", "Cedula", uSUARIO_LOGIN.idPersona);
            ViewBag.idPersona = new SelectList(db.Personas, "idPersona", "Cedula", uSUARIO_LOGIN.idPersona);
            return View(uSUARIO_LOGIN);
        }

        // GET: USUARIO_LOGIN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(id);
            if (uSUARIO_LOGIN == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(db.Personas, "idPersona", "Cedula", uSUARIO_LOGIN.idPersona);
            ViewBag.idPersona = new SelectList(db.Personas, "idPersona", "Cedula", uSUARIO_LOGIN.idPersona);
            return View(uSUARIO_LOGIN);
        }

        // POST: USUARIO_LOGIN/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Usuario,Contraseña,idPersona")] USUARIO_LOGIN uSUARIO_LOGIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO_LOGIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(db.Personas, "idPersona", "Cedula", uSUARIO_LOGIN.idPersona);
            ViewBag.idPersona = new SelectList(db.Personas, "idPersona", "Cedula", uSUARIO_LOGIN.idPersona);
            return View(uSUARIO_LOGIN);
        }

        // GET: USUARIO_LOGIN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(id);
            if (uSUARIO_LOGIN == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO_LOGIN);
        }

        // POST: USUARIO_LOGIN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(id);
            db.USUARIO_LOGIN.Remove(uSUARIO_LOGIN);
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
        public ActionResult Login()
        {
            if (Session["id"] == null)
            {
                Session["id"] = "0";
                return View();
            }
            else if (!Session["id"].ToString().Equals("0"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(String usuario, String contraseña)
        {
            if (usuario.IsNullOrWhiteSpace() | contraseña.IsNullOrWhiteSpace())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(m.USUARIO_LOGINL(usuario, contraseña));
            var result = 0;
            //Session["time"] = 0;
            //Session["fecha"] = 0;
            if (uSUARIO_LOGIN == null)
            {
                if (Session["time"] == null)
                {
                    Session["time"] = 1;
                }
                else { 
                    Session["time"] = (int) Session["time"] + 1;
                }
                if ((int) Session["time"] == 4)
                {
                    Session["fecha"] = DateTime.Now;
                }
                if (Session["fecha"] == null)
                {
                    result = 2;
                }
                else { 
                    var loginDate = (DateTime) Session["fecha"];
                    if ((int) Session["time"] > 3 && DateTime.Now < loginDate.AddMinutes(5))
                    {
                        result = 3;
                    }
                    else if ((int)Session["time"] > 3 && DateTime.Now > loginDate.AddMinutes(5))
                    {
                        Session["time"] = 0;
                        result = 2;
                    }
                    else {
                        result = 2;
                    }
                }
            }
            else
            {
                Session["id"] = uSUARIO_LOGIN.IdUsuario;
                Empleado empleado = db.Empleadoes.Find(m.BuscarEmpleadoU((int)Session["id"]));
                Session["idempleado"] = empleado.IdEmpleado;
                DetalleRole Rolesdetail = db.DetalleRoles.Find(m.BuscarRolU((int)Session["id"]));
                Session["Idroles"] = Rolesdetail.IdRoles;
                result = 1;
            }
            switch (result)
            {
                case 1:
                    return RedirectToAction("Index", "Home");
                case 2:
                    ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                    return View();
                case 3:
                    return View("Lockout");
                default:
                    return View();
            }



        }
        public ActionResult LogOff()
        {
            Session["id"] = 0;
            Session["idempleado"] = 0;
            Session["Idroles"] = 0;
            return RedirectToAction("Login", "Usuario_Login");

        }
    }
}
