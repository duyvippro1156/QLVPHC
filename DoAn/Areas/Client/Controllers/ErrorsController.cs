using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Client.Controllers
{
    public class ErrorsController : Controller
    {
        //
        // GET: /Errors/
        [HandleError]
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
	}
}