using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListUserController : BaseAdminController
    {
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            if (SortOrder == null) { SortOrder = "Asc"; }//Default SortOrder
            if (SortBy == null) { SortBy = "UserEmail"; }

            ViewBag.SortBy = SortBy;
            var Users = objbs.userBs.Getall();//.Where(x => x.IsApproved == "a");
            switch (SortOrder)
            {
                case "Asc":
                    switch (SortBy)
                    {
                        case "UserEmail": Users = Users.OrderBy(x => x.UserEmail).ToList(); break;
                        case "Role": Users = Users.OrderBy(x => x.Role).ToList(); break;
                        default: break;
                    }
                    ViewBag.SortOrder = "Desc";
                    break;
                case "Desc":
                    switch (SortBy)
                    {
                        case "UserEmail": Users = Users.OrderByDescending(x => x.UserEmail).ToList(); break;
                        case "Role": Users = Users.OrderByDescending(x => x.Role).ToList(); break;
                        default: break;
                    }
                    ViewBag.SortOrder = "Asc";
                    break;
                default:
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objbs.userBs.Getall().Count() / 10.0);//.Where(x => x.IsApproved == "a").Count() / 10.0);
            ViewBag.SortOrderStatic = SortOrder;
            int intPage = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = intPage;
            Users = Users.Skip((intPage - 1) * 10).Take(10);

            return View(Users);
        }
	}
}