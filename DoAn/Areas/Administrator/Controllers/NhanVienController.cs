using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Administrator.Controllers
{
    public class NhanVienController : Controller
    {
        QLVPHC dbType = new QLVPHC();
        AdminDAO aDB = new AdminDAO();
        //
        // GET: /Administrator//
        [HandleError]
        [HttpGet]
        public ActionResult Index(string error, string cmnd, int page = 1, int pagesize = 15)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.ProError = error;
                var model = aDB.layDSNhanVien();
                return View(model.ToPagedList(page, pagesize));
            }
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var model = aDB.ListWhereNV(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        public ActionResult Details(int id)
        {
            var dt = dbType.NhanViens.Find(id);
            return View(dt);
        }

        [HandleError]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View(dbType.NhanViens.SingleOrDefault(e => e.maSo.Equals(id)));
            }
        }

        [HandleError]
        [HttpPost]
        public ActionResult Edit(NhanVien editNV)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        aDB.SuaThongTinCaNhan(editNV);
                        ViewBag.EditTypeError = "Cập nhật người vi phạm thành công.";
                    }
                }
                catch (Exception)
                {
                    ViewBag.EditTypeError = "Không thể cập nhật người vi phạm.";
                }
                return View();
            }
        }
    }
}