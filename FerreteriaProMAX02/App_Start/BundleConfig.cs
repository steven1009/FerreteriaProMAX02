using System.Web;
using System.Web.Optimization;

namespace FerreteriaProMAX02
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/morris.min.js",
                "~/Content/metisMenu.min.js",
                "~/Content/jquery.min.js",
                 "~/Content/jquery.js",
                 "~/Content/jquery.jquery.js",
                      "~/Content/jquery.jquery.min.js",
                   "~/Scripts/sb-admin-2.min.js",
                    "~/Scripts/alertify.min.js",
                        "~/Scripts/modernizr-2.8.3.min.js",
                        "~/Scripts/jquery-{version}.js"));




                         bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/scripts/jquery.validate.min.js",
                        "~/scripts//jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                "~/Content/sb-admin-2.min.css",
                   "~/Content/Site.css",
                "~/Content/sb-admin-2.css",
                "~/Content/alertify.core.css",
                 "~/Content/alertify.default.css",
               "~/Content/metisMenu.min.css",
                 "~/Content/font-awesome.min.css",
                      "~/Content/site.css"));
        }
    }
}
