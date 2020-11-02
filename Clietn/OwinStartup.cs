using System;
using System.Threading.Tasks;
using Client.App_Start;
using Clietn.App_Start;
using Data;
using DomainLogic.Model.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Client.OwinStartup))]

namespace Client
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new DataContext());
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            app.CreatePerOwinContext<RoleManager<ApplicationRole>>((options, context) =>
                new RoleManager<ApplicationRole>(
                    new RoleStore<ApplicationRole>(context.Get<DataContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}
