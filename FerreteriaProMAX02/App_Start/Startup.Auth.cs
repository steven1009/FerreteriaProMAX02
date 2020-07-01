using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FerreteriaProMAX02
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {

                // YOUR LOGIN PATH
                LoginPath = new PathString("/Usuario_Login/Login")
                }
            );
        }
    }
}