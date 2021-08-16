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
    public class BienBanController : Controller
    {
        // GET: Administrator/BienBan
        QLVPHC dbPro = new QLVPHC();
        Repository.LoginDAO shopDAO = new Repository.LoginDAO();
        AdminDAO aDB = new AdminDAO();
        //
        // GET: /Administrator/Product/
        [HandleError]
        [HttpGet]
        public ActionResult Index(string error, string name, int page = 1, int pagesize = 4)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.ProError = error;
                var model = aDB.ListAll();
                //if (!string.IsNullOrEmpty(name))
                //{
                //    model = aDB.ListWhereAll(name, 2, 12);
                //}
                return View(model.ToPagedList(page, pagesize));
            }
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 4)
        {            
            var model = aDB.ListWhereAll(searchString, page, pagesize);
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
                ViewBag.nvpListCreate = new SelectList(dbPro.NguoiViPhams, "soCMND", "hoTen");
                ViewBag.typeListCreate = new SelectList(dbPro.MucPhats, "maLoi", "tenLoi");
                ViewBag.pdcListCreate = new SelectList(dbPro.NhanViens, "maSo", "hoTen");
                return View();
            }
        }

        [HandleError]
        [HttpPost]
        public ActionResult Create(ThongTinBienBan createPro)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {

                ViewBag.nvpListCreate = new SelectList(dbPro.NguoiViPhams, "soCMND", "hoTen");
                ViewBag.typeListCreate = new SelectList(dbPro.MucPhats, "maLoi", "tenLoi");
                ViewBag.pdcListCreate = new SelectList(dbPro.NhanViens, "maSo", "hoTen");
                var pro = dbPro.ThongTinBienBans.SingleOrDefault(c => c.maBienBan.Equals(createPro.maBienBan));

                try
                {
                    if (pro != null)
                    {
                        ViewBag.CreateProError = "Mã sản phẩm đã tồn tại.";
                    }
                    else
                    {
                        aDB.Insert(createPro);
                        ViewBag.CreateProError = "Thêm biên bản thành công.";
                        return RedirectToAction("Index", "BienBan");
                    }
                }
                catch (Exception)
                {
                    ViewBag.CreateProError = "Không thể thêm biên bản.";
                }
                return View();
            }
        }

        [HandleError]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ThongTinBienBan thongTinBienBan = dbPro.ThongTinBienBans.Find(id);
                ViewBag.nvpListCreate = new SelectList(dbPro.NguoiViPhams, "soCMND", "hoTen");
                ViewBag.typeListCreate = new SelectList(dbPro.MucPhats, "maLoi", "tenLoi");
                ViewBag.pdcListCreate = new SelectList(dbPro.NhanViens, "maSo", "hoTen");
                var result = aDB.Find(id);
                if (result != null)
                    return View(result);
                return View();
            }                                  
        }

        [HandleError]
        [HttpPost]
        public ActionResult Edit(ThongTinBienBan editPro)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.nvpListCreate = new SelectList(dbPro.NguoiViPhams, "soCMND", "hoTen");
                ViewBag.typeListCreate = new SelectList(dbPro.MucPhats, "maLoi", "tenLoi");
                ViewBag.pdcListCreate = new SelectList(dbPro.NhanViens, "maSo", "hoTen");

                try
                {
                    aDB.Edit(editPro);                
                    ViewBag.EditProError = "Cập nhật biên bản thành công.";
                    return RedirectToAction("Index", "BienBan");

                }
                catch (Exception)
                {
                    ViewBag.EditProError = "Không thể cập nhật biên bản.";
                }
                return View();
            }
        }

        [HandleError]
        public ActionResult Delete(string maBB)
        {
            var dao = new AdminDAO();
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var model = dbPro.ThongTinBienBans.SingleOrDefault(h => h.maBienBan.Equals(maBB));
                try
                {
                    if (model != null)
                    {
                        dao.Delete(maBB);
                        return RedirectToAction("Index", "BienBan", new { error = "Xoá biên bản thành công." });
                    }
                    else
                    {
                        return RedirectToAction("Index", "BienBan", new { error = "Biên bản không tồn tại." });
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "BienBan", new { error = "Không thể xoá biên bản." });
                }

            }
        }

        [HandleError]
        public ActionResult Details(string id)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var model = dbPro.ThongTinBienBans.Find(id);
                return View(model);
            }
        }

        [HandleError]
        public ActionResult XacNhan(string id)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                aDB.XacNhanBienLai(id);
                return RedirectToAction("Index", "BienLai");
            }
        }
    }
}