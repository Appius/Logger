using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Logger.Core.Models;

namespace Logger.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Сontact page";
            ViewBag.Title = "Contact page";

            return View();
        }

        public ActionResult Help()
        {
            return View();
        }
    }
}