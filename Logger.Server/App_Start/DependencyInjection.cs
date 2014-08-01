using System;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Logger.Core.Models.Abstract;
using Logger.Core.Models.Repos;

namespace Logger.Server
{
    public class DependencyInjection
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<BrowserRepository>().As<IBrowserRepository>().InstancePerHttpRequest();
            builder.RegisterType<OsRepository>().As<IOsRepository>().InstancePerDependency();
            builder.RegisterType<ErrorRepository>().As<IErrorRepository>().InstancePerHttpRequest();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}