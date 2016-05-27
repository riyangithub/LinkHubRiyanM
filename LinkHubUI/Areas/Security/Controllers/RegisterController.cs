using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class RegisterController : BaseSecurityController
    {
        //
        // GET: /Security/Register/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_User usrx)
        {
            try {
                if (ModelState.IsValid)
                {
                    usrx.Role = "U";
                    objbs.userBs.Insert(usrx);
                    TempData["Msg"] = "Create Successfully";
                    return RedirectToAction("Index");
                }
                else { 
                    return View("Index");
                }

            }
            catch(Exception ex){
                TempData["Msg"] = "Create Failed : " + ex.Message;
               return  RedirectToAction("Index");
            }            
            
        }


	}
}