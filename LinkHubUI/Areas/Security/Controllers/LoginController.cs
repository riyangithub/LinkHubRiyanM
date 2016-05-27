using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LinkHubUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseSecurityController
    {
        //
        // GET: /Security/Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(tbl_User tbuser)
        {
            try{
                if (Membership.ValidateUser(tbuser.UserEmail, tbuser.Password)) {
                    FormsAuthentication.SetAuthCookie(tbuser.UserEmail, false);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }
                else
                {
                    TempData["Msg"] = "Login Failed";
                    return RedirectToAction("Index");
                }            
            }catch(Exception ex){
                TempData["Msg"]="Login Error : "+ ex.Message;
                return RedirectToAction("Index");
            }
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
	}
}