using EbookRentalShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EbookRentalShop.Startup))]
namespace EbookRentalShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AddUsersAndRoles();
        }
		private void AddUsersAndRoles()
		{
			ApplicationDbContext context = new ApplicationDbContext();
			var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
			var usermanager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
			if (!rolemanager.RoleExists("SuperAdmin"))
			{
				//Create Default Role
				var role = new IdentityRole("SuperAdmin");
				rolemanager.Create(role);

				//Create Default Users
				var user = new ApplicationUser();
				user.UserName = "admin@mail.com";
				user.Email = "admin@mail.com";
				string pwd = "Haslo!23";
				var newuser = usermanager.Create(user, pwd);
				if (newuser.Succeeded)
				{
					usermanager.AddToRole(user.Id, "SuperAdmin");
				}
			}
			else
			{
				//var role = roleManager.FindByName("SuperAdmin");
				//roleManager.Delete(role);
				var user = usermanager.FindByName("admin@mail.com");
				//userManager.Delete(user);
				usermanager.AddToRole(user.Id, "SuperAdmin");
			}
		}
	}
}
