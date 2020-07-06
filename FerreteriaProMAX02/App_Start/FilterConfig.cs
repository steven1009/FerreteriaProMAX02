using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FerreteriaProMAX02
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

        }
        public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
        {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                    || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                {
                    // Don't check for authorization as AllowAnonymous filter is applied to the action or controller
                    return;
                }

                // Check for authorization
                if (HttpContext.Current.Session["id"] == null || HttpContext.Current.Session["id"].ToString().Equals("0"))
                {
                    filterContext.Result = new RedirectToRouteResult(
            new RouteValueDictionary {{ "Controller", "Usuario_login" },
                                      { "Action", "Login" } });
                }
            }
        }
    }
}
