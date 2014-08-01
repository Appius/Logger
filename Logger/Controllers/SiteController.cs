using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using Logger.App_GlobalResources;
using Logger.Core.Models.Tables;
using Logger.ViewModels;
using MvcPaging;
using WebMatrix.WebData;

namespace Logger.Controllers
{
    public class SiteController : BaseController
    {
        [Authorize]
        public ActionResult Index(int? page, int? nid, string urlreferrer, int pageSize = 10)
        {
            if (nid != null)
            {
                int id = nid.Value;
                //Session["id"] = id;
                ViewBag.CurrentSite = id;

                var firstOrDefault = SiteRepository.Get(id);
                if (firstOrDefault != null)
                {
                    Session["sitename"] = firstOrDefault.Name;
                    Session["siteid"] = firstOrDefault.Id;
                }
                if (!String.IsNullOrEmpty(urlreferrer))
                    return Redirect(urlreferrer);
            }
            var currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            IEnumerable<Site> sites;
            if (User.IsInRole("User"))
                sites = SiteRepository.GetAllByUserId(WebSecurity.CurrentUserId);
            else
                sites = SiteRepository.GetAll();

            return View(sites.ToPagedList(currentPageIndex, pageSize));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Users(int? page, int pageSize = 10)
        {
            var currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            var users = UserRepository.GetAll();
            return View(users.ToPagedList(currentPageIndex, pageSize));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult LockUser(string u, string act)
        {
            var userName = Membership.GetUser(u);
            switch (act)
            {
                case "lock":
                    if (u != User.Identity.Name)
                        if (userName != null) userName.IsApproved = false;
                    if (userName != null) Membership.UpdateUser(userName);
                    break;

                case "unlock":
                    if (userName != null)
                    {
                        userName.IsApproved = true;
                        Membership.UpdateUser(userName);
                    }
                    break;
            }
            return Content("OK");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GiveAdmin(string u, string act)
        {
            switch (act)
            {
                case "giveadmin":
                    Roles.AddUserToRole(u, "Admin");
                    break;

                case "revokeadmin":
                    if (u != User.Identity.Name) Roles.RemoveUserFromRole(u, "Admin");
                    break;
            }
            return Content("OK");
        }

        [Authorize(Roles = "user, admin")]
        public ActionResult AddSite()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "user, admin")]
        public ActionResult AddSite(AddSiteModel model)
        {
            if (ModelState.IsValid)
            {
                var key = Guid.NewGuid().ToString("N");
                int code = SiteRepository.Add(new Site
                {
                    ApiKey = key,
                    Name = model.Name,
                    Description = model.Description,
                    IsBlocked = false,
                    UserId = WebSecurity.CurrentUserId,
                    Url = model.Url
                });

                if (code < 1)
                {
                    ModelState.AddModelError("", Resources.UnknownError);
                    return View(model);
                }
                return RedirectToAction("Index", "Site");
            }
            ModelState.AddModelError("", Resources.IncorrectParams);
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult DelSite(int id)
        {
            return Content(SiteRepository.Remove(id) == 1 ? "OK" : "ERR");
        }

        [Authorize(Roles = "admin")]
        public ActionResult ToggleSite(int? id)
        {
            var code = -1;
            if (id.HasValue)
                code = SiteRepository.Toggle(new Site {Id = id.Value});
            return Content(code == 1 ? "OK" : "ERR");
        }
    }
}