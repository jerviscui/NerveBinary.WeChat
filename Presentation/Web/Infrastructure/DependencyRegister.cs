using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using DataService;
using WebService;

namespace Web.Infrastructure
{
    public class DependencyRegister
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetAssembly(typeof(MvcApplication)));

            builder.RegisterType<EFDbContext>().As<IDbContext>().InstancePerRequest();
            builder.RegisterGeneric(typeof (Repository<>)).As(typeof (IRepository<>)).InstancePerRequest();

            builder.RegisterType<SubjectInfoService>().As<ISubjectInfoService>().InstancePerRequest();
            builder.RegisterType<SubjectOptionService>().As<ISubjectOptionService>().InstancePerRequest();
            builder.RegisterType<SubjectResultService>().As<ISubjectResultService>().InstancePerRequest();
            builder.RegisterType<PictureService>().As<IPictureService>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}