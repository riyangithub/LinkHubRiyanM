using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListCategoryController : BaseAdminController
    {
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            if (SortOrder == null) { SortOrder = "Asc"; }//Default SortOrder
            if (SortBy == null) { SortBy = "CategoryName"; }

            ViewBag.SortBy = SortBy;
            var Categories = objbs.categoryBs.Getall();//.Where(x => x.IsApproved == "a");
            switch (SortOrder)
            {
                case "Asc":
                    switch (SortBy)
                    {
                        case "CategoryName": Categories = Categories.OrderBy(x => x.CategoryName).ToList(); break;
                        case "CategoryDesc": Categories = Categories.OrderBy(x => x.CategoryDesc).ToList(); break;
                        default: break;
                    }
                    ViewBag.SortOrder = "Desc";
                    break;
                case "Desc":
                    switch (SortBy)
                    {
                        case "CategoryName": Categories = Categories.OrderByDescending(x => x.CategoryName).ToList(); break;
                        case "CategoryDesc": Categories = Categories.OrderByDescending(x => x.CategoryDesc).ToList(); break;
                        default: break;
                    }
                    ViewBag.SortOrder = "Asc";
                    break;
                default:
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objbs.categoryBs.Getall().Count() / 10.0);//.Where(x => x.IsApproved == "a").Count() / 10.0);
            ViewBag.SortOrderStatic = SortOrder;
            int intPage = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = intPage;
            Categories = Categories.Skip((intPage - 1) * 10).Take(10);

            return View(Categories);
        }

        public ActionResult Delete(int id) {
            try {
                objbs.categoryBs.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }catch(Exception ex){
                TempData["Msg"] = "Deleted Failed : "+ ex.Message;
                return RedirectToAction("Index");
            }
        }
	}
}