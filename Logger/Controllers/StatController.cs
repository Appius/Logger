using System;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logger.Core.Models;

using Logger.ViewModels;
using MvcPaging;

namespace Logger.Controllers
{
    public class StatController : BaseController
    {
        const int DefaultPageSize = 10;

        [Authorize]
        public ActionResult Index(int? page)
        {
            int siteid = 0;
            if (Session["siteid"] == null || !Int32.TryParse(Session["siteid"].ToString(), out siteid))
            {
                var action = Url.Action("Index");
                if (action != null)
                    return RedirectToAction("Index", "Site",
                        new {urlreferrer = action.ToString(CultureInfo.InvariantCulture)});
            }


            var pageSizeStr = Request.Cookies["isepam_stats_pagesize"];
            int pageSize = DefaultPageSize;
            if (pageSizeStr == null || !Int32.TryParse(pageSizeStr.Value, out pageSize))
            {
                var myCookie = new HttpCookie("isepam_stats_pagesize");
                myCookie.Value = DefaultPageSize.ToString(CultureInfo.InvariantCulture);
                myCookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(myCookie);
            }

            var currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            return View(ErrorRepository.GetAll(SiteRepository.Get(siteid).ApiKey)
                .Select(item => new ExceptionModel{Browser = item.Browser,BrowserId = item.BrowserId,DateTime = item.DateTime,Id=item.Id,Message = item.Message,Name = item.Name,OsId = item.OsId,OS = item.OS})
                .ToPagedList(currentPageIndex, pageSize));
        }

        [Authorize]
        public ActionResult ErrorDetail(int? id)
        {
            int siteid = 0;
            if (Session["siteid"] == null || !Int32.TryParse(Session["siteid"].ToString(), out siteid))
            {
                var action = Url.Action("Index");
                if (action != null)
                    return RedirectToAction("Index", "Site",
                        new { urlreferrer = action.ToString(CultureInfo.InvariantCulture) });
            }

            var site = SiteRepository.Get(siteid);
            var apikey = site==null ? string.Empty : site.ApiKey;

            if (id == null) id = 0;

            var error = ErrorRepository.Get(apikey, (Int32)id);
            if (error == null)
                ViewBag.NullId = id;
            var next = ErrorRepository.GetNext(apikey, id.Value);
            var prev = ErrorRepository.GetPrev(apikey, id.Value);
            if (Request.IsAjaxRequest())
                return PartialView("ErrorDetailTbl",
                                   new FailWithPager(error, prev == null ? 0 : prev.Id, next == null ? 0 : next.Id));
            return View(new FailWithPager(error, prev == null ? 0 : prev.Id, next == null ? 0 : next.Id));
        }
    }
}