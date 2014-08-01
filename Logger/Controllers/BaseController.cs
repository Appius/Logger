using System;
using System.Web.Mvc;
using Logger.Core.Models.Abstract;
using Logger.Filters;

namespace Logger.Controllers
{
    [InitializeSimpleMembership]
    public abstract class BaseController : Controller
    {
        private readonly Lazy<IErrorRepository> _lazyErrorRepository =
            new Lazy<IErrorRepository>(() => DependencyResolver.Current.GetService<IErrorRepository>());

        private readonly Lazy<ISiteRepository> _lazySiteRepository =
            new Lazy<ISiteRepository>(() => DependencyResolver.Current.GetService<ISiteRepository>());

        private readonly Lazy<IUserRepository> _lazyUserRepository =
            new Lazy<IUserRepository>(() => DependencyResolver.Current.GetService<IUserRepository>());

        public IErrorRepository ErrorRepository
        {
            get { return _lazyErrorRepository.Value; }
        }

        public ISiteRepository SiteRepository
        {
            get { return _lazySiteRepository.Value; }
        }

        public IUserRepository UserRepository
        {
            get { return _lazyUserRepository.Value; }
        }
    }
}