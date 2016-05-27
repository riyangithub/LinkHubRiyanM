using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class QuickURLSubmitController : BaseCommonController
    {
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objbs.categoryBs.Getall().ToList(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Create (QuickURLSubmitModel myQuickURL)
        {
            try 
            {
                ModelState.Remove("MyUser.Password");
                ModelState.Remove("MyUser.ConfirmPassword");
                ModelState.Remove("MyUrl.UrlDesc");
                if (ModelState.IsValid)
                {
                    objbs.InsertQuickURL(myQuickURL);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else {
                    ViewBag.CategoryId = new SelectList(objbs.categoryBs.Getall().ToList(),"CategoryId","CategoryName");
                    return View("Index");
                }            
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Created Failed : "+ ex.Message;
                return RedirectToAction("Index");
            }

        }
	}
}