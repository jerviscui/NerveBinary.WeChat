using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using DataService;
using System.Reflection;
using System.Web.Optimization;
using Autofac.Core;
using Web.Infrastructure;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.Config(BundleTable.Bundles);

            DependencyRegister.Register();
            ObjectMapper.ConfigMapper();

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFDbContext>());
        }
    }
}
