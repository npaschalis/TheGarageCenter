using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Stripe;
using System.Configuration;
using TheGarageCenter.Models;

[assembly: OwinStartupAttribute(typeof(TheGarageCenter.Startup))]
namespace TheGarageCenter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRoles();
        }

        private void createRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);

                role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Dealer";
                roleManager.Create(role);
            }

        }
    }
}
