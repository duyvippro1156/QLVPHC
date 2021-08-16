using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;

namespace DoAn.Areas.Administrator.Controllers
{
    public class AccountController : Controller
    {
        QLVPHC dbLog = new QLVPHC();
        Repository.LoginDAO dao = new Repository.LoginDAO();
        // GET: Administrator/Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Login(TaiKhoan adLogin)
        {
            try
            {
                var model = dbLog.TaiKhoans.SingleOrDefault(a => a.tenTaiKhoan.Equals(adLogin.tenTaiKhoan));
                if (model != null)
                {
                    if (model.matKhau.Equals(dao.Encrypt(adLogin.matKhau)))
                    {
                        Session["accname"]= model.tenTaiKhoan;                        
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Session["accname"] = null;
                        ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
                    }
                }
                else
                {
                    Session["accname"] = null;
                    ViewBag.LoginError="Sai tài khoản hoặc mật khẩu.";
                }
            }
            catch (Exception)
            {
                Session["accname"] = null;
                ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
            }
            return View();
        }

        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session["accname"] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}