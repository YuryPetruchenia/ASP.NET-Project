using Data;
using DomainLogic.Model.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Client.App_Start
{
    public class AppUserManager : UserManager<ApplicationUser>
    {
        public AppUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static AppUserManager Create(
            IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(new UserStore<ApplicationUser>(context.Get<DataContext>()));

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 8,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            return manager;
        }
    }
}