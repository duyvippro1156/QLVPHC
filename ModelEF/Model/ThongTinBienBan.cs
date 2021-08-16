namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinBienBan")]
    public partial class ThongTinBienBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTinBienBan()
        {
            TTBienLais = new HashSet<TTBienLai>();
        }

        [Key]
        [StringLength(5)]
        public string maBienBan { get; set; }

        [StringLength(9)]
        public string soCMND { get; set; }

        [StringLength(100)]
        public string bienSoXe { get; set; }

        [StringLength(100)]
        public string giayPhepLaiXe { get; set; }

        [StringLength(5)]
        public string maLoiViPham { get; set; }

        [StringLength(200)]
        public string diaDiemViPham { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayViPham { get; set; }

        public int? maThanhTra { get; set; }

        [StringLength(200)]
        public string tangVatTamGiu { get; set; }

        public virtual MucPhat MucPhat { get; set; }

        public virtual NguoiViPham NguoiViPham { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual ThongTinTangVatTamGiu ThongTinTangVatTamGiu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTBienLai> TTBienLais { get; set; }
    }
}
