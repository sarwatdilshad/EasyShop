using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(EasyShop.App_code.OwinStartup))]

namespace EasyShop.App_code
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Pages/Account/SignIn.aspx")
            });
        }
    }
}
