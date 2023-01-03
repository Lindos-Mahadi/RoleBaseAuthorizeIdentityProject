using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoleBaseIdentiyProject.Startup))]
namespace RoleBaseIdentiyProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
