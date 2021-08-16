using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;
using ModelEF.Model;
using ModelEF.DAO;

namespace DoAn.Areas.Client.Controllers
{
    public class SanPhamController : Controller
    {
        QLVPHC db = new QLVPHC();
        // GET: Shopper/Products
        //hiển thị sản phẩm theo  loại
        AdminDAO uDB = new AdminDAO();

        //Hiển thị biên bản theo biển số xe
        public ActionResult BienBanTheoBienSoXe(string name, int? page)
        {
            ViewBag.search = name;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(uDB.TimBienBan(name).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult BienBanTheoSoCMND(string cmnd, int? page)
        {
            ViewBag.searchcmnd = cmnd;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(uDB.TimBienBanCMND(cmnd).ToPagedList(pageNumber, pageSize));
        }
    }
}