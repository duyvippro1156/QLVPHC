using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;
using ModelEF.DAO;
using PagedList;

namespace DoAn.Areas.Administrator.Controllers
{
    public class NguoiViPhamController : Controller
    {
        QLVPHC dbType = new QLVPHC();
        AdminDAO aDB = new AdminDAO();       
        // GET: /Administrator/ProductType/
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
                var model = aDB.LayDSNguoiViPham();                
                return View(model.ToPagedList(page, pagesize));
            }
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {            
            var model = aDB.ListWhereNVP(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        [HandleError]
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {             
                return View();
            }
        }

        [HandleError]
        [HttpPost]
        public ActionResult Create(NguoiViPham createNVP)
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
                        aDB.InsertNVP(createNVP);
                        ViewBag.CreateTypeError = "Thêm người vi phạm thành công.";
                        return RedirectToAction("Index", "NguoiViPham");
                    }
                }
                catch (Exception)
                {
                    ViewBag.CreateTypeError = "Không thể thêm người vi phạm.";
                }
                return View();
            }
        }

        [HandleError]
        [HttpGet]
        public ActionResult Edit(string cmnd)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {              
                return View(dbType.NguoiViPhams.SingleOrDefault(e => e.soCMND.Equals(cmnd)));
            }
        }

        [HandleError]
        [HttpPost]
        public ActionResult Edit(NguoiViPham editNVP)
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
                        aDB.SuaNguoiViPham(editNVP);
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

        [HandleError]
        public ActionResult Delete(string cmnd)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var model = dbType.NguoiViPhams.SingleOrDefault(h => h.soCMND.Equals(cmnd));
                try
                {
                    if (model != null)
                    {
                        aDB.DeleteNVP(cmnd);                        
                        return RedirectToAction("Index", "NguoiViPham", new { error = "Xoá người vi phạm thành công." });
                    }
                    else
                    {
                        return RedirectToAction("Index", "NguoiViPham", new { error = "Người vi phạm không tồn tại." });
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "NguoiViPham", new { error = "Không thể xoá người vi phạm." });
                }
            }
        }
    }
}