using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles="A")]
    public class CategoryController : BaseAdminController   
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Category ctgr)
        {                        
           try
            {
                if (ModelState.IsValid)
                {
                    objbs.categoryBs.Insert(ctgr);
                    TempData["Msg"] = "Create Successfully";
                    return RedirectToAction("Index");
                }
                else {
                    return RedirectToAction("Index");
                
                }
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Create Failed : " + ex.Message;
                return RedirectToAction("Index");
            }            
        }
	}
}