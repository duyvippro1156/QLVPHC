using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace DoAn.Areas.Client.Controllers
{
    public class HomeController : Controller
    {
        // GET: Client/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}