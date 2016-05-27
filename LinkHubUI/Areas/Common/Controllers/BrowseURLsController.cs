using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class BrowseURLsController : BaseCommonController
    {

        public ActionResult Index(string SortOrder, string SortBy,string Page)
        {
            if (SortOrder == null) { SortOrder = "Asc"; }//Default SortOrder
            if (SortBy== null) { SortBy= "Title"; }

            ViewBag.SortBy = SortBy;
            var urls = objbs.urlBs.Getall().Where(x => x.IsApproved == "A");
            switch(SortOrder){
                case "Asc":
                    switch (SortBy) { 
                        case "Title":urls = urls.OrderBy(x => x.UrlTitle).ToList();break;
                        case "Url":urls = urls.OrderBy(x => x.Url).ToList();break;
                        case "UrlDesc":urls = urls.OrderBy(x => x.UrlDesc).ToList();break;
                        case "CategoryName":urls = urls.OrderBy(x => x.UrlDesc).ToList();break;
                        default:break;}                    
                    ViewBag.SortOrder = "Desc";
                    break;
                case "Desc" :
                    switch (SortBy){
                        case "Title": urls = urls.OrderByDescending(x => x.UrlTitle).ToList(); break;
                        case "Url": urls = urls.OrderByDescending(x => x.Url).ToList(); break;
                        case "UrlDesc": urls = urls.OrderByDescending(x => x.UrlDesc).ToList(); break;
                        case "CategoryName": urls = urls.OrderByDescending(x => x.UrlDesc).ToList(); break;
                        default: break;}
                    ViewBag.SortOrder = "Asc";
                    break;
                default:
                    break;}
            ViewBag.TotalPages = Math.Ceiling(objbs.urlBs.Getall().Where(x => x.IsApproved == "A").Count() / 10.0);
            ViewBag.SortOrderStatic = SortOrder;
            int intPage=int.Parse(Page==null?"1":Page);
            ViewBag.Page = intPage;
            urls = urls.Skip((intPage - 1) * 10).Take(10);

            return View(urls);
        }
	}
}