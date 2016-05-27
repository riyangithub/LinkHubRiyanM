using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
   
    public class BaseUserAreaController : Controller
    {
        protected SecurityBs ObjBs;
        public BaseUserAreaController()
        { 
            ObjBs=new SecurityBs();
        }
	}
}