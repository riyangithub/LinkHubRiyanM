using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ApproveURLsController : BaseAdminController
    {
        public ActionResult Index(string Status)
        {
            Status =Status == null ? "P" : Status;
            ViewBag.Status = Status;
            var urls = objbs.urlBs.Getall().Where(x => x.IsApproved == Status).ToList(); 
            return View(urls);
        }
        public ActionResult Approve(int id) {
            try { 
                var Myurl = objbs.urlBs.GetById(id);
                Myurl.IsApproved = "A";
                objbs.urlBs.Update(Myurl);
                TempData["Msg"] = "Approve Successfully";
                return RedirectToAction("Index");
            }catch(Exception ex){
                TempData["Msg"] = "Approve Failed : " + ex.Message;
                return RedirectToAction("Index");
            }
        }
        public ActionResult Reject(int id)
        {
            try
            {
                var Myurl = objbs.urlBs.GetById(id);
                Myurl.IsApproved = "R";
                objbs.urlBs.Update(Myurl);
                TempData["Msg"] = "Reject Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Reject Failed : " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult ApproveOrRejectAll(List<int> Ids, string Status, string CurrentStatus)
        {
            try 
            {
                objbs.ApproveOrReject(Ids, Status);
                TempData["Msg"] = "Operation Successfully";
                var urls = objbs.urlBs.Getall().Where(x => x.IsApproved == CurrentStatus).ToList();
                return PartialView("pv_ApproveURLs",urls);

            }
            catch(Exception ex)
            {
                TempData["Msg"] = "Operation Failed : " + ex.Message;
                var urls = objbs.urlBs.Getall().Where(x => x.IsApproved == CurrentStatus).ToList();
                return PartialView("pv_ApproveURLs", urls);

            }            
        }
	}
}