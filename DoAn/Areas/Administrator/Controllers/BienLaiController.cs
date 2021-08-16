using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace DoAn.Areas.Administrator.Controllers
{
    public class BienLaiController : Controller
    {
        // GET: Administrator/BienLai
        QLVPHC dbPro = new QLVPHC();        
        AdminDAO aDB = new AdminDAO();
        //
        // GET: /Administrator/Product/
        [HandleError]
        public ActionResult Index(string error, string name, int page = 1, int pagesize = 15)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.ProError = error;
                var model = aDB.LayBienLai();
                return View(model.ToPagedList(page, pagesize));
            }
        }
      
    
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 4)
        {
            var model = aDB.TimBienLai(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        

        [HandleError]
        public ActionResult Delete(int id)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var model = dbPro.TTBienLais.SingleOrDefault(h => h.maBienLai.Equals(id));
                try
                {
                    if (model != null)
                    {
                        aDB.DeleteBL(id);
                        return RedirectToAction("Index", "BienLai", new { error = "Xoá biên lai thành công." });
                    }
                    else
                    {
                        return RedirectToAction("Index", "BienLai", new { error = "Biên lai không tồn tại." });
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "BienLai", new { error = "Không thể xoá biên lai." });
                }

            }
        }

        [HandleError]
        public ActionResult BaoCao(int id)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var dt = dbPro.TTBienLais.Find(id);
                return View(dt);
            }
        }
    }
}