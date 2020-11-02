using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Client.App_Start;
using Clietn.App_Start;
using DomainLogic.Model.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Clietn.Controllers
{
    public partial class AccountController : Controller
    {
        [HttpGet]
        public virtual ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public virtual ActionResult Login(string userName, string password, string returnUrl)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            ApplicationUser user = userManager.Find(userName, password);
            if (user != null)
            {
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction(MVC.Track.IMusic());
            }

            return View();
        }

        [HttpGet]
        public virtual ActionResult Register(string src)
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Register(string email, string password)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

            var user = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };
            userManager.Create(user, password);

            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<ApplicationRole>>();
            const string roleName = "Subscription";
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new ApplicationRole { Name = roleName });
            }

            var newUserDb = userManager.Find(email, password);
            userManager.AddToRole(newUserDb.Id, roleName);

            return RedirectToAction(MVC.Track.IMusic());
        }

        public virtual ActionResult logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction(MVC.Track.IMusic());
        }
    }
}
