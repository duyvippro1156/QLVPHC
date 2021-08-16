namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiViPham")]
    public partial class NguoiViPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiViPham()
        {
            ThongTinBienBans = new HashSet<ThongTinBienBan>();
        }

        [Key]
        [StringLength(9)]
        public string soCMND { get; set; }

        [StringLength(200)]
        public string hoTen { get; set; }

        public bool? gioiTinh { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? ngaySinh { get; set; }

        [StringLength(10)]
        public string soDienThoai { get; set; }

        [StringLength(200)]
        public string diaChi { get; set; }

        [StringLength(100)]
        public string quocTich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinBienBan> ThongTinBienBans { get; set; }
    }
}
