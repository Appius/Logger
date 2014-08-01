using System;
using System.Web.Http;
using System.Web.Mvc;
using Logger.Core.Models.Abstract;

namespace Logger.Server.Controllers
{
    public abstract class BaseController : ApiController
    {
        public static IErrorRepository ErrorRepository
        {
            get { return DependencyResolver.Current.GetService<IErrorRepository>(); }
        }

        public static IBrowserRepository BrowserRepository
        {
            get { return DependencyResolver.Current.GetService<IBrowserRepository>(); }
        }

        public static IOsRepository OsRepository
        {
            get { return DependencyResolver.Current.GetService<IOsRepository>(); }
        }
    }
}