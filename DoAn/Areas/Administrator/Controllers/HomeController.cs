using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;

namespace DoAn.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        QLVPHC db = new QLVPHC();
        Repository.LoginDAO dao = new Repository.LoginDAO();
        [HandleError]
        public ActionResult Index()
        {
            if (Session["accname"]==null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {              
                return View();
            }
        }
	}
}