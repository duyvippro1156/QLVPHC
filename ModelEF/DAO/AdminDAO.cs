using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;

namespace ModelEF.DAO
{
    public class AdminDAO
    {
        public static string cn = @"Data Source=XUANDUY\SQLEXPRESS;initial catalog=ViPhamHanhChinh;Integrated Security=True";
        SqlConnection conn = new SqlConnection(cn);
        QLVPHC context = new QLVPHC();

        #region Thao tác bảng thông tin biên bản
        //public List<ThongTinBienBan> LayTTBienBan()
        //{
        //    var data = context.ThongTinBienBans.SqlQuery("[dbo].[LayTTBienBan]").ToList();
        //    return data;
        //}

        public List<ThongTinBienBan> ListAll()
        {
            return context.ThongTinBienBans.ToList();
        }

        public IEnumerable<ThongTinBienBan> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<ThongTinBienBan> model = context.ThongTinBienBans;
            if (!string.IsNullOrEmpty(keysearch))
                model = model.Where(x => x.soCMND.Contains(keysearch));
            return model.OrderBy(x => x.soCMND).ToPagedList(page, pagesize);
        }

        //public List<ThongTinBienBan> TimBienBan(string bienSoXe)
        //{
        //    var data = context.ThongTinBienBans.SqlQuery("[dbo].[TimBienBan] @bienSoXe", new SqlParameter("bienSoXe", bienSoXe)).ToList();
        //    return data;
        //}
        public List<ThongTinBienBan> XemChiTietBienBan(string id)
        {
            var data = context.ThongTinBienBans.SqlQuery("[dbo].[XemChiTietBienBan] @maBienBan", new SqlParameter("maBienBan", id)).ToList();
            return data;
        }

        public void ThemTTBienBan(ThongTinBienBan dM)
        {
            SqlCommand com = new SqlCommand("ThemTTBienBan", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@maBienBan", dM.maBienBan);
            com.Parameters.AddWithValue("@soCMND", dM.soCMND);
            com.Parameters.AddWithValue("@bienSoXe", dM.bienSoXe);
            com.Parameters.AddWithValue("@giayPhepLaiXe", dM.giayPhepLaiXe);
            com.Parameters.AddWithValue("@maLoiViPham", dM.maLoiViPham);
            com.Parameters.AddWithValue("@diaDiemViPham", dM.diaDiemViPham);
            com.Parameters.AddWithValue("@ngayViPham", dM.ngayViPham);
            com.Parameters.AddWithValue("@maThanhTra", dM.maThanhTra);           
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
        public void SuaTTBienBan(ThongTinBienBan dM)
        {
            SqlCommand com = new SqlCommand("SuaTTBienBan", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@maBienBan", dM.maBienBan);
            com.Parameters.AddWithValue("@soCMND", dM.soCMND);
            com.Parameters.AddWithValue("@bienSoXe", dM.bienSoXe);
            com.Parameters.AddWithValue("@giayPhepLaiXe", dM.giayPhepLaiXe);
            com.Parameters.AddWithValue("@maLoiViPham", dM.maLoiViPham);
            com.Parameters.AddWithValue("@diaDiemViPham", dM.diaDiemViPham);
            com.Parameters.AddWithValue("@ngayViPham", dM.ngayViPham);
            com.Parameters.AddWithValue("@maThanhTra", dM.maThanhTra);        
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
        public void XoaTTBienBan(string maBienBan)
        {
            SqlCommand com = new SqlCommand("XoaTTBienBan", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@maBienBan", maBienBan);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
        public string Insert(ThongTinBienBan entity)
        {
            var sp = Find(entity.maBienBan);
            if (sp == null)
            {
                context.ThongTinBienBans.Add(entity);
            }
            else
            {
                sp.maBienBan = entity.maBienBan;
            }
            context.SaveChanges();
            return entity.maBienBan.ToString();
        }

        public ThongTinBienBan Find(string id)
        {
            return context.ThongTinBienBans.Find(id);
        }

        public string Edit(ThongTinBienBan entity)
        {
            var sp = Find(entity.maBienBan);
            if (sp == null)
            {
                context.ThongTinBienBans.Add(entity);
            }
            else
            {
                sp.maBienBan = entity.maBienBan;
                sp.NguoiViPham = entity.NguoiViPham;
                sp.bienSoXe = entity.bienSoXe;
                sp.giayPhepLaiXe = entity.giayPhepLaiXe;
                sp.maLoiViPham = entity.maLoiViPham;
                sp.diaDiemViPham = entity.diaDiemViPham;
                sp.ngayViPham = entity.ngayViPham;
                sp.maThanhTra = entity.maThanhTra;
                sp.tangVatTamGiu = entity.tangVatTamGiu;
            }
            context.SaveChanges();
            return entity.maBienBan.ToString();
        }

        public bool Delete(string id)
        {
            try
            {
                var sp = context.ThongTinBienBans.Find(id);
                context.ThongTinBienBans.Remove(sp);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Thao tác bảng người vi phạm
        public List<NguoiViPham> LayDSNguoiViPham()
        {
            return context.NguoiViPhams.ToList();
            //var data = context.NguoiViPhams.SqlQuery("[dbo].[LayNguoiViPham]").ToList();
            //return data;
        }

        public IEnumerable<NguoiViPham> ListWhereNVP(string keysearch, int page, int pagesize)
        {
            IQueryable<NguoiViPham> model = context.NguoiViPhams;
            if (!string.IsNullOrEmpty(keysearch))
                model = model.Where(x => x.soCMND.Contains(keysearch));
            return model.OrderBy(x => x.soCMND).ToPagedList(page, pagesize);
        }

        public string InsertNVP(NguoiViPham entity)
        {
            var sp = FindNVP(entity.soCMND);
            if (sp == null)
            {
                context.NguoiViPhams.Add(entity);
            }
            else
            {
                sp.soCMND = entity.soCMND;
            }
            context.SaveChanges();
            return entity.soCMND.ToString();
        }

        public ThongTinBienBan FindNVP(string id)
        {
            return context.ThongTinBienBans.Find(id);
        }

        public bool DeleteNVP(string id)
        {
            try
            {
                var sp = context.NguoiViPhams.Find(id);
                context.NguoiViPhams.Remove(sp);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
  
        public void SuaNguoiViPham(NguoiViPham nguoiViPham)
        {
            SqlCommand com = new SqlCommand("SuaNguoiViPham", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CMND", nguoiViPham.soCMND);
            com.Parameters.AddWithValue("@hoTen", nguoiViPham.hoTen);
            com.Parameters.AddWithValue("@gioiTinh", nguoiViPham.gioiTinh);
            com.Parameters.AddWithValue("@ngaySinh", nguoiViPham.ngaySinh);
            com.Parameters.AddWithValue("@sdt", nguoiViPham.soDienThoai);
            com.Parameters.AddWithValue("@diaChi", nguoiViPham.diaChi);
            com.Parameters.AddWithValue("@quocTich", nguoiViPham.quocTich);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
        #endregion Thao tác bảng người vi phạm

        #region thao tác bảng Nhân Viên
        public List<NhanVien> XemThongTinCaNhan(string taikhoan)
        {
            var data = context.NhanViens.SqlQuery("[dbo].[LayThongTinCaNhan] @taikhoan", new SqlParameter("taiKhoan", taikhoan)).ToList();
            return data;
        }

        public List<NhanVien> layDSNhanVien()
        {
            return context.NhanViens.ToList();
        }

        public IEnumerable<NhanVien> ListWhereNV(string keysearch, int page, int pagesize)
        {
            IQueryable<NhanVien> model = context.NhanViens;
            if (!string.IsNullOrEmpty(keysearch))
                model = model.Where(x => x.hoTen.Contains(keysearch));
            return model.OrderBy(x => x.soCMND).ToPagedList(page, pagesize);
        }

        public NhanVien FindNV(int id)
        {
            return context.NhanViens.Find(id);
        }

        public string EditNV(NhanVien entity)
        {
            var sp = FindNV(entity.maSo);
            if (sp == null)
            {
                context.NhanViens.Add(entity);
            }
            else
            {
                sp.hoTen = entity.hoTen;
                sp.gioiTinh = entity.gioiTinh;
                sp.ngaySinh = entity.ngaySinh;
                sp.soCMND = entity.soCMND;
                sp.soDienThoai = entity.soDienThoai;
                sp.email = entity.email;
                sp.donVi = entity.donVi;
                sp.diaChi = entity.diaChi;
            }
            context.SaveChanges();
            return entity.maSo.ToString();
        }

        public void SuaThongTinCaNhan(NhanVien nhanVien)
        {
            SqlCommand com = new SqlCommand("SuaThongTinCaNhan", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CMND", nhanVien.soCMND);
            com.Parameters.AddWithValue("@hoTen", nhanVien.hoTen);
            com.Parameters.AddWithValue("@gioiTinh", nhanVien.gioiTinh);
            com.Parameters.AddWithValue("@ngaySinh", nhanVien.ngaySinh);
            com.Parameters.AddWithValue("@sdt", nhanVien.soDienThoai);
            com.Parameters.AddWithValue("@email", nhanVien.soDienThoai);
            com.Parameters.AddWithValue("@diaChi", nhanVien.diaChi);
            com.Parameters.AddWithValue("@donVi", nhanVien.donVi);
            com.Parameters.AddWithValue("@taiKhoan", nhanVien.taiKhoan);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
        #endregion

        #region Thao tác bảng thông tin biên lai
        public List<TTBienLai> LayBienLai()
        {
            return context.TTBienLais.ToList();
        }

        public IEnumerable<TTBienLai> TimBienLai(string keysearch, int page, int pagesize)
        {
            IQueryable<TTBienLai> model = context.TTBienLais;
            if (!string.IsNullOrEmpty(keysearch))
                model = model.Where(x => x.maBienBan.Contains(keysearch));
            return model.OrderBy(x => x.maBienBan).ToPagedList(page, pagesize);
        }

        public void ThemBienLai(TTBienLai dM)
        {
            SqlCommand com = new SqlCommand("ThemBienLai", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@maBienLai", dM.maBienLai);
            com.Parameters.AddWithValue("@maBienBan", dM.maBienBan);
            com.Parameters.AddWithValue("@tinhTrangNopPhat", dM.tinhTrangNopPhat);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
        public void XacNhanBienLai(string maBienBan)
        {
            SqlCommand com = new SqlCommand("XacNhanBienLai", conn);
            com.CommandType = CommandType.StoredProcedure;            
            com.Parameters.AddWithValue("@maBienBan", maBienBan);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }

        public bool DeleteBL(int id)
        {
            try
            {
                var sp = context.TTBienLais.Find(id);
                context.TTBienLais.Remove(sp);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TTBienLai FindBL(int id)
        {
            return context.TTBienLais.Find(id);
        }

        public string EditBL(TTBienLai entity)
        {
            var sp = FindBL(entity.maBienLai);
            if (sp == null)
            {
                context.TTBienLais.Add(entity);
            }
            else
            {
                sp.maBienBan = entity.maBienBan;
                sp.ngayXuat = entity.ngayXuat;
                sp.tinhTrangNopPhat = entity.tinhTrangNopPhat;
            }
            context.SaveChanges();
            return entity.maBienLai.ToString();
        }
        #endregion

        #region thao tác với Client
        public List<ThongTinBienBan> TimBienBan(string bienSoXe)
        {
            var data = context.ThongTinBienBans.SqlQuery("[dbo].[TimBienBan] @bienSoXe", new SqlParameter("bienSoXe", bienSoXe)).ToList();
            return data;
        }

        public List<ThongTinBienBan> TimBienBanCMND(string soCMND)
        {
            var data = context.ThongTinBienBans.SqlQuery("[dbo].[TimBienBanCMND] @soCMND", new SqlParameter("soCMND", soCMND)).ToList();
            return data;
        }
        #endregion
    
    }
}