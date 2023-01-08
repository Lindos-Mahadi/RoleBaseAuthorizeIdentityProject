using Autofac;
using Autofac.Integration.Mvc;
using RoleBaseIdentiyProject.Controllers;
using RoleBaseIdentiyProject.Models;
using RoleBaseIdentiyProject.Repository.Implementation;
using RoleBaseIdentiyProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RoleBaseIdentiyProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // AUTOFAC DEPENDANCY INJECTION
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<HomeController>().InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<ApplicationDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
