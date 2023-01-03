using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using RoleBaseIdentiyProject.Models;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(RoleBaseIdentiyProject.Startup))]
namespace RoleBaseIdentiyProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // THis runs whenever application first start
            PopulateUserRole();
        }

        private void PopulateUserRole()
        {
            // populate users and assign roles to user
            var db = new ApplicationDbContext();

            // populate roles
            if (!db.Roles.Any(x => x.Name == RoleName.RoleAdmin))
            {
                db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(RoleName.RoleAdmin));
                db.SaveChanges();
            }
            if (!db.Roles.Any(x => x.Name == RoleName.RoleUser))
            {
                db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(RoleName.RoleUser));
                db.SaveChanges();
            }

            // populate user
            if (!db.Users.Any(x => x.UserName == "admin"))
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new ApplicationUserManager(userStore);

                var roleStore = new RoleStore<IdentityRole>(db);
                var roleManager = new RoleManager<IdentityRole>(roleStore);


                var newUser = new ApplicationUser
                {
                    Email = "admin@test.com",
                    UserName = "admin"
                };

                userManager.Create(newUser, "admin123");
                userManager.AddToRole(newUser.Id, RoleName.RoleAdmin);
                db.SaveChanges();

            }

            if (!db.Users.Any(x => x.UserName == "user"))
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new ApplicationUserManager(userStore);

                var roleStore = new RoleStore<IdentityRole>(db);
                var roleManager = new RoleManager<IdentityRole>(roleStore);


                var newUser = new ApplicationUser
                {
                    Email = "user@test.com",
                    UserName = "user"
                };

                userManager.Create(newUser, "user123");
                userManager.AddToRole(newUser.Id, RoleName.RoleUser);
                db.SaveChanges();

            }
        }
    }
}
