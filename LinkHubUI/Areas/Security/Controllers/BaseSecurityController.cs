using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security
{
    public class BaseSecurityController : Controller
    {
        protected  SecurityBs objbs;
        public BaseSecurityController()
        {
            objbs = new SecurityBs();
        }
	}
}