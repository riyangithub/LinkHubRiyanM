using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
     [Authorize(Roles = "A,U")]
    public class URLController : BaseUserAreaController
    {
        public ActionResult Index()
        {            
           ViewBag.CategoryId = new SelectList(ObjBs.categoryBs.Getall().ToList(), "CategoryId", "CategoryName");
           ViewBag.UserId = new SelectList(ObjBs.userBs.Getall().ToList(), "UserId", "UserEmail");
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Url obj_url) {
            try {
                if (ModelState.IsValid)
                {
                    obj_url.IsApproved = "P";
                    obj_url.UserId = ObjBs.userBs.Getall().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;

                    ObjBs.urlBs.Insert(obj_url);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else {
                    ViewBag.CategoryId = new SelectList(ObjBs.categoryBs.Getall().ToList(), "CategoryId", "CategoryName");
                    ViewBag.UserId = new SelectList(ObjBs.userBs.Getall().ToList(), "UserId", "UserEmail");
                    return View("Index");
                }
            }catch (Exception ex){
                TempData["Msg"] = "Created Failed : "+ ex.Message;
                return RedirectToAction("Index");
            }
        }
	}
}