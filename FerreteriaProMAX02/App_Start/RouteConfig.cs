using System.Web.Mvc;
using System.Web.Routing;

namespace FerreteriaProMAX02
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "USUARIO_LOGIN", action = "Login", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                     name: "Login",
                     url: "{controller}/{action}/{id}",
                     defaults: new { controller = "USUARIO_LOGIN", action = "Login", id = UrlParameter.Optional }
                 );
                routes.MapRoute(
                    name: "Cargos",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Cargoes", action = "Index", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "CargosAdd",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Cargoes", action = "Crete", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "Categoria",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Categorias", action = "Index", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "CategoriaAdd",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Categorias", action = "Create", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "Empleado",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Empleadoes", action = "Index", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "EmpleadoAdd",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Empleadoes", action = "Create", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "Facturas",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Facturas", action = "Index", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "FacturasAdd",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Facturas", action = "Create", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "Marcas",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Marcas", action = "Index", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "MarcasAdd",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Marcas", action = "Create", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "Personas",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Personas", action = "Index", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "PersonasAdd",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Personas", action = "Create", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "Proveedores",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Proveedores", action = "Index", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "ProveedoresAdd",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Proveedores", action = "Create", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "Producto",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Productoes", action = "Index", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "ProductoAdd",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Productoes", action = "Create", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "Roles",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Roles", action = "Index", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "RolesAdd",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Roles", action = "Create", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "TipoPago",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "TipoPagoes", action = "Index", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "TipoPagoAdd",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "TipoPagoes", action = "Create", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "Usuario_Login",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Usuario_Login", action = "Index", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "Ventas",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Ventas", action = "Index", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "VentasaAdd",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Ventas", action = "Create", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "VentasN",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Ventas", action = "VentaN", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "VentasaOC",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Ventas", action = "ObtenerClientes", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "Inicio",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "DetailsVentas",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "DetalleVentas", action = "DetailsVentas", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "ComprasaAdd",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "CompraProdProvs", action = "Create", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "ComprasN",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "CompraProdProvs", action = "CompraN", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                    name: "ComprasOC",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "CompraProdProvs", action = "ObtenerProveedores", id = UrlParameter.Optional }
                );
                routes.MapRoute(
                name: "Salir",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Usuario_Login", action = "LogOff", id = UrlParameter.Optional }
                );

            }
        }
    }
}