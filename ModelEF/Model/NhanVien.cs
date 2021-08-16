namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            ThongTinBienBans = new HashSet<ThongTinBienBan>();
        }

        [Key]
        public int maSo { get; set; }

        [StringLength(100)]
        public string hoTen { get; set; }

        public bool? gioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaySinh { get; set; }

        [StringLength(9)]
        public string soCMND { get; set; }

        [StringLength(10)]
        public string soDienThoai { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(100)]
        public string donVi { get; set; }

        [StringLength(200)]
        public string diaChi { get; set; }

        [Required]
        [StringLength(50)]
        public string taiKhoan { get; set; }

        public virtual TaiKhoan TaiKhoan1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinBienBan> ThongTinBienBans { get; set; }
    }
}
