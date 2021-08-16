using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.Administrator.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Administrator/Profile
        QLVPHC dbType = new QLVPHC();
        AdminDAO aDB = new AdminDAO();
        //
        // GET: /Administrator/ProductType/
        [HandleError]
        public ActionResult Index(string taikhoan)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var model = aDB.XemThongTinCaNhan(taikhoan).SingleOrDefault();
                return View(model);
            }
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